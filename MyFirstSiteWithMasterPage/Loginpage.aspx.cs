using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstSiteWithMasterPage
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                // User already logged in → skip login page
                Response.Redirect("LoginScucess.aspx");
            }
        }
        private string GetHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string connectionString = "your_connection_string_here";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            string enteredEmail = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            string hashedPassword = GetHash(enteredPassword);


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM [5680Labs].[dbo].[Logins] WHERE User_Email=@Email AND User_Pass=@PasswordHash";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", enteredEmail);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    Session["Email"] = enteredEmail;
                    Response.Redirect("LoginScucess.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid User ID or Password";
                }
            }

        }
    }
}