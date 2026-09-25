using System;
using System.Linq;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode.Admin
{
    public partial class LessonEdit : AdminBase
    {
        private int LessonId
        {
            get { return ViewState["LessonId"] != null ? (int)ViewState["LessonId"] : 0; }
            set { ViewState["LessonId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();

                // Edit mode?
                int id;
                if (int.TryParse(Request.QueryString["id"], out id) && id > 0)
                {
                    LessonId = id;
                    lblPageTitle.Text = "✏️ Edit Lesson";
                    LoadLesson(id);
                }
                else
                {
                    lblPageTitle.Text = "➕ Add New Lesson";
                    // Pre-fill order index with next available
                    using (var db = new AppDbContext())
                    {
                        int nextOrder = db.Lessons.Any() ? db.Lessons.Max(l => l.OrderIndex) + 1 : 1;
                        txtOrder.Text = nextOrder.ToString();
                    }
                }
            }
        }

        private void LoadCourses()
        {
            using (var db = new AppDbContext())
            {
                ddlCourse.DataSource = db.Courses.OrderBy(c => c.OrderIndex).ToList();
                ddlCourse.DataTextField = "Title";
                ddlCourse.DataValueField = "Id";
                ddlCourse.DataBind();
            }
        }

        private void LoadLesson(int id)
        {
            using (var db = new AppDbContext())
            {
                var lesson = db.Lessons.FirstOrDefault(l => l.Id == id);
                if (lesson == null)
                {
                    Response.Redirect("Lessons.aspx");
                    return;
                }

                ddlCourse.SelectedValue = lesson.CourseId.ToString();
                txtOrder.Text = lesson.OrderIndex.ToString();
                txtTitle.Text = lesson.Title;
                ddlLanguage.SelectedValue = lesson.Language;
                txtContent.Text = lesson.Content;
                txtCode.Text = lesson.CodeExample;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                lblMsg.Text = "Title is required.";
                return;
            }

            int order;
            if (!int.TryParse(txtOrder.Text, out order))
            {
                lblMsg.Text = "Order must be a number.";
                return;
            }

            using (var db = new AppDbContext())
            {
                Lesson lesson;

                if (LessonId > 0)
                {
                    // Update
                    lesson = db.Lessons.FirstOrDefault(l => l.Id == LessonId);
                    if (lesson == null)
                    {
                        Response.Redirect("Lessons.aspx");
                        return;
                    }
                }
                else
                {
                    // Create new
                    lesson = new Lesson();
                    db.Lessons.Add(lesson);
                }

                lesson.CourseId = int.Parse(ddlCourse.SelectedValue);
                lesson.OrderIndex = order;
                lesson.Title = txtTitle.Text.Trim();
                lesson.Language = ddlLanguage.SelectedValue;
                lesson.Content = txtContent.Text;
                lesson.CodeExample = txtCode.Text;

                db.SaveChanges();
            }

            Response.Redirect("Lessons.aspx?msg=saved");
        }
    }
}