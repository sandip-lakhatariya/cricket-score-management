<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LiveScore.aspx.cs" Inherits="CricketApp.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="NoLiveMatch" runat="server" class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center" >
       <divd-flex flex-column align-items-center>
            <h1 class="mb-5 text-center">Currently, There Is No Live Match!</h1>
            <h6 class="text-center">Please Come After Some Time.</h6>
       </divd-flex>
    </div>
    
    <div id="LiveScore" runat="server">
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

<table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Batsman</th>
      <th scope="col">Runs</th>
      <th scope="col">Balls</th>
      <th scope="col">Status</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td><asp:Label ID="lbl_Player1" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player1Run" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player1Ball" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player1Status" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td><asp:Label ID="lbl_Player2" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player2Run" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player2Ball" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_Player2Status" runat="server" Text="Label"></asp:Label></td>
    </tr>
  </tbody>
</table>

        <table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Bowler</th>
      <th scope="col">Overs</th>
      <th scope="col">Runs</th>
      <th scope="col">Wickets</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td><asp:Label ID="lbl_bowler" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_bowlerOvers" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_bowler_runs" runat="server" Text="Label"></asp:Label></td>
      <td><asp:Label ID="lbl_bowler_wickets" runat="server" Text="Label"></asp:Label></td>
    </tr>
  </tbody>
</table>
    
    <asp:Button ID="btnScoreCard" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Score Card" OnClick="btnScoreCard_Click" />

  </div>
        </div>
</asp:Content>
