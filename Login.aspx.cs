using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Security;
using MyCode.Models;

namespace MyCode
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["registered"] == "true")
                {
                    lblMessage.CssClass = "d-block mb-3 text-success";
                    lblMessage.Text = "✅ Account created! Please check your email and activate before logging in.";
                }
                else
                {
                    lblMessage.Text = "";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.CssClass = "d-block mb-3 text-danger";
                lblMessage.Text = "Please enter both email and password.";
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);

                if (user == null || !VerifyPassword(password, user.PasswordHash))
                {
                    lblMessage.CssClass = "d-block mb-3 text-danger";
                    lblMessage.Text = "Invalid email or password.";
                    return;
                }

                // Block unactivated users
                if (!user.IsEmailConfirmed)
                {
                    lblMessage.CssClass = "d-block mb-3 text-warning";
                    lblMessage.Text = "⚠️ Your account is not activated yet. Please check your email and click the activation link.";
                    return;
                }

                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["UserName"] = user.Name;
                Session["UserEmail"] = user.Email;
                Session["IsAdmin"] = user.IsAdmin;

                Response.Redirect("Default.aspx");
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(hashedPassword);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}