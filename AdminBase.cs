using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyCode.Models;

namespace MyCode
{
    public class AdminBase : Page
    {
        protected User CurrentUser { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            using (var db = new AppDbContext())
            {
                string email = Session["UserEmail"] as string;
                CurrentUser = db.Users.FirstOrDefault(u => u.Email == email);

                if (CurrentUser == null || !CurrentUser.IsAdmin)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}