using System;
using System.Linq;
using MyCode.Models;

namespace MyCode
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new AppDbContext())
                {
                    rptCourses.DataSource = db.Courses.OrderBy(c => c.OrderIndex).ToList();
                    rptCourses.DataBind();
                }
            }
        }
    }
}