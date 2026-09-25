<%@ Page Title="Quiz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="MyCode.QuizPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">

                <asp:Panel ID="pnlQuiz" runat="server" Visible="false">
                    <h2 class="mb-2"><asp:Label ID="lblQuizTitle" runat="server" /></h2>
                    <p class="text-muted mb-4">
                        Answer all questions, then click <strong>Submit Quiz</strong>. 
                        You can retake this quiz anytime.
                    </p>

                    <asp:Repeater ID="rptQuestions" runat="server">
                        <ItemTemplate>
                            <div class="card shadow-sm border-0 mb-4">
                                <div class="card-body">
                                    <h5 class="mb-3">
                                        <%# Container.ItemIndex + 1 %>. <%# Eval("QuestionText") %>
                                    </h5>

                                    <div class="form-check mb-2">
                                        <input class="form-check-input" type="radio" 
                                               name="q_<%# Eval("Id") %>" 
                                               id="q<%# Eval("Id") %>_A" 
                                               value="A" />
                                        <label class="form-check-label" for="q<%# Eval("Id") %>_A">
                                            <strong>A.</strong> <%# Eval("OptionA") %>
                                        </label>
                                    </div>

                                    <div class="form-check mb-2">
                                        <input class="form-check-input" type="radio" 
                                               name="q_<%# Eval("Id") %>" 
                                               id="q<%# Eval("Id") %>_B" 
                                               value="B" />
                                        <label class="form-check-label" for="q<%# Eval("Id") %>_B">
                                            <strong>B.</strong> <%# Eval("OptionB") %>
                                        </label>
                                    </div>

                                    <div class="form-check mb-2">
                                        <input class="form-check-input" type="radio" 
                                               name="q_<%# Eval("Id") %>" 
                                               id="q<%# Eval("Id") %>_C" 
                                               value="C" />
                                        <label class="form-check-label" for="q<%# Eval("Id") %>_C">
                                            <strong>C.</strong> <%# Eval("OptionC") %>
                                        </label>
                                    </div>

                                    <div class="form-check mb-2">
                                        <input class="form-check-input" type="radio" 
                                               name="q_<%# Eval("Id") %>" 
                                               id="q<%# Eval("Id") %>_D" 
                                               value="D" />
                                        <label class="form-check-label" for="q<%# Eval("Id") %>_D">
                                            <strong>D.</strong> <%# Eval("OptionD") %>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:Label ID="lblQuizError" runat="server" CssClass="d-block mb-3 text-danger" />

                    <asp:Button ID="btnSubmitQuiz" runat="server" Text="Submit Quiz" 
                                CssClass="btn btn-primary btn-lg w-100 mb-4" 
                                OnClick="btnSubmitQuiz_Click" />
                </asp:Panel>

                <!-- Results panel -->
                <asp:Panel ID="pnlResults" runat="server" Visible="false">
                    <div class="card shadow border-0 text-center">
                        <div class="card-body p-5">
                            <h1 class="display-1 mb-3"><asp:Label ID="lblScoreIcon" runat="server" /></h1>
                            <h2 class="mb-3"><asp:Label ID="lblResultTitle" runat="server" /></h2>
                            <p class="fs-3 mb-4">
                                You scored 
                                <strong class="text-primary"><asp:Label ID="lblScore" runat="server" /></strong>
                            </p>

                            <asp:Panel ID="pnlReview" runat="server" CssClass="text-start mb-4">
                                <h5 class="mb-3">📋 Review</h5>
                                <asp:Repeater ID="rptReview" runat="server">
                                    <ItemTemplate>
                                        <div class='alert <%# (bool)Eval("IsCorrect") ? "alert-success" : "alert-danger" %>'>
                                            <strong><%# Container.ItemIndex + 1 %>. <%# Eval("QuestionText") %></strong><br />
                                            <small>Your answer: <strong><%# Eval("UserAnswer") %></strong></small><br />
                                            <%# (bool)Eval("IsCorrect") ? "" : "<small>Correct answer: <strong>" + Eval("CorrectAnswer") + "</strong></small>" %>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>

                            <div class="d-flex gap-2 justify-content-center">
                                <asp:HyperLink ID="lnkBack" runat="server" CssClass="btn btn-outline-secondary">← Back to Lesson</asp:HyperLink>
                                <asp:HyperLink ID="lnkRetake" runat="server" CssClass="btn btn-primary">🔄 Retake Quiz</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlNotFound" runat="server" Visible="false">
                    <div class="alert alert-warning">
                        ❌ Quiz not found.
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>