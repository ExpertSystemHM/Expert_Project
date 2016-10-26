using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ir.expert.DB;

namespace ir.expert.user
{
    public  class Users
    {
        #region Constants
        public enum Face_types
        {
            FACE_BLOCKED,

        }
        //public const string FACE_BLOCKED = "BLOCKED";
        #endregion

        #region Methods
        public static Dictionary<string, user> _debugAllUsers = new Dictionary<string, user>();
        protected static Dictionary<string,user> _onlineUsersDictionary = new Dictionary<string, user>();
        public static user getOnlineUser(string paraUserName)
        {
            user returnUser = new user();
           if( _onlineUsersDictionary.TryGetValue(paraUserName, out returnUser)){
                return returnUser;

            }else
            {
                return null;
            }

        }
        public static string GenerateSMSVerificationText(string number) { return ""; }
        public static bool isUsernameAvailable(string paraUserName)
        {
#if DEBUG
            user tmpUser = new user();
            return !(_debugAllUsers.TryGetValue(paraUserName,out  tmpUser));
#else
            throw new NotImplementedException();
#endif
        }
        public  static user RegisterUser(string paraUserName,string paraPassword,string paraMobileNumber,user.UserType paratype)
        {
           // user tmp_user = DbUtilities.getUser(paraUserName);
            if (DbUtilities.isUserRegistered(paraUserName))
            {
                return null;
            }else
            {
                switch (paratype)
                {
                    case user.UserType.TYPE_CLIENT:
                       return Clients.RegisterClientUser(paraUserName, paraPassword, paraMobileNumber, paratype);
                        break;
                    case user.UserType.TYPE_EXPERT:
                        return Experts.RegisterExpertUser(paraUserName, paraPassword, paraMobileNumber, paratype);
                        break;
                    case user.UserType.TYPE_STAFF:
                        return Staffs.RegisterStaffUser(paraUserName, paraPassword, paraMobileNumber, paratype);
                        break;
                     default:
                        return null;
                }
               
                
            }
            
        }

        public virtual  bool BlockUser(string paraUserName)
        {
            if (DbUtilities.enableUserStatus(paraUserName,user.UserStatus.USER_STATUS_BLOCKED))  {
                ChangeFaceToIfIsOnLine(paraUserName,Users.Face_types.FACE_BLOCKED);
                
            }
            
            return true;
        }
        public virtual  bool DeleteUser(string paraUserName)
        {
            DbUtilities.DeleteUser(paraUserName);
            //DbUtilities.enableUserStatus(paraUserName, user.UserStatus.USER_STATUS_DELETED);

            return true;
        }
        protected virtual  void ChangeFaceToIfIsOnLine(string paraUserName,Users.Face_types paraUserfaceType)
        {
            user foundUser = new user();
            if(_onlineUsersDictionary.TryGetValue(paraUserName,out foundUser))
            {
                changeUserAppFace(foundUser, paraUserfaceType);

            }
            
        }

        protected virtual void changeUserAppFace(user foundUser, Users.Face_types paraface_type)
        {
#if DEBUG
            var hub= Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ir.expert.signalR.SysetemHub>();
            hub.Clients.Group(foundUser.debug_PrivateGroupID).changeFaceTo(paraface_type);
                #else
            throw new NotImplementedException();
#endif
        }
#endregion
    }
}