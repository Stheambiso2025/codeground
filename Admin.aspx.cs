using System;
using System.Linq;
using MyCode.Models;

namespace MyCode
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            using (var db = new AppDbContext())
            {
                string email = Session["UserEmail"] as string;
                var user = db.Users.FirstOrDefault(u => u.Email == email);

                if (user == null || !user.IsAdmin)
                {
                    pnlDenied.Visible = true;
                    return;
                }

                pnlAdmin.Visible = true;

                // Stats
                lblLessons.Text = db.Lessons.Count().ToString();
                lblUsers.Text = db.Users.Count().ToString();
                lblComments.Text = db.Comments.Count().ToString();
                lblLikes.Text = db.Likes.Count().ToString();

                // Users table
                gvUsers.DataSource = db.Users.OrderBy(u => u.Id).ToList();
                gvUsers.DataBind();

                // Lessons table
                var lessons = db.Lessons
                                 .OrderBy(l => l.CourseId)
                                 .ThenBy(l => l.OrderIndex)
                                 .Select(l => new
                                 {
                                     l.Id,
                                     CourseTitle = l.Course.Title,
                                     l.OrderIndex,
                                     l.Title,
                                     l.Language
                                 })
                                 .ToList();

                gvLessons.DataSource = lessons;
                gvLessons.DataBind();
            }
        }
    }
}