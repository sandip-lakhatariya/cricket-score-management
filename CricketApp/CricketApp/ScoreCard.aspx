<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScoreCard.aspx.cs" Inherits="CricketApp.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center" >
    
        <div class="d-flex flex-row justify-content-around w-100">
            <div class="d-flex flex-column align-items-center">
              <p class="h4" >Team-A</p>
              <asp:Label ID="lbl_TeamARuns" runat="server" CssClass="h3" Text="Label"></asp:Label>
              <asp:Label ID="lbl_TeamABalls" runat="server" Text="Label"></asp:Label>
              <asp:Label ID="lbl_TeamAExtra" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="d-flex flex-column  align-items-center ">
                <p class="h4" >Team-B</p>
              <asp:Label ID="lbl_TeamBRuns" runat="server" CssClass="h3" Text="Label"></asp:Label>
              <asp:Label ID="lbl_TeamBBalls" runat="server" Text="Label"></asp:Label>
              <asp:Label ID="lbl_TeamBExtra" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <div class="container shadow h-100 w-75 bg-light p-4 mt-4 " >

        <div class="mb-4">
            <asp:Button ID="btnShowTable1" runat="server" Text="TeamA" OnClick="btnShowTable1_Click" />
            <asp:Button ID="btnShowTable2" runat="server" Text="TeamB" OnClick="btnShowTable2_Click" />
        </div>

        <asp:Literal ID="litTable1" runat="server"></asp:Literal>
        <div class="mt-5">
            <asp:Literal ID="litTable3" runat="server"></asp:Literal>
        </div>
        <asp:Literal ID="litTable2" runat="server"></asp:Literal>
        <div class="mt-5">
            <asp:Literal ID="litTable4" runat="server"></asp:Literal>
        </div>
    </div>

    
</asp:Content>
