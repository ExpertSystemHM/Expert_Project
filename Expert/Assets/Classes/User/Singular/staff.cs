using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.user
{
    public class staff : userWtihCommonPersonalInformation
    {
        public staff(string paraUserName, string paraPassword, string paraMobileNumber, string paraFirstName, string paraLastName, string paraEmail) : base(paraUserName, paraPassword, paraMobileNumber, paraFirstName, paraLastName, paraEmail)
        {
        }
    }
}