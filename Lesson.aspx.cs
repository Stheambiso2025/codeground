using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode
{
    public partial class LessonPage : System.Web.UI.Page
    {
        private int CurrentLessonId
        {
            get { return ViewState["LessonId"] != null ? (int)ViewState["LessonId"] : 0; }
            set { ViewState["LessonId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    Response.Redirect("Courses.aspx");
                    return;
                }

                CurrentLessonId = id;
                LoadLesson(id);
                LoadComments(id);
                LoadLikeCount(id);
                SetupActionButtons(id);
            }
        }

        private void LoadLesson(int id)
        {
            using (var db = new AppDbContext())
            {
                var lesson = db.Lessons.FirstOrDefault(l => l.Id == id);
                if (lesson == null)
                {
                    Response.Redirect("Courses.aspx");
                    return;
                }

                var course = db.Courses.FirstOrDefault(c => c.Id == lesson.CourseId);

                lblTitle.Text = lesson.Title;
                lblOrder.Text = lesson.OrderIndex.ToString();
                litContent.Text = lesson.Content;
                litCode.Text = HttpUtility.HtmlEncode(lesson.CodeExample);

                codeBlock.Attributes["class"] = "language-" + lesson.Language;
                lnkBack.NavigateUrl = "CourseDetail.aspx?slug=" + course.Slug;

                var total = db.Lessons.Count(l => l.CourseId == lesson.CourseId);
                lblTotal.Text = total.ToString();

                var prev = db.Lessons
                             .Where(l => l.CourseId == lesson.CourseId && l.OrderIndex < lesson.OrderIndex)
                             .OrderByDescending(l => l.OrderIndex)
                             .FirstOrDefault();

                var next = db.Lessons
                             .Where(l => l.CourseId == lesson.CourseId && l.OrderIndex > lesson.OrderIndex)
                             .OrderBy(l => l.OrderIndex)
                             .FirstOrDefault();
                // Check if this lesson has a quiz
                var quiz = db.Quizzes.FirstOrDefault(q => q.LessonId == lesson.Id);
                if (quiz != null)
                {
                    pnlQuizButton.Visible = true;
                    lnkTakeQuiz.NavigateUrl = "Quiz.aspx?id=" + quiz.Id;
                }
                else
                {
                    pnlQuizButton.Visible = false;
                }
                
                if (prev != null)
                    lnkPrev.NavigateUrl = "Lesson.aspx?id=" + prev.Id;
                else
                    lnkPrev.Visible = false;

                if (next != null)
                    lnkNext.NavigateUrl = "Lesson.aspx?id=" + next.Id;
                else
                    lnkNext.Visible = false;
            }
        }

        private void LoadComments(int lessonId)
        {
            using (var db = new AppDbContext())
            {
                var comments = db.Comments
                                 .Include("User")
                                 .Where(c => c.LessonId == lessonId)
                                 .OrderByDescending(c => c.CreatedAt)
                                 .ToList();

                rptComments.DataSource = comments;
                rptComments.DataBind();

                lblCommentCount.Text = comments.Count.ToString();
                lblNoComments.Visible = comments.Count == 0;
            }
        }

        private void LoadLikeCount(int lessonId)
        {
            using (var db = new AppDbContext())
            {
                int count = db.Likes.Count(l => l.LessonId == lessonId);
                lblLikeCount.Text = count.ToString();
            }
        }

        private void SetupActionButtons(int lessonId)
        {
            if (!Request.IsAuthenticated)
            {
                btnLike.Visible = false;
                btnComplete.Visible = false;
                pnlCommentBox.Visible = false;
                pnlLoginPrompt.Visible = true;
                return;
            }

            pnlCommentBox.Visible = true;
            pnlLoginPrompt.Visible = false;

            using (var db = new AppDbContext())
            {
                var user = GetCurrentUser(db);
                if (user == null) return;

                // Already liked?
                bool liked = db.Likes.Any(l => l.LessonId == lessonId && l.UserId == user.Id);
                if (liked)
                {
                    btnLike.CssClass = "btn btn-danger";
                    btnLike.Text = "❤️ <span id='likeCount'>" + db.Likes.Count(l => l.LessonId == lessonId) + "</span> Likes (Liked)";
                }

                // Already completed?
                bool completed = db.UserProgresses.Any(p => p.LessonId == lessonId && p.UserId == user.Id && p.IsCompleted);
                if (completed)
                {
                    btnComplete.CssClass = "btn btn-success";
                    btnComplete.Text = "✅ Completed";
                }
            }
        }

        private User GetCurrentUser(AppDbContext db)
        {
            string email = Session["UserEmail"] as string;
            if (string.IsNullOrEmpty(email)) return null;
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        // ========== LIKE ==========
        protected void btnLike_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) return;

            using (var db = new AppDbContext())
            {
                var user = GetCurrentUser(db);
                if (user == null) return;

                var existing = db.Likes.FirstOrDefault(l => l.LessonId == CurrentLessonId && l.UserId == user.Id);

                if (existing != null)
                {
                    // Unlike
                    db.Likes.Remove(existing);
                }
                else
                {
                    // Like
                    db.Likes.Add(new Like { LessonId = CurrentLessonId, UserId = user.Id });
                }

                db.SaveChanges();
            }

            Response.Redirect(Request.RawUrl);
        }

        // ========== COMPLETE ==========
        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) return;

            using (var db = new AppDbContext())
            {
                var user = GetCurrentUser(db);
                if (user == null) return;

                var progress = db.UserProgresses
                                 .FirstOrDefault(p => p.LessonId == CurrentLessonId && p.UserId == user.Id);

                if (progress == null)
                {
                    db.UserProgresses.Add(new UserProgress
                    {
                        LessonId = CurrentLessonId,
                        UserId = user.Id,
                        IsCompleted = true,
                        CompletedAt = DateTime.Now
                    });
                }
                else
                {
                    progress.IsCompleted = !progress.IsCompleted;
                    progress.CompletedAt = progress.IsCompleted ? DateTime.Now : (DateTime?)null;
                }

                db.SaveChanges();
            }

            Response.Redirect(Request.RawUrl);
        }

        // ========== COMMENT ==========
        protected void btnPostComment_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) return;

            string body = txtComment.Text.Trim();
            if (string.IsNullOrEmpty(body)) return;

            using (var db = new AppDbContext())
            {
                var user = GetCurrentUser(db);
                if (user == null) return;

                db.Comments.Add(new Comment
                {
                    LessonId = CurrentLessonId,
                    UserId = user.Id,
                    Body = body,
                    CreatedAt = DateTime.Now
                });

                db.SaveChanges();
            }

            txtComment.Text = "";
            Response.Redirect(Request.RawUrl);
        }
    }
}