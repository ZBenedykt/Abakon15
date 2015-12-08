using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AbakonDataModel
{
    public class ConnectionString
    {
        private ConnectionString() { }

        private static string instance = string.Empty;

        public static void CreateConnectionString(string server, string DbName = "OmetrisisDB", bool authent = true, string user = "", string password = "")
        {
            if (authent)
            {
                instance = string.Format(@"Server={0}; Trusted_Connection=true; Database={1}", server, DbName);
            }
            else
            {
                instance = string.Format(@"Server={0}; User ID={1}; Password={3}; Database={2}", server, user, DbName, password);
            }
        }

        public static string GetConnectionString()
        {
            return instance;
        }

        public static bool TestConnection()
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(instance))
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    return result;
                }

                using (SqlCommand command = new SqlCommand("SELECT Count(*) FROM [_Application] Where ApplicationName = 'Ometrisis'", con))
                {
                    try
                    {
                        result = (int)command.ExecuteScalar() == 1;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return result;
        }



    }
}
