<%@ Page Title="Manage Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="MyCode.Admin.Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">💬 Manage Comments</h2>

        <asp:GridView ID="gvComments" runat="server" AutoGenerateColumns="false"
                      CssClass="table table-striped table-hover"
                      DataKeyNames="Id"
                      OnRowDeleting="gvComments_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="UserName" HeaderText="User" />
                <asp:BoundField DataField="LessonTitle" HeaderText="Lesson" />
                <asp:BoundField DataField="Body" HeaderText="Comment" />
                <asp:BoundField DataField="CreatedAt" HeaderText="Posted" DataFormatString="{0:MMM d, yyyy h:mm tt}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" 
                                        CommandName="Delete" 
                                        CssClass="btn btn-sm btn-danger"
                                        OnClientClick="return confirm('Delete this comment?');">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>