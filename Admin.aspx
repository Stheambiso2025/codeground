<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MyCode.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">

        <asp:Panel ID="pnlDenied" runat="server" Visible="false">
            <div class="alert alert-danger">
                ❌ Access denied. You are not an admin.
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlAdmin" runat="server" Visible="false">

            <h2 class="mb-4">⚙️ Admin Dashboard</h2>
            <p class="text-muted mb-4">Welcome back, admin. Here's your site overview.</p>

            <!-- Stats Cards -->
            <div class="row g-4 mb-5">
                <div class="col-md-3">
                    <div class="card shadow-sm border-0 text-center">
                        <div class="card-body">
                            <h1 class="display-4 text-primary"><asp:Label ID="lblLessons" runat="server" /></h1>
                            <p class="text-muted mb-0">Lessons</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm border-0 text-center">
                        <div class="card-body">
                            <h1 class="display-4 text-success"><asp:Label ID="lblUsers" runat="server" /></h1>
                            <p class="text-muted mb-0">Users</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm border-0 text-center">
                        <div class="card-body">
                            <h1 class="display-4 text-warning"><asp:Label ID="lblComments" runat="server" /></h1>
                            <p class="text-muted mb-0">Comments</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm border-0 text-center">
                        <div class="card-body">
                            <h1 class="display-4 text-danger"><asp:Label ID="lblLikes" runat="server" /></h1>
                            <p class="text-muted mb-0">Likes</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Users Table -->
            <h4 class="mb-3">👥 All Users</h4>
            <div class="card shadow-sm border-0 mb-5">
                <div class="card-body p-0">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false"
                                  CssClass="table table-striped mb-0">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:CheckBoxField DataField="IsAdmin" HeaderText="Admin" ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- Lessons Table -->
            <h4 class="mb-3">📚 All Lessons</h4>
            <div class="card shadow-sm border-0 mb-5">
                <div class="card-body p-0">
                    <asp:GridView ID="gvLessons" runat="server" AutoGenerateColumns="false"
                                  CssClass="table table-striped mb-0">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" />
                            <asp:BoundField DataField="CourseTitle" HeaderText="Course" />
                            <asp:BoundField DataField="OrderIndex" HeaderText="#" />
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                            <asp:BoundField DataField="Language" HeaderText="Language" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </asp:Panel>

    </div>
</asp:Content>