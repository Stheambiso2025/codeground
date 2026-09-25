using System;
using System.Collections.Generic;
using System.Linq;
using MyCode.Models;

namespace MyCode
{
    public partial class QuizPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuiz();
            }
        }

        private void LoadQuiz()
        {
            int quizId;
            if (!int.TryParse(Request.QueryString["id"], out quizId))
            {
                pnlNotFound.Visible = true;
                return;
            }

            using (var db = new AppDbContext())
            {
                var quiz = db.Quizzes.FirstOrDefault(q => q.Id == quizId);
                if (quiz == null)
                {
                    pnlNotFound.Visible = true;
                    return;
                }

                lblQuizTitle.Text = quiz.Title;

                var questions = db.Questions
                                  .Where(q => q.QuizId == quizId)
                                  .OrderBy(q => q.OrderIndex)
                                  .ToList();

                rptQuestions.DataSource = questions;
                rptQuestions.DataBind();

                ViewState["QuizId"] = quizId;

                // Back / retake links
                if (quiz.LessonId.HasValue)
                {
                    lnkBack.NavigateUrl = "Lesson.aspx?id=" + quiz.LessonId.Value;
                }
                else if (quiz.CourseId.HasValue)
                {
                    var course = db.Courses.FirstOrDefault(c => c.Id == quiz.CourseId.Value);
                    lnkBack.NavigateUrl = "CourseDetail.aspx?slug=" + (course != null ? course.Slug : "");
                }
                else
                {
                    lnkBack.NavigateUrl = "Courses.aspx";
                }

                lnkRetake.NavigateUrl = "Quiz.aspx?id=" + quizId;

                pnlQuiz.Visible = true;
            }
        }

        protected void btnSubmitQuiz_Click(object sender, EventArgs e)
        {
            int quizId = ViewState["QuizId"] != null ? (int)ViewState["QuizId"] : 0;
            if (quizId == 0) return;

            using (var db = new AppDbContext())
            {
                var quiz = db.Quizzes.FirstOrDefault(q => q.Id == quizId);
                if (quiz == null) return;

                var questions = db.Questions
                                  .Where(q => q.QuizId == quizId)
                                  .OrderBy(q => q.OrderIndex)
                                  .ToList();

                int score = 0;
                var review = new List<ReviewItem>();

                foreach (var q in questions)
                {
                    string userAnswer = Request.Form["q_" + q.Id];
                    bool isCorrect = userAnswer == q.CorrectOption;

                    if (isCorrect) score++;

                    review.Add(new ReviewItem
                    {
                        QuestionText = q.QuestionText,
                        UserAnswer = string.IsNullOrEmpty(userAnswer) ? "(not answered)" : userAnswer,
                        CorrectAnswer = q.CorrectOption,
                        IsCorrect = isCorrect
                    });
                }

                pnlQuiz.Visible = false;
                pnlResults.Visible = true;

                int total = questions.Count;
                double percent = total > 0 ? (score * 100.0 / total) : 0;

                lblScore.Text = score + " / " + total + " (" + Math.Round(percent) + "%)";

                if (percent >= 70)
                {
                    lblScoreIcon.Text = "🎉";
                    lblResultTitle.Text = "Great job!";
                }
                else if (percent >= 50)
                {
                    lblScoreIcon.Text = "👍";
                    lblResultTitle.Text = "Not bad!";
                }
                else
                {
                    lblScoreIcon.Text = "📚";
                    lblResultTitle.Text = "Keep practicing!";
                }

                rptReview.DataSource = review;
                rptReview.DataBind();

                if (Request.IsAuthenticated)
                {
                    string email = Session["UserEmail"] as string;
                    var user = db.Users.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        db.QuizAttempts.Add(new QuizAttempt
                        {
                            UserId = user.Id,
                            QuizId = quizId,
                            Score = score,
                            TotalQuestions = total,
                            AttemptedAt = DateTime.Now
                        });
                        db.SaveChanges();
                    }
                }
            }
        }

        public class ReviewItem
        {
            public string QuestionText { get; set; }
            public string UserAnswer { get; set; }
            public string CorrectAnswer { get; set; }
            public bool IsCorrect { get; set; }
        }
    }
}