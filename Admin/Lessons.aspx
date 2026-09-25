<%@ Page Title="Manage Lessons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lessons.aspx.cs" Inherits="MyCode.Admin.Lessons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>📚 Manage Lessons</h2>
            <a href="LessonEdit.aspx" class="btn btn-success">+ Add New Lesson</a>
        </div>

        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3 text-success" />

        <asp:GridView ID="gvLessons" runat="server" AutoGenerateColumns="false"
                      CssClass="table table-striped table-hover"
                      DataKeyNames="Id"
                      OnRowDeleting="gvLessons_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Course" />
                <asp:BoundField DataField="OrderIndex" HeaderText="#" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Language" HeaderText="Lang" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <a href='LessonEdit.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-primary">Edit</a>
                        <asp:LinkButton ID="btnDelete" runat="server" 
                                        CommandName="Delete" 
                                        CssClass="btn btn-sm btn-danger"
                                        OnClientClick="return confirm('Delete this lesson?');">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>