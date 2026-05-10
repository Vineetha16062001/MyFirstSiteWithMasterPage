using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstSiteWithMasterPage
{
    public partial class AcctSuccessfull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "Registered successfully!";
                lnkLogin.Visible = true;
            }

        }
    }
}