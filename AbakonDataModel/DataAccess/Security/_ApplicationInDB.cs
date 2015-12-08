using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class _ApplicationInDB : DataAccessBaseClass
    {

        internal static _Application ThisApplication()
        {
            try
            {
                PgSqlDBContext mContext = defaultContext;
                _Application result = defaultContext._ApplicationDbSet.FirstOrDefault(a => a.ApplicationName == "Abakon");
                if (result == null)
                {
                    result = new _Application();
                    result.ApplicationName = "Abakon";
                    result.LicenceDescription = Math.Exp(Math.PI).ToString();
                    mContext._ApplicationDbSet.Add(result);
                    DataAccessBaseClass.SaveChanges();
                    mContext.Entry(result).Reload();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
              //  return null;
            }
        }



        internal static bool CanConnectToDB()
        {
            try
            {
                _Application result = defaultContext._ApplicationDbSet.FirstOrDefault(a => a.ApplicationName == "Abakon");
                _User.CreateFirstAdmin(result.ApplicationId);
                return true;
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                return false;
            }
        }
    }
}
