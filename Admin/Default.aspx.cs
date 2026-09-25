using System;
using System.Linq;
using MyCode.Models;

namespace MyCode.Admin
{
    public partial class Default : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new AppDbContext())
                {
                    lblTotalLessons.Text = db.Lessons.Count().ToString();
                    lblTotalUsers.Text = db.Users.Count().ToString();
                    lblTotalComments.Text = db.Comments.Count().ToString();
                    lblTotalLikes.Text = db.Likes.Count().ToString();
                }
            }
        }
    }
}