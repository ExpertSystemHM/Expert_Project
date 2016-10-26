using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ir.expert.signalR
{
    public class SysetemHub : Hub
    {
        public static Dictionary<string, string> debug_connections = new Dictionary<string, string>();
        private static Random _randomGenerator = new Random(Environment.TickCount);
       
        public override Task OnConnected()
        {
            /*   if (!aTimer.Enabled)
               {
                   aTimer.Elapsed += ATimer_Elapsed;
                   aTimer.Enabled = true;
               }*/



            return base.OnConnected();
        }

      

        public void send(string na, string mess)
        {
            Clients.All.myCid(Context.ConnectionId);
            Clients.All.broadcastMessage(na, mess);
        }
        //-------------------------------------------------------
        public bool RegisterUser(string name, string family, string password, string mobile, string username)
        {
            if (username.Trim() == "" || password.Trim() == "" || mobile.Trim() =="")
            {
                return false;
            }
            
            user.user tmpUser= user.Users.RegisterUser(username, password, mobile, user.user.UserType.TYPE_CLIENT);
            if (tmpUser != null)
            {
                debug_connections.Add(mobile + "1234", Context.ConnectionId);
                return true;
            }
            return false;
        }
        public bool CheckUserNameAvailablity(string userName)
        {
           return user.Users.isUsernameAvailable(userName);
        }
        public string GetVerificationCode()
        {
            return _randomGenerator.Next(1000, 9999).ToString();
        }
    }
}