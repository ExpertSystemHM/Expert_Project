using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.user
{
    public class user
    {
        #region Constants
        public enum UserType
        {
            TYPE_CLIENT=0x00000001,
                TYPE_EXPERT = 0x00000002,
                TYPE_STAFF = 0x00000004
        }
        public enum UserStatus
        {
            USER_STATUS_ACTIVE = 0x00000001,
            USER_STATUS_BLOCKED = 0x00000002,
            USER_STATUS_ONLINE = 0x00000004,       
            USER_STATUS_DELETED = 0x00000010,
            USER_STATUS_VERIFING=0X00000020

        }
        #endregion
        #region Constructors
        public user(string paraUserName,string paraPassword,string paraMobileNumber)
        {
            UserName = paraUserName;
            Password = paraPassword;
            MobileNumber = paraMobileNumber;
        }
        public user()
        {
            UserName = Password = MobileNumber = "";
        }
        #endregion

        #region Properties variables
        private string _userName;
        private string _password;
        private string _mobileNumber;
        private int _type;
        private string _lastVerificationCode;
        private int _status;
#if DEBUG
        private string _debug_PrivateGroupID;
#endif
        #endregion

        #region Properties definition
#if DEBUG
        public string debug_PrivateGroupID
        {
            get
            {
                return _debug_PrivateGroupID;
            }
            set
            {
                _debug_PrivateGroupID = value;
            }
        }
#endif
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value.Trim();
            }
        }
        public string LastVerificationCode
        {
            get
            {
                return _lastVerificationCode;
            }
            set
            {
                _lastVerificationCode = value.Trim();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value.Trim();
            }
        }
        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                _mobileNumber = value.Trim();
            }
        }
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        #endregion


    }
}