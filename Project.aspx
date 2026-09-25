<%@ Page Title="Final Project" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="MyCode.ProjectPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-9">

                <asp:Panel ID="pnlNotFound" runat="server" Visible="false">
                    <div class="alert alert-warning">❌ Project not found.</div>
                </asp:Panel>

                <asp:Panel ID="pnlProject" runat="server" Visible="false">

                    <asp:HyperLink ID="lnkBack" runat="server" CssClass="text-decoration-none">
                        ← Back to course
                    </asp:HyperLink>

                    <h1 class="mt-3 mb-2">🏆 Final Project: <asp:Label ID="lblProjectTitle" runat="server" /></h1>
                    <p class="text-muted mb-5">
                        This is the practical test for this course. Build the program, test it, then paste your code below.
                    </p>

                    <!-- Project Prompt -->
                    <div class="card shadow-sm border-0 mb-5">
                        <div class="card-body p-4">
                            <h5 class="mb-3">🎯 Your Task</h5>
                            <div class="project-prompt">
                                <asp:Literal ID="litPrompt" runat="server" />
                            </div>
                        </div>
                    </div>

                    <!-- Submission Form -->
                    <h5 class="mb-3">💻 Submit Your Code</h5>

                    <asp:Panel ID="pnlNotLoggedIn" runat="server" Visible="false" CssClass="alert alert-info mb-4">
                        <a href="Login.aspx">Login</a> or <a href="Register.aspx">Register</a> to submit your project.
                    </asp:Panel>

                    <asp:Panel ID="pnlSubmit" runat="server" Visible="false">
                        <asp:TextBox ID="txtCode" runat="server" 
                                     CssClass="form-control mb-3" 
                                     TextMode="MultiLine" 
                                     Rows="18"
                                     style="font-family: Consolas, Monaco, monospace; font-size: 0.95rem;"
                                     placeholder="// Paste your code here..." />

                        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

                        <asp:Button ID="btnSubmit" runat="server" Text="✅ Submit Project" 
                                    CssClass="btn btn-success btn-lg mb-5" 
                                    OnClick="btnSubmit_Click" />
                    </asp:Panel>

                    <!-- Past Submissions -->
                    <asp:Panel ID="pnlPast" runat="server" Visible="false">
                        <h5 class="mb-3">📋 Your Past Submissions</h5>
                        <asp:Repeater ID="rptSubmissions" runat="server">
                            <ItemTemplate>
                                <div class="card shadow-sm border-0 mb-3">
                                    <div class="card-header bg-light d-flex justify-content-between">
                                        <small class="text-muted">
                                            Submitted: <strong><%# Eval("SubmittedAt", "{0:MMM d, yyyy h:mm tt}") %></strong>
                                        </small>
                                    </div>
                                    <div class="card-body p-0">
                                        <pre style="margin: 0; max-height: 300px; overflow: auto; padding: 15px; background: #f8f9fa;"><code><%# System.Web.HttpUtility.HtmlEncode(Eval("Code").ToString()) %></code></pre>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>