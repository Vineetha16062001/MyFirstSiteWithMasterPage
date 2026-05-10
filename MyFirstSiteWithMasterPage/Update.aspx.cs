using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstSiteWithMasterPage
{
    public partial class Update : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();

                    txtEmail.Text = email;   // ✅ THIS shows the email
                    LoadUser(email);         // load other details
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

        // 🔹 Load existing user data into form
        private void LoadUser(string email)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query = "SELECT * FROM [5680Labs].[dbo].[Logins] WHERE User_Email=@Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    txtFname.Text = dr["User_FName"].ToString();
                    txtLname.Text = dr["User_LName"].ToString();
                    txtDob.Text = dr["User_YOB"].ToString();
                }
            }
        }

        // 🔹 Insert or Update
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string email = txtEmail.Text.Trim();

                // 🔍 Check if user exists
                string checkQuery = "SELECT COUNT(*) FROM [5680Labs].[dbo].[Logins] WHERE User_Email=@Email";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);

                int count = (int)checkCmd.ExecuteScalar();

                // 🔐 Handle password
                string finalPassword = "";

                if (count > 0) // UPDATE MODE
                {
                    // Disable password validators
                    rfvPassword.Enabled = false;

                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        // Get existing password
                        string getPassQuery = "SELECT User_Pass FROM [5680Labs].[dbo].[Logins] WHERE User_Email=@Email";
                        SqlCommand getCmd = new SqlCommand(getPassQuery, conn);
                        getCmd.Parameters.AddWithValue("@Email", email);

                        finalPassword = getCmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        finalPassword = GetHash(txtPassword.Text);
                    }

                    // 🔁 UPDATE QUERY
                    string updateQuery = @"UPDATE [5680Labs].[dbo].[Logins] 
                           SET User_Pass=@Password,
                               User_FName=@FirstName,
                               User_LName=@LastName,
                               User_YOB=@YearOfBirth
                           WHERE User_Email=@Email";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", finalPassword);
                    cmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
                    cmd.Parameters.AddWithValue("@YearOfBirth", txtDob.Text.Trim());

                    cmd.ExecuteNonQuery();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "User updated successfully!";

                }

            }
        }
    }
}