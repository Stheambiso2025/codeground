using System;
using System.Collections.Generic;
using System.Linq;
using MyCode.Models;

namespace MyCode
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                using (var db = new AppDbContext())
                {
                    string email = Session["UserEmail"] as string;
                    var user = db.Users.FirstOrDefault(u => u.Email == email);
                    if (user == null)
                    {
                        Response.Redirect("Login.aspx");
                        return;
                    }

                    lblName.Text = user.Name;

                    int completedCount = db.UserProgresses
                                           .Count(p => p.UserId == user.Id && p.IsCompleted);
                    lblCompleted.Text = completedCount.ToString();

                    lblLikes.Text = db.Likes.Count(l => l.UserId == user.Id).ToString();
                    lblComments.Text = db.Comments.Count(c => c.UserId == user.Id).ToString();

                    var progressList = db.UserProgresses
                                         .Where(p => p.UserId == user.Id && p.IsCompleted)
                                         .Join(db.Lessons,
                                               p => p.LessonId,
                                               l => l.Id,
                                               (p, l) => new { p.LessonId, LessonTitle = l.Title })
                                         .OrderBy(x => x.LessonTitle)
                                         .ToList();

                    rptProgress.DataSource = progressList;
                    rptProgress.DataBind();

                    lblNoProgress.Visible = progressList.Count == 0;
                }
            }
        }
    }
}