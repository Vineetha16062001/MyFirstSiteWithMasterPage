using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstSiteWithMasterPage
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Session["Email"] == null)
            {
                // If not logged in, redirect to login page
                Response.Redirect("LoginPage.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string message = txtMessage.Text;

            lblResult.Text = "Thank you " + name + ", your message has been sent!";

            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";
        }
    }
}