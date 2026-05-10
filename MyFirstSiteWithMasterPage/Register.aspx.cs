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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["deleted"] == "true")
                {
                    successCard.Visible = true;
                }
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            try
            {
                string connectionString = System.Configuration.ConfigurationManager
                                          .ConnectionStrings["MyDB"].ConnectionString;

                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string fname = txtFname.Text;
                string lname = txtLname.Text;
                string dob = txtDob.Text;

                // Hash password (same as login)
                string hashedPassword = GetHash(password);

                conn = new SqlConnection(connectionString);
                conn.Open();

                // Check if email already exists
                string checkQuery = "SELECT COUNT(*) FROM [5680Labs].[dbo].[Logins] WHERE User_Email=@Email";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);

                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    lblMessage.Text = "Email already registered!";
                    return;
                }

                // Insert new user
                string insertQuery = @"INSERT INTO [5680Labs].[dbo].[Logins]
                       (User_Email, User_Pass, User_FName, User_LName, User_YOB)
                       VALUES (@Email, @Password, @Fname, @Lname, @DOB)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Fname", fname);
                cmd.Parameters.AddWithValue("@Lname", lname);
                cmd.Parameters.AddWithValue("@DOB", dob);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    lblMessage.Text = "Registration Successful!";
                    Response.Redirect("AcctSuccessfull.aspx");
                }
                else
                {
                    lblMessage.Text = "Registration Failed!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
    }
}