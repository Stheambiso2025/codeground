using System;
using System.Linq;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode.Admin
{
    public partial class Comments : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComments();
            }
        }

        private void LoadComments()
        {
            using (var db = new AppDbContext())
            {
                var comments = db.Comments
                                 .OrderByDescending(c => c.CreatedAt)
                                 .Select(c => new
                                 {
                                     c.Id,
                                     UserName = c.User.Name,
                                     LessonTitle = c.Lesson.Title,
                                     c.Body,
                                     c.CreatedAt
                                 })
                                 .ToList();

                gvComments.DataSource = comments;
                gvComments.DataBind();
            }
        }

        protected void gvComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvComments.DataKeys[e.RowIndex].Value;

            using (var db = new AppDbContext())
            {
                var comment = db.Comments.FirstOrDefault(c => c.Id == id);
                if (comment != null)
                {
                    db.Comments.Remove(comment);
                    db.SaveChanges();
                }
            }

            Response.Redirect("Comments.aspx");
        }
    }
}