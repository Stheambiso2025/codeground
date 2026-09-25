<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="MyCode.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">👥 Manage Users</h2>

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false"
                      CssClass="table table-striped table-hover"
                      DataKeyNames="Id"
                      OnRowDeleting="gvUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CheckBoxField DataField="IsAdmin" HeaderText="Admin" ReadOnly="true" />
                <asp:BoundField DataField="IsEmailConfirmed" HeaderText="Verified" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" 
                                        CommandName="Delete" 
                                        CssClass="btn btn-sm btn-danger"
                                        OnClientClick="return confirm('Delete this user? This will also delete their comments and likes.');">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
