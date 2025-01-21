using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

namespace CarPoolingProject
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false; // Hide error label on initial page load
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text.Trim();
            string password = txtpass.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError("Email and Password cannot be empty.");
                return;
            }

            // Get connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["CarPoolingDB"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    const string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        con.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            // Successful login
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            // Unsuccessful login
                            ShowError("Invalid email or password. Please try again.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError("A database error occurred. Please try again later.");
                LogError(ex); // Optional: Implement logging for detailed error tracking
            }
            catch (Exception ex)
            {
                ShowError("An unexpected error occurred. Please try again later.");
                LogError(ex); // Optional: Implement logging for detailed error tracking
            }
        }

        protected void btnforget_Click(object sender, EventArgs e)
        {
            // Redirect to the Forgot Password page
            Response.Redirect("ForgotPassword.aspx");
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void LogError(Exception ex)
        {
            // Log the exception details for debugging (optional)
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }
}