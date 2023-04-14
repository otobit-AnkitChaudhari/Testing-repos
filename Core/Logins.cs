using Microsoft.AspNetCore.Mvc.Routing;
using SqlAuthenticationContext;
using System;
using System.Linq;
using Testing.MODEL;

namespace Testing.Core
{
    public class Logins
    {
        public MODEL.Login GetLogins(int id)
        {
            var C = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var LOGIN = C.LoginTables.Where(C => C.PwdId == id).FirstOrDefault();
            var res = new MODEL.Login();
            res.Pwdid = LOGIN.PwdId;
            res.PwdName = LOGIN.PwdName;
            return res;
        }

        public string CreateLogins(MODEL.Login value)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var Login = new LoginTable()
            {
                PwdId = value.Pwdid,
                PwdName = value.PwdName
            };
            c.LoginTables.InsertOnSubmit(Login);
            c.SubmitChanges();
            return "Success";
        }

        public string EditLogin(int id, MODEL.Login value)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var login = c.LoginTables.Where(z => z.PwdId== id).FirstOrDefault();
            login.PwdId = value.Pwdid;
            login.PwdName = value.PwdName;
            c.SubmitChanges();

            return "success";

        }
        public string DeleteLogin(int id)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var login = c.LoginTables.Where(c => c.PwdId== id).FirstOrDefault(); 
            c.LoginTables.DeleteOnSubmit(login);    
            c.SubmitChanges();
            return "Success";
        }
    }
}
