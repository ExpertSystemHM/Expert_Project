using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ir.expert.SMS;
namespace Exper
{
    public partial class SMScallBackPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!check for secuirty,where a athunticated caller and with specifi ip call this
            if (Request["mobileNumber"] != null)
            {

                SMSservice.gotSMSfromUser(Request["mobileNumber"], Request["smsText"]);
                
                Response.Write("ok");
                Response.End();
            }
        }
    }
}