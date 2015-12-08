using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows;

namespace Abakon15WPF.Utility
{
    public static class RijndaelCrypto
    {
        public static string EncryptString(string plainText)
        {
            byte[] Key = PasswordCrypto.GetPsw();
            byte[] IV = PasswordCrypto.GetPswIV();

            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
            {
                MessageBox.Show("Brak tekstu do zakodowania", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an Rijndael object 
            // with the specified key and IV. 
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptString(string encryptedText)
        {
            byte[] Key = PasswordCrypto.GetPsw();
            byte[] IV = PasswordCrypto.GetPswIV();
            if (encryptedText == null || encryptedText.Length <= 0)
            {
                //  MessageBox.Show("Brak zakodowanego tekstu", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            byte[] cipherText;
            try
            {
                cipherText = Convert.FromBase64String(encryptedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błędny zapis licencji" + System.Environment.NewLine, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Rijndael object 
            // with the specified key and IV. 
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {

                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }

    public static class PasswordCrypto
    {
        static string secPsswrd;

        static PasswordCrypto()
        {
            secPsswrd = "łśngźq2xprż3vń";
        }

        //public static string EncodeString(string str)
        //{
        //    secPsswrd = str;
        //    byte[] ppp = GetPsw();
        //    byte[] data;
        //    data = Encoding.Unicode.GetBytes(str);
        //    byte[] hash = System.Security.Cryptography.MD5.Create().ComputeHash(data);
        //    System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
        //    return enc.GetString(hash);
        //}


        public static byte[] GetPsw()
        {
            string psswrd = secPsswrd;
            byte[] psswrdByte = new byte[32];
            if (psswrd != "")
            {
                for (int i = 0; i < 32; i++)
                {
                    int mod = (byte)psswrd.Length;
                    bool oddRound = (i / mod) % 2 == 1;
                    int ib = i % mod;
                    byte bp = (Byte)(psswrd[ib] ^ (19 * i % 255));
                    psswrdByte[i] = bp;
                }
            }
            return psswrdByte;
        }

        public static byte[] GetPswIV()
        {
            return new byte[] { 128, 52, 200, 211, 32, 59, 65, 45, 157, 1, 15, 35, 69, 19, 87, 250 };
        }

    }
}
