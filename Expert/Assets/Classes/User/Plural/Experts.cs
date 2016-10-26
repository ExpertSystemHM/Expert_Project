using ir.expert.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.user
{
    public  class Experts:Users
    {
    

        #region Methods
        private static Dictionary<string,user> _activeExpertsDictionary = new Dictionary<string, user>();
        public override  bool BlockUser(string paraUserName)
        {
            if (DbUtilities.enableUserStatus(paraUserName,user.UserStatus.USER_STATUS_BLOCKED))  {
                ChangeFaceToIfIsOnLine(paraUserName, Users.Face_types.FACE_BLOCKED);

            }
            
            return true;
        }
        public override  bool DeleteUser(string paraUserName)
        {
            DbUtilities.DeleteUser(paraUserName);

            return true;
        }
        protected override void ChangeFaceToIfIsOnLine(string paraUserName, Users.Face_types paraUserfaceType)
        {
            user foundUser = new user();
            if(_onlineUsersDictionary.TryGetValue(paraUserName,out foundUser))
            {
                changeUserAppFace(foundUser, paraUserfaceType);

            }
            
        }

        protected override void changeUserAppFace(user foundUser, Face_types fACE_BLOCKED)
        {
            throw new NotImplementedException();
        }

        public static user RegisterExpertUser(string paraUserName, string paraPassword, string paraMobileNumber, user.UserType paratype)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}