<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FirstInnings.aspx.cs" Inherits="CricketApp.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center">
        <p class="h4">First Inning is Over</p>
        <asp:Label ID="lbl_Target" runat="server" CssClass="h2 mt-3 mb-3" Text="Label"></asp:Label>
        <asp:Button ID="btnSecondInning" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Start 2nd Inning" OnClick="btnSelectNext_Click" />
    </div>
</asp:Content>
