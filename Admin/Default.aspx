<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyCode.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">🛠️ Admin Dashboard</h2>
        <p class="text-muted mb-5">Manage lessons, users, and content.</p>

        <div class="row g-4 mb-5">
            <div class="col-md-3">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-primary"><asp:Label ID="lblTotalLessons" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Lessons</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-success"><asp:Label ID="lblTotalUsers" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Users</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-warning"><asp:Label ID="lblTotalComments" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Comments</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-0 text-center">
                    <div class="card-body">
                        <h1 class="display-4 text-danger"><asp:Label ID="lblTotalLikes" runat="server" Text="0" /></h1>
                        <p class="text-muted mb-0">Likes</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-4">
                <a href="Lessons.aspx" class="btn btn-primary w-100 py-3">📚 Manage Lessons</a>
            </div>
            <div class="col-md-4">
                <a href="Users.aspx" class="btn btn-secondary w-100 py-3">👥 Manage Users</a>
            </div>
            <div class="col-md-4">
                <a href="Comments.aspx" class="btn btn-warning w-100 py-3">💬 Manage Comments</a>
            </div>
        </div>
    </div>
</asp:Content>