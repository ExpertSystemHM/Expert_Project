using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.DB
{
    public static class DbUtilities
    {
        public static ir.expert.user.user InsertUser(Dictionary<string,Object> paraParameters)
        {
#if DEBUG
            Object o = new Object();
            string name, password, mobile;
            paraParameters.TryGetValue("UserName", out o);
            name = o.ToString();
            paraParameters.TryGetValue("Password", out o);
            password = o.ToString();
            paraParameters.TryGetValue("MobileNumber", out o);
            mobile = o.ToString();

            user.user tmpUser = new user.user(name, password, mobile);
            user.Users._debugAllUsers.Add(name, tmpUser);
            return tmpUser;      
            
#else
            throw new NotImplementedException();
#endif    

            
        }
        public static Boolean isUserRegistered(string paraUserName)
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            return user.Users._debugAllUsers.TryGetValue(paraUserName,out tmpUser);

#else
            throw new NotImplementedException();
#endif
        }
        public static ir.expert.user.user getUser(string paraUserName)
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            if(user.Users._debugAllUsers.TryGetValue(paraUserName, out tmpUser))
            {
                return tmpUser;
            }
            return null ;

#else
            throw new NotImplementedException();
#endif
        }
        public static bool enableUserStatus(string paraUserName, ir.expert.user.user.UserStatus paraStatus )
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            if (user.Users._debugAllUsers.TryGetValue(paraUserName, out tmpUser))
            {
                tmpUser.Status =(int) tmpUser.Status |(int) paraStatus;

                return true;
            }
            return false;

#else
            throw new NotImplementedException();
#endif
        }
        public static bool isUserStatusEnable(string paraUserName, ir.expert.user.user.UserStatus paraStatus)
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            if (user.Users._debugAllUsers.TryGetValue(paraUserName, out tmpUser))
            {
                tmpUser.Status = (int)tmpUser.Status & (int)paraStatus;
                if (tmpUser.Status ==(int)paraStatus)
                {
                    return true;
                }
            }
            return false;

#else
            throw new NotImplementedException();
#endif
        }
        public static bool disableUserStatus(string paraUserName, ir.expert.user.user.UserStatus paraStatus)
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            if (user.Users._debugAllUsers.TryGetValue(paraUserName, out tmpUser))
            {
                tmpUser.Status = (int)tmpUser.Status & ~(int)paraStatus;

                return true;
            }
            return false;

#else
            throw new NotImplementedException();
#endif
        }
        public static bool DeleteUser(string paraUserName)
        {
#if DEBUG

            user.user tmpUser = new expert.user.user();
            if (user.Users._debugAllUsers.TryGetValue(paraUserName, out tmpUser))
            {
              //  tmpUser.Status = (int)tmpUser.Status & ~(int)paraStatus;
                enableUserStatus(paraUserName, ir.expert.user.user.UserStatus.USER_STATUS_DELETED);
                return true;
            }
            return false;

#else
            //transaction for clearing user data

            //end transaction
            throw new NotImplementedException();
#endif





        }
    }
}