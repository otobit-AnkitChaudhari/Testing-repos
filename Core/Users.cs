using SqlAuthenticationContext;
using System;
using System.Linq;
using Testing.MODEL;

namespace Testing.Core
{
    public class Users
    {
        public MODEL.User GetUser(int id)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var user = c.UserTables.Where(c => c.UserId == id).FirstOrDefault();
            var res = new MODEL.User();
            res.Userid = user.UserId;
            res.UserName = user.UserName;
            return res;
        }

        public string CreateUser(MODEL.User value)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var user = new UserTable()
            {
                UserId = value.Userid,
                UserName = value.UserName
            };
            c.UserTables.InsertOnSubmit(user);
             c.SubmitChanges();
            return "success";

        }
        public string EditUser(int id,MODEL.User value)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var user=c.UserTables.Where(z=>z.UserId==id).FirstOrDefault();
            user.UserId = value.Userid;
            user.UserName = value.UserName;
            c.SubmitChanges();

            return "success";

        }
        public string DeleteUser(int id)
        {
            var c = new SqlAuthenticationContext.SqlAuthenticationDataContext();
            var user = c.UserTables.Where(z => z.UserId == id).FirstOrDefault();
            c.UserTables.DeleteOnSubmit(user);
            c.SubmitChanges();

            return "success";

        }

    }
}
