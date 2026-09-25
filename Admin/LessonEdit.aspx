<%@ Page Title="Edit Lesson" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LessonEdit.aspx.cs" Inherits="MyCode.Admin.LessonEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4"><asp:Label ID="lblPageTitle" runat="server" Text="➕ Add New Lesson" /></h2>

        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3 text-danger" />

        <div class="card shadow-sm border-0">
            <div class="card-body p-4">
                <div class="mb-3">
                    <label>Course</label>
                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-select" />
                </div>

                <div class="mb-3">
                    <label>Order Index</label>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control" TextMode="Number" />
                    <small class="text-muted">Lesson 1, 2, 3, etc.</small>
                </div>

                <div class="mb-3">
                    <label>Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label>Language</label>
                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Python" Value="python" />
                        <asp:ListItem Text="Java" Value="java" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label>Content (HTML allowed)</label>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" />
                    <small class="text-muted">You can use HTML tags like &lt;p&gt;, &lt;strong&gt;, &lt;code&gt;</small>
                </div>

                <div class="mb-3">
                    <label>Code Example</label>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"
                                 style="font-family: Consolas, monospace;" />
                </div>

                <div class="d-flex gap-2">
                    <asp:Button ID="btnSave" runat="server" Text="💾 Save Lesson" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <a href="Lessons.aspx" class="btn btn-secondary">Cancel</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>