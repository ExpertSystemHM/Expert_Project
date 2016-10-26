using ir.expert.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.user
{
    public  class Clients:Users
    {


        #region Methods
        private static Dictionary<string, user> _activeClientsDictionary = new Dictionary<string, user>();
        public override  bool BlockUser(string paraUserName)
        {
            if (DbUtilities.enableUserStatus(paraUserName,user.UserStatus.USER_STATUS_BLOCKED))  {
                ChangeFaceToIfIsOnLine(paraUserName, Users.Face_types.FACE_BLOCKED);


            }
            
            return true;
        }
        public override bool DeleteUser(string paraUserName)
        {
            DbUtilities.DeleteUser(paraUserName);

            return true;
        }
        protected override void ChangeFaceToIfIsOnLine(string paraUserName, Users.Face_types paraUserFaceType)
        {
            user foundUser = new user();
            if (_onlineUsersDictionary.TryGetValue(paraUserName, out foundUser))
            {
                changeUserAppFace(foundUser, paraUserFaceType);

            }

        }

        public static user RegisterClientUser(string paraUserName, string paraPassword, string paraMobileNumber, user.UserType paratype)
        {
            Dictionary<string, Object> tmpInsertParameters = new Dictionary<string, object>();
            tmpInsertParameters.Add("UserName", paraUserName);
            tmpInsertParameters.Add("Password", paraPassword);
            tmpInsertParameters.Add("MobileNumber", paraMobileNumber);
           user tmpUser= DbUtilities.InsertUser(tmpInsertParameters);
            DbUtilities.enableUserStatus(paraUserName, user.UserStatus.USER_STATUS_ONLINE | user.UserStatus.USER_STATUS_VERIFING);
            return tmpUser;
           // throw new NotImplementedException();
        }

        protected override void changeUserAppFace(user foundUser, Users.Face_types paraface_type)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}