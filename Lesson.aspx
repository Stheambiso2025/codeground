<%@ Page Title="Lesson" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lesson.aspx.cs" Inherits="MyCode.LessonPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-9">
                <asp:HyperLink ID="lnkBack" runat="server" CssClass="text-decoration-none">← Back to course</asp:HyperLink>
                
                <h1 class="mt-3 mb-2"><asp:Label ID="lblTitle" runat="server" /></h1>
                <p class="text-muted mb-4">
                    Lesson <asp:Label ID="lblOrder" runat="server" /> of <asp:Label ID="lblTotal" runat="server" />
                </p>

                <div class="lesson-content mb-4">
                    <asp:Literal ID="litContent" runat="server" />
                </div>

                <h5 class="mt-5 mb-3">💻 Code Example</h5>
                <div class="code-block position-relative mb-4">
                    <button type="button" class="btn btn-sm btn-light copy-btn" onclick="copyCode(this)">📋 Copy</button>
                    <pre><code id="codeBlock" runat="server"><asp:Literal ID="litCode" runat="server" /></code></pre>
                </div>

                <!-- Action Bar: Like + Complete -->
                <div class="d-flex justify-content-between align-items-center border-top border-bottom py-3 my-4">
                    <div>
                        <asp:LinkButton ID="btnLike" runat="server" CssClass="btn btn-outline-danger" OnClick="btnLike_Click">
                            ❤️ <asp:Label ID="lblLikeCount" runat="server" Text="0" /> Likes
                        </asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton ID="btnComplete" runat="server" CssClass="btn btn-outline-success" OnClick="btnComplete_Click">
                            ✅ Mark as Complete
                        </asp:LinkButton>
                    </div>
                </div>

               <!-- Quiz Button -->
<asp:Panel ID="pnlQuizButton" runat="server" Visible="false" CssClass="text-center my-5">
    <div class="card shadow-sm border-0 bg-light">
        <div class="card-body p-4">
            <h5 class="mb-3">📝 Test your understanding</h5>
            <p class="text-muted mb-3">This quiz is optional — take it anytime.</p>
            <asp:HyperLink ID="lnkTakeQuiz" runat="server" CssClass="btn btn-warning btn-lg">
                Take Quiz →
            </asp:HyperLink>
        </div>
    </div>
</asp:Panel>

<!-- Prev / Next -->
<div class="d-flex justify-content-between mt-4 mb-5">
    <asp:HyperLink ID="lnkPrev" runat="server" CssClass="btn btn-outline-secondary">← Previous</asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server" CssClass="btn btn-primary">Next →</asp:HyperLink>
</div>
                <!-- Comments Section -->
                <hr class="my-5" />
                <h4 class="mb-4">💬 Comments (<asp:Label ID="lblCommentCount" runat="server" Text="0" />)</h4>

                <asp:Panel ID="pnlCommentBox" runat="server" CssClass="mb-4">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control mb-2" 
                                 TextMode="MultiLine" Rows="3" placeholder="Write a comment..." />
                    <asp:Button ID="btnPostComment" runat="server" Text="Post Comment" 
                                CssClass="btn btn-primary btn-sm" OnClick="btnPostComment_Click" />
                </asp:Panel>

                <asp:Panel ID="pnlLoginPrompt" runat="server" CssClass="alert alert-info mb-4">
                    <a href="Login.aspx">Login</a> or <a href="Register.aspx">Register</a> to post a comment.
                </asp:Panel>

                <asp:Label ID="lblCommentMsg" runat="server" CssClass="d-block mb-3" />

                <asp:Repeater ID="rptComments" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3 shadow-sm border-0">
                            <div class="card-body">
                                <div class="d-flex justify-content-between mb-2">
                                    <strong>👤 <%# Eval("User.Name") %></strong>
                                    <small class="text-muted"><%# Eval("CreatedAt", "{0:MMM d, yyyy h:mm tt}") %></small>
                                </div>
                                <p class="mb-0"><%# System.Web.HttpUtility.HtmlEncode(Eval("Body").ToString()).Replace("\n", "<br />") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Label ID="lblNoComments" runat="server" CssClass="text-muted fst-italic" Text="No comments yet. Be the first!" Visible="false" />

            </div>
        </div>
    </div>

    <link href="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism-tomorrow.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/prism.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-python.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-java.min.js"></script>

    <script>
        function copyCode(btn) {
            var code = btn.parentElement.querySelector('code').innerText;
            navigator.clipboard.writeText(code);
            btn.innerText = "✅ Copied!";
            setTimeout(function () { btn.innerText = "📋 Copy"; }, 1500);
        }
    </script>
</asp:Content>