using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstSiteWithMasterPage
{
    public partial class LoginScucess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                lblWelcome.Text = "Welcome " + Session["Email"].ToString();
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }



        protected void btnContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }
        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }

        protected void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string sessionEmail = Session["Email"]?.ToString();

            // 1. Check if user is logged in
            if (sessionEmail == null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            // 2. Check if email matches input
            if (txtConfirmEmail.Text != sessionEmail)
            {
                lblDeleteError.Text = "Email does not match. Please try again.";
                return;
            }

            // 3. Delete from database
            string connectionString = System.Configuration.ConfigurationManager
                                      .ConnectionStrings["MyDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"DELETE FROM [5680Labs].[dbo].[Logins]
                         WHERE User_Email = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", sessionEmail);

                cmd.ExecuteNonQuery();
            }

            // 4. Logout user
            Session.Clear();

            // 5. Go to success page
            Response.Redirect("Register.aspx?deleted=true");
        }
    }
}