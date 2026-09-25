using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode
{
    public partial class Activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["code"];

            if (string.IsNullOrEmpty(code))
            {
                lblMessage.CssClass = "d-block mb-4 fs-5 text-danger";
                lblMessage.Text = "❌ Invalid activation link.";
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.ActivationCode == code);

                if (user == null)
                {
                    lblMessage.CssClass = "d-block mb-4 fs-5 text-danger";
                    lblMessage.Text = "❌ Invalid or already-used activation code.";
                    return;
                }

                user.IsEmailConfirmed = true;
                user.ActivationCode = null; // Clear so it can't be reused
                db.SaveChanges();

                lblMessage.CssClass = "d-block mb-4 fs-5 text-success";
                lblMessage.Text = "✅ Your account is now activated! You can log in.";
            }
        }
    }
}