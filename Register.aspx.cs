using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using MyCode.Models;

namespace MyCode
{
    public partial class Register : System.Web.UI.Page
    {
        
        // ==== Gmail SMTP Settings ====
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SmtpLogin = "Sthembisovusmuzi@gmail.com";
        private const string SmtpKey = "gprhdkxeplgujeub";
        private const string FromEmail = "Sthembisovusmuzi@gmail.com";
        private const string FromName = "CodeGround";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;

            // Validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.CssClass = "d-block mb-3 text-danger";
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (password.Length < 6)
            {
                lblMessage.CssClass = "d-block mb-3 text-danger";
                lblMessage.Text = "Password must be at least 6 characters long.";
                return;
            }

            if (password != txtConfirmPassword.Text)
            {
                lblMessage.CssClass = "d-block mb-3 text-danger";
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            string activationCode = Guid.NewGuid().ToString();
            int newUserId = 0;

            using (var db = new AppDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    lblMessage.CssClass = "d-block mb-3 text-danger";
                    lblMessage.Text = "This email is already registered. Try logging in.";
                    return;
                }

                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = HashPassword(password),
                    IsEmailConfirmed = false,
                    ActivationCode = activationCode
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                newUserId = newUser.Id;
            }

            // Send activation email
            try
            {
                SendActivationEmail(email, name, activationCode);

                lblMessage.CssClass = "d-block mb-3 text-success";
                lblMessage.Text = "✅ Registration successful! Check your email for the activation link before logging in.";
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "d-block mb-3 text-warning";
                lblMessage.Text = "Account created, but the activation email could not be sent: " + ex.Message;
            }
        }

        private void SendActivationEmail(string email, string name, string code)
        {
            string activationLink = Request.Url.GetLeftPart(UriPartial.Authority)
                                    + "/Activate.aspx?code=" + code;

            string body = $@"
                <div style='font-family: Arial, sans-serif; max-width:600px; margin:auto; padding:20px;'>
                    <h2 style='color:#1e3c72;'>Welcome to CodeGround, {name}!</h2>
                    <p>Thanks for registering. Click the button below to activate your account:</p>
                    <p style='text-align:center; margin:30px 0;'>
                        <a href='{activationLink}' 
                           style='background:#2a5298; color:#ffffff; padding:14px 28px; 
                                  text-decoration:none; border-radius:6px; font-weight:bold; display:inline-block;'>
                            ✅ Activate My Account
                        </a>
                    </p>
                    <p>Or copy this link into your browser:</p>
                    <p style='color:#555; word-break:break-all; font-size:13px;'>{activationLink}</p>
                    <hr />
                    <p style='color:#888; font-size:12px;'>
                        If you didn't register for CodeGround, please ignore this email.
                    </p>
                    <p style='color:#888; font-size:12px;'>&mdash; The CodeGround Team</p>
                </div>
            ";

            var mail = new MailMessage
            {
                From = new MailAddress(FromEmail, FromName),
                Subject = "Activate Your CodeGround Account",
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            using (var smtp = new SmtpClient(SmtpHost, SmtpPort))
            {
                smtp.Credentials = new NetworkCredential(SmtpLogin, SmtpKey);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}