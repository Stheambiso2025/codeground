<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="MyCode.Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Choose Your Course</h2>
        <p class="text-center text-muted mb-5">Free forever. Learn at your own pace.</p>

        <div class="row g-4 justify-content-center">
            <asp:Repeater ID="rptCourses" runat="server">
                <ItemTemplate>
                    <div class="col-md-5">
                        <div class="card h-100 shadow-sm border-0">
                            <div class="card-body">
                                <div class="display-4 mb-2"><%# Eval("Icon") %></div>
                                <h4 class="card-title"><%# Eval("Title") %></h4>
                                <p class="card-text text-muted"><%# Eval("Description") %></p>
                                <a href='CourseDetail.aspx?slug=<%# Eval("Slug") %>' class="btn btn-primary">
                                    View Lessons →
                                </a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>