using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCode.Models;

namespace MyCode
{
    public partial class ProjectPage : System.Web.UI.Page
    {
        private int CurrentCourseId
        {
            get { return ViewState["CourseId"] != null ? (int)ViewState["CourseId"] : 0; }
            set { ViewState["CourseId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string slug = Request.QueryString["course"];
                if (string.IsNullOrEmpty(slug))
                {
                    pnlNotFound.Visible = true;
                    return;
                }

                using (var db = new AppDbContext())
                {
                    var course = db.Courses.FirstOrDefault(c => c.Slug == slug);
                    if (course == null)
                    {
                        pnlNotFound.Visible = true;
                        return;
                    }

                    CurrentCourseId = course.Id;
                    pnlProject.Visible = true;

                    // Set the project prompt based on the course
                    if (slug == "python")
                    {
                        lblProjectTitle.Text = "Student Grade Calculator (Python)";
                        litPrompt.Text = GetPythonProjectPrompt();
                    }
                    else if (slug == "java")
                    {
                        lblProjectTitle.Text = "Student Grade Calculator (Java)";
                        litPrompt.Text = GetJavaProjectPrompt();
                    }
                    else
                    {
                        lblProjectTitle.Text = "Final Project";
                        litPrompt.Text = "<p>No project defined for this course yet.</p>";
                    }

                    lnkBack.NavigateUrl = "CourseDetail.aspx?slug=" + slug;

                    // Check login
                    if (!Request.IsAuthenticated)
                    {
                        pnlNotLoggedIn.Visible = true;
                        pnlSubmit.Visible = false;
                    }
                    else
                    {
                        pnlNotLoggedIn.Visible = false;
                        pnlSubmit.Visible = true;
                        LoadSubmissions(course.Id);
                    }
                }
            }
        }

        private void LoadSubmissions(int courseId)
        {
            string email = Session["UserEmail"] as string;

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null) return;

                var subs = db.ProjectSubmissions
                             .Where(s => s.UserId == user.Id && s.CourseId == courseId)
                             .OrderByDescending(s => s.SubmittedAt)
                             .ToList();

                if (subs.Count > 0)
                {
                    rptSubmissions.DataSource = subs;
                    rptSubmissions.DataBind();
                    pnlPast.Visible = true;
                }
                else
                {
                    pnlPast.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated) return;

            string code = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                lblMsg.CssClass = "d-block mb-3 text-danger";
                lblMsg.Text = "Please paste your code before submitting.";
                return;
            }

            using (var db = new AppDbContext())
            {
                string email = Session["UserEmail"] as string;
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null) return;

                db.ProjectSubmissions.Add(new ProjectSubmission
                {
                    UserId = user.Id,
                    CourseId = CurrentCourseId,
                    Code = code,
                    SubmittedAt = DateTime.Now
                });
                db.SaveChanges();
            }

            lblMsg.CssClass = "d-block mb-3 text-success";
            lblMsg.Text = "🎉 Project submitted! Your submission is saved below.";

            txtCode.Text = "";
            LoadSubmissions(CurrentCourseId);
        }

        private string GetPythonProjectPrompt()
        {
            return @"
                <p>Build a program called <strong>Student Grade Calculator</strong> in Python. It must:</p>
                <ol>
                    <li>Ask for the student's <strong>name</strong></li>
                    <li>Ask for <strong>three marks</strong> (as integers)</li>
                    <li>Calculate the <strong>average</strong> using a function called <code>calculate_average()</code></li>
                    <li>Determine the result using a function called <code>get_result()</code>:
                        <ul>
                            <li><strong>75+</strong> → Distinction</li>
                            <li><strong>50-74</strong> → Pass</li>
                            <li><strong>0-49</strong> → Fail</li>
                        </ul>
                    </li>
                    <li>Display the results in a nice format</li>
                </ol>
                <hr />
                <h6>📋 Example Output</h6>
                <pre style='background:#f8f9fa; padding:15px; border-radius:6px;'>==========================
     STUDENT RESULTS
==========================

Name: Thabo

Mark 1: 70
Mark 2: 65
Mark 3: 80

Average: 71.67
Result: PASS

==========================</pre>
                <p class='mt-3'><strong>Requirements:</strong></p>
                <ul>
                    <li>Use at least <strong>2 functions</strong></li>
                    <li>Use <code>input()</code> for user input</li>
                    <li>Use <code>int()</code> to convert the marks</li>
                    <li>Use <code>if</code> / <code>elif</code> / <code>else</code> for the result</li>
                </ul>
            ";
        }

        private string GetJavaProjectPrompt()
        {
            return @"
                <p>Build a program called <strong>Student Grade Calculator</strong> in Java. It must:</p>
                <ol>
                    <li>Ask for the student's <strong>name</strong> using <code>Scanner</code></li>
                    <li>Ask for <strong>three marks</strong> (as integers)</li>
                    <li>Calculate the <strong>average</strong> using a method called <code>calculateAverage()</code></li>
                    <li>Determine the result using a method called <code>getResult()</code>:
                        <ul>
                            <li><strong>75+</strong> → Distinction</li>
                            <li><strong>50-74</strong> → Pass</li>
                            <li><strong>0-49</strong> → Fail</li>
                        </ul>
                    </li>
                    <li>Display the results in a nice format</li>
                </ol>
                <hr />
                <h6>📋 Example Output</h6>
                <pre style='background:#f8f9fa; padding:15px; border-radius:6px;'>==========================
     STUDENT RESULTS
==========================

Name: Thabo

Mark 1: 70
Mark 2: 65
Mark 3: 80

Average: 71.67
Result: PASS

==========================</pre>
                <p class='mt-3'><strong>Requirements:</strong></p>
                <ul>
                    <li>Use at least <strong>2 methods</strong></li>
                    <li>Use <code>Scanner</code> for user input</li>
                    <li>Use <code>int</code> for the marks</li>
                    <li>Use <code>if</code> / <code>else if</code> / <code>else</code> for the result</li>
                </ul>
            ";
        }
    }
}