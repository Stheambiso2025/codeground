<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MyCode.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-2">👤 Welcome back, <asp:Label ID="lblName" runat="server" />!</h2>
        <p class="text-muted mb-5">Here's your learning progress.</p>

        <div class="row g-4 mb-5">
            <div class="col-md-4">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-primary"><asp:Label ID="lblCompleted" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Lessons Completed</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-danger"><asp:Label ID="lblLikes" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Lessons Liked</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-success"><asp:Label ID="lblComments" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Comments Posted</p>
                    </div>
                </div>
            </div>
        </div>

        <h4 class="mb-3">📚 Continue Learning</h4>
        <div class="list-group shadow-sm mb-5">
            <asp:Repeater ID="rptProgress" runat="server">
                <ItemTemplate>
                    <a href='Lesson.aspx?id=<%# Eval("LessonId") %>' 
                       class="list-group-item list-group-item-action d-flex justify-content-between">
                        <span>📖 <%# Eval("LessonTitle") %></span>
                        <span class="badge bg-success rounded-pill">✅ Done</span>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <asp:Label ID="lblNoProgress" runat="server" CssClass="text-muted fst-italic" 
                   Text="You haven't completed any lessons yet. Start learning!" Visible="false" />
    </div>
</asp:Content>