<%@ Page Title="Course" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="MyCode.CourseDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-5">
            <h1><asp:Label ID="lblIcon" runat="server" /> <asp:Label ID="lblTitle" runat="server" /></h1>
            <p class="text-muted"><asp:Label ID="lblDescription" runat="server" /></p>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="list-group shadow-sm">
                    <asp:Repeater ID="rptLessons" runat="server">
                        <ItemTemplate>
                            <a href='Lesson.aspx?id=<%# Eval("Id") %>' 
                               class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">
                                <div>
                                    <strong><%# Eval("OrderIndex") %>. <%# Eval("Title") %></strong>
                                </div>
                                <span class="badge bg-primary rounded-pill">Start →</span>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <!-- Final Project Button -->
<asp:Panel ID="pnlFinalProject" runat="server" CssClass="mt-5 text-center">
    <div class="card shadow-sm border-0 bg-light">
        <div class="card-body p-4">
            <h4 class="mb-2">🏆 Ready for the Final Project?</h4>
            <p class="text-muted mb-3">
                Put everything you've learned to the test. Build a small program and submit your code.
            </p>
            <asp:HyperLink ID="lnkFinalProject" runat="server" CssClass="btn btn-success btn-lg">
                Start Final Project →
            </asp:HyperLink>
        </div>
    </div>
</asp:Panel>
    </div>
</asp:Content>