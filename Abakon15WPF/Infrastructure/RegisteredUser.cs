using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel;
using Abakon15WPF.Utility;
using System.Xml.Linq;
using System.Windows;

namespace Abakon15WPF.Infrastructure
{
    public interface Iperson
    {
    }
    public class personTest : Iperson
    {
    }




    public sealed class RegisteredUser
    {

        static private EventHandler _userChanged;
        public static event EventHandler UserChanged
        {
            add { _userChanged += value; }
            remove { _userChanged -= value; }
        }

        private static _User userInDB;

        //TODO Jeśli nie dopuszczamy użytkowników anonimowych, należy zmienić na false
        private static bool anonymousAllowed = false;

        private static RegisteredUser instance;
        public static RegisteredUser CurrentUser
        {
            get { return instance; }
            set
            {
                if (instance != value)
                {
                    instance = value;
                    _userChanged(instance, new EventArgs());
                }
            }
        }

        //====================== Ustawienia aplikacji ============================
        //public bool isLimitAccessToPartnersDisable { get; set; }
        //public bool isLimitAccessToProjectDisable { get; set; }
        //public bool isLimitAccessToOfferDisable { get; set; }

        public int UserId { get; set; }
        string Password { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public int LevelOfConfidence { get; set; }
        bool IsAnonymous { get; set; }
        public bool IsNeedChangePassword { get; set; }
        public _Membership membership { get; set; }
        public List<GenPrivilege> ListOfPrivileges { get; set; }

        //===================== Ustawienia uprawniń użytkownika ==================
        //public List<int> allowedDocumentClassifiers { get; set; }
        //public List<int> allowedPartners { get; set; }
        //public List<int> allowedProjects { get; set; }
        //public List<int> allowedOffers { get; set; }
        public List<Guid> allowedEquipments { get; set; }

        public bool hasPrivilege(string privilegeName)
        {
            if (ListOfPrivileges != null)
            {
                return ListOfPrivileges.Find(p => p.Name == privilegeName) != null;
            }
            else
            {
                return false;
            }
        }

        public bool hasReadPrivilege(string privilegeName)
        {
            if (privilegeName == string.Empty) return true;
            if (ListOfPrivileges != null)
            {
                var pr = ListOfPrivileges.Find(p => p.Name == privilegeName + "_R" || p.Name == privilegeName + "_W");
                return pr != null;
            }
            else
            {
                return false;
            }
        }

        public bool hasPrivilege(PrivilegeListEnum privilege)
        {
            return true;
            //todo if (ListOfPrivileges != null)
            //{
            //    var pr = ListOfPrivileges.Find(p => p.Key == privilege);
            //    return pr != null;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool hasWritePrivilege(string privilegeName)
        {
            if (privilegeName == string.Empty) return true;
            if (ListOfPrivileges != null)
            {
                return ListOfPrivileges.Find(p => p.Name == privilegeName + "_W") != null;
            }
            else
            {
                return false;
            }
        }

        public bool isAdmin
        {
            get
            {
                return hasPrivilege("_admin");
            }
        }

        private RegisteredUser() { }

        public static StateOfExecution CreateRegisteredUser(_Application _appState, _User user)
        {
#if !GE
            //if (_appState.LicenceDescription == null || _appState.LicenceDescription.Trim().Length == 0)
            //{
            //  _appState.LicenceDescription = XMLUtility.CreateInitLicence();
            //  _appState.SaveData();
            //}
            //else
            //{
            if (XMLUtility.CreateInitLicence(_appState.LicenceDescription))
            {
                _appState.LicenceDescription = XMLUtility.CreateTryLicence();
                _appState.SaveData();
            }
            else
            {
                XElement licence = XMLUtility.GetLicence(_appState.LicenceDescription);
                XElement sessions = XMLUtility.GetSessions(_appState.Sessions);

                switch (licence.Attribute("Type").Value)
                {
                    case "try":
                        {
                            int zostaloDni = 60 - DateTime.Today.Subtract(DateTime.ParseExact(licence.Attribute("StartDate").Value, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture)).Days;
                            if (zostaloDni > 0)
                            {
                                string guid = licence.Attribute("UserId").Value;
                                System.Windows.MessageBox.Show("_youStillHave".Translate() + " " + zostaloDni.ToString() + " " + "_trialPeriod".Translate());
                                string kom = "_registerApplication".Translate();
                                string komHeader = "_confirm".Translate();
                                if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                {
                                    //todo instalacja licencji

                                    _appState.LicenceDescription = XMLUtility.UpdateLicence(licence);
                                    _appState.SaveData();
                                }
                                else if (MessageBox.Show("_ifPurchaseLicense".Translate(), komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                {
                                    //todo zamawianie licencji
                                    PurchaseLicense(_appState.LicenceDescription);
                                }
                                if (LogeedUsersCount(sessions) >= 3)
                                {
                                    System.Windows.MessageBox.Show("_limitLoginsExceeded ".Translate());
                                    Application.Current.Shutdown();
                                }
                                else
                                {
                                    RegisterLoggedUser(sessions);
                                    _appState.Sessions = XMLUtility.SaveSessions(sessions);
                                    _appState.SaveData();
                                }
                            }
                            else
                            {
                                string kom = "_endOfTryPeriod".Translate() + ":" + Environment.NewLine + "_registerApplication".Translate();
                                string komHeader = "_confirm".Translate();
                                if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                {
                                    //todo instalacja licencji


                                    _appState.LicenceDescription = XMLUtility.UpdateLicence(licence);
                                    _appState.SaveData();
                                }
                                else
                                {
                                    if (MessageBox.Show("_ifPurchaseLicense".Translate(), komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                    {
                                        //todo zamawianie licencji
                                        Application.Current.Shutdown();
                                    }

                                    else
                                    {
                                        Application.Current.Shutdown();
                                    }
                                }
                            }


                            break;
                        }
                    case "user":
                        {
                            string guid = licence.Attribute("UserId").Value;
                            int limitLogins = int.Parse(licence.Attribute("LoginLimit").Value);
                            if (LogeedUsersCount(sessions) >= limitLogins)
                            {
                                System.Windows.MessageBox.Show("_limitLoginsExceeded ".Translate());
                                Application.Current.Shutdown();
                            }
                            else
                            {
                                RegisterLoggedUser(sessions);
                                _appState.Sessions = XMLUtility.SaveSessions(sessions);
                                _appState.SaveData();
                            }
                            break;
                        }


                    default:
                        break;
                }

            }

#endif

            instance = new RegisteredUser();
            userInDB = user;
            StateOfExecution result = new StateOfExecution();
            instance.ListOfPrivileges = new List<GenPrivilege>();
            instance.allowedEquipments = new List<Guid>();
            if (user == null)
                if (anonymousAllowed)
                {
                    instance.UserId = -1;
                    instance.UserName = "_anonymous".Translate();
                    instance.LoweredUserName = instance.UserName;
                    instance.Password = "";
                    instance.LevelOfConfidence = 0;
                    instance.IsAnonymous = true;
                    instance.ListOfPrivileges = new List<GenPrivilege>();
                    instance.IsNeedChangePassword = false;
                    result.OperationOK = true;
                    return result;
                }
                else
                {

                    result.CreateException("_anonymousNoAllowed".Translate());
                    result.OperationOK = false;
                    return result;
                }
            else
            {

                if (user.person != null)
                {
                    UpadateSignatureExt.LoggedUserName = user.person.SureFirstName; // string.Format("{0} ({1})", user.UserName, user.person.SureFirstName);
                }
                else
                {
                    UpadateSignatureExt.LoggedUserName = user.UserName;
                }
                instance.UserId = user.UserId;
                instance.UserName = user.UserName;
                instance.LoweredUserName = user.LoweredUserName;
                instance.Password = user.Password;
                instance.LevelOfConfidence = user.LevelOfConfidence;
                instance.IsAnonymous = false;

                instance.ListOfPrivileges = user.privilegeList;
                instance.IsNeedChangePassword = user.IsNeedChangePassword;
                result.OperationOK = true;
            }
            return result;
        }

        private static void PurchaseLicense(string oldLicence)
        {
            string attachFile = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/oldLicence.txt";
            System.IO.File.WriteAllText(attachFile, oldLicence);
            MAPI mapi = new MAPI();
            mapi.AddAttachment(attachFile);
            mapi.AddRecipientTo("z.benedykt@post.pl");
            mapi.SendMailPopup("_licenceEmailSubject".Translate(), "_orderLicence".Translate());
        }

        private static void RegisterLoggedUser(XElement sessions)
        {
            XMLUtility.LoggedUsersAdd(ref  sessions);
        }

        private static int LogeedUsersCount(XElement sessions)
        {
            return XMLUtility.LoggedUsersCount(sessions);
        }


        public static void UpdateAllowedLists(IappUser user)
        {
            //instance.allowedPartners = user.person.GetListPartnerIds();
            //instance.allowedProjects = user.person.GetListProjectIds();
            //instance.allowedOffers = user.person.GetListOfferIds();
        }

        public static bool PasswordCorrect(string password)
        {
            bool response = false;
            if (instance != null)
            {
                if (instance.IsAnonymous)
                {
                    response = true;
                }
                else
                {
                    if ((instance.Password == null || instance.Password.Trim() == "") && password.Trim() == "") return true;
                    response = instance.Password == EncodeString(password);
                }
            }
            return response;
        }

        public static void ChangePassword(string password)
        {

            //CurrentUser.membership.Password = EncodeString(password);
            //CurrentUser.membership.IsLockedOut = false;
            userInDB.membership.Password = EncodeString(password);
            userInDB.membership.IsLockedOut = false;
            userInDB.Update();
        }

        public static void ChangePassword(_User user, string password, bool needChange)
        {
            user.membership.Password = EncodeString(password);
            user.membership.IsLockedOut = needChange;
            user.Update();
        }


        static string EncodeString(string str)
        {
            byte[] data;
            data = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] hash = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            return enc.GetString(hash);
        }

        static byte[] EncodeByte(string str)
        {
            byte[] data;
            data = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] hash = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return hash;
        }

    }
}
