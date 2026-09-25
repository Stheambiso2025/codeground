<%@ Page Title="Activate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activate.aspx.cs" Inherits="MyCode.Activate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-center">
        <div class="card shadow mx-auto" style="max-width: 500px;">
            <div class="card-body p-5">
                <h3 class="mb-4">Account Activation</h3>
                <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-4 fs-5" />
                <a href="Login.aspx" class="btn btn-primary">Go to Login</a>
            </div>
        </div>
    </div>
</asp:Content>