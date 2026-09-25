using System;
using System.Linq;
using MyCode.Models;

namespace MyCode
{
    public partial class CourseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string slug = Request.QueryString["slug"];
                if (string.IsNullOrEmpty(slug))
                {
                    Response.Redirect("Courses.aspx");
                    return;
                }

                using (var db = new AppDbContext())
                {
                    var course = db.Courses.FirstOrDefault(c => c.Slug == slug);
                    if (course == null)
                    {
                        Response.Redirect("Courses.aspx");
                        return;
                    }

                    lblIcon.Text = course.Icon;
                    lblTitle.Text = course.Title;
                    lblDescription.Text = course.Description;

                    var lessons = db.Lessons
                                    .Where(l => l.CourseId == course.Id)
                                    .OrderBy(l => l.OrderIndex)
                                    .ToList();

                    rptLessons.DataSource = lessons;
                    rptLessons.DataBind();
                    lnkFinalProject.NavigateUrl = "Project.aspx?course=" + course.Slug;
                }
            }
        }
    }
}