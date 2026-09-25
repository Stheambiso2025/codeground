using System;
using System.Linq;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode.Admin
{
    public partial class Users : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            using (var db = new AppDbContext())
            {
                var users = db.Users.OrderBy(u => u.Id).ToList();
                gvUsers.DataSource = users;
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvUsers.DataKeys[e.RowIndex].Value;

            // Prevent admin from deleting themselves
            if (CurrentUser != null && CurrentUser.Id == id)
            {
                Response.Redirect("Users.aspx");
                return;
            }

            using (var db = new AppDbContext())
            {
                // Delete user's comments, likes, progress first
                var comments = db.Comments.Where(c => c.UserId == id).ToList();
                var likes = db.Likes.Where(l => l.UserId == id).ToList();
                var progress = db.UserProgresses.Where(p => p.UserId == id).ToList();

                db.Comments.RemoveRange(comments);
                db.Likes.RemoveRange(likes);
                db.UserProgresses.RemoveRange(progress);

                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null) db.Users.Remove(user);

                db.SaveChanges();
            }

            Response.Redirect("Users.aspx");
        }
    }
}