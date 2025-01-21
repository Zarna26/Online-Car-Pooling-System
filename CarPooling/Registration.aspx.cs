using System;
using System.Data.SqlClient; // For database connection
using System.Configuration; // To access connection string

namespace CarPoolingProject
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear any message on initial load
            if (!IsPostBack)
            {
                //lblMessage.Text = string.Empty;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                DisplayMessage("All fields are required.", "error");
                return;
            }

            // Check for valid email format
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                DisplayMessage("Please enter a valid email address.", "error");
                return;
            }

            // Database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Check if the email already exists
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand cmdCheck = new SqlCommand(checkEmailQuery, con))
                    {
                        cmdCheck.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        int emailExists = (int)cmdCheck.ExecuteScalar();

                        if (emailExists > 0)
                        {
                            DisplayMessage("Email already exists. Please use a different email.", "error");
                            return;
                        }
                    }

                    // Insert the new user into the database
                    string query = "INSERT INTO Users (FullName, Email, Password, PhoneNumber) VALUES (@FullName, @Email, @Password, @PhoneNumber)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim()); // Ideally, hash the password
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DisplayMessage("Registration successful! Redirecting to login page...", "success");

                            // Redirect to login page after 3 seconds
                            Response.AddHeader("REFRESH", "3;URL=Login.aspx");
                        }
                        else
                        {
                            DisplayMessage("Registration failed. Please try again.", "error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display a generic error message
                    DisplayMessage("An error occurred: " + ex.Message, "error");
                }
            }
        }

        private void DisplayMessage(string message, string cssClass)
        {
            //lblMessage.Text = message;
            //lblMessage.CssClass = cssClass; // Assign CSS class for styling (e.g., "success" or "error")
            //lblMessage.Visible = true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
