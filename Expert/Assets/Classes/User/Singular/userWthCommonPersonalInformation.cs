using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.user
{
    public class userWtihCommonPersonalInformation:user
    {
        #region Constructors
        public userWtihCommonPersonalInformation(string paraUserName, string paraPassword, string paraMobileNumber, string paraFirstName, string paraLastName, string paraEmail) : base(paraUserName, paraPassword, paraMobileNumber)
        {
            FirstName = paraFirstName;
            LastName = paraLastName;
            Email = paraEmail;
        }
        #endregion

        #region Properties variables
        private string _email;
        private string _firstName;
        private string _lastName;
        #endregion

        #region Properties definition
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value.Trim();
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value.Trim();
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value.Trim();
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        #endregion

        
    }
}