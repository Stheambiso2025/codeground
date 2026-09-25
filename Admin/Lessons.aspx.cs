using System;
using System.Linq;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode.Admin
{
    public partial class Lessons : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLessons();

                if (Request.QueryString["msg"] == "saved")
                {
                    lblMsg.Text = "✅ Lesson saved successfully!";
                }
                else if (Request.QueryString["msg"] == "deleted")
                {
                    lblMsg.Text = "🗑️ Lesson deleted.";
                }
            }
        }

        private void LoadLessons()
        {
            using (var db = new AppDbContext())
            {
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

        protected void gvLessons_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvLessons.DataKeys[e.RowIndex].Value;

            using (var db = new AppDbContext())
            {
                var lesson = db.Lessons.FirstOrDefault(l => l.Id == id);
                if (lesson != null)
                {
                    db.Lessons.Remove(lesson);
                    db.SaveChanges();
                }
            }

            Response.Redirect("Lessons.aspx?msg=deleted");
        }
    }
}