using ir.expert.DB;
using ir.expert.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ir.expert.SMS
{
    public static class SMSservice
    {
        public static Boolean gotSMSfromUser (string paraUserName,string paraSMS)
        {
            string s;
            ir.expert.signalR.SysetemHub.debug_connections.TryGetValue(paraUserName + paraSMS, out s);
            if (s != null) {
            Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext("SysetemHub").Clients.Client(s).showAppFace(1,"ok,we got sms!");
            if (DbUtilities.isUserStatusEnable(paraUserName, user.user.UserStatus.USER_STATUS_VERIFING)){
                if (isUserSMSandVerifyKeyOK(paraUserName, paraSMS,paraUserName))
                {
                    DbUtilities.disableUserStatus(paraUserName, user.user.UserStatus.USER_STATUS_VERIFING);
                    
                }
            }
                return true;
            }
            return false;
           
        }
        private static Boolean isUserSMSandVerifyKeyOK(string paraUserSMS,string paraSMS,string paraUserName)
        {
            user.user userToCheck = Users.getOnlineUser(paraUserName);
            if (userToCheck != null)
            {
                if (userToCheck.LastVerificationCode == paraSMS)
                {
                    return true;
                }
            }
            return false;

           // throw new NotImplementedException();
        }
    }
}