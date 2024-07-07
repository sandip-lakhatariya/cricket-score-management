<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPlayer.aspx.cs" Inherits="CricketApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container shadow h-100 w-75 bg-light p-4 " >
  <div class="row">
    <div class="col">
      <label for="inputPlayerName">Name</label>
      <asp:TextBox type="text" class="form-control mt-1" id="inputPlayerName" placeholder="Enter Player Name" runat="server" />
    </div>
    <div class="col">
      <label for="inputMatchesPlayed">Matches Played</label>
      <asp:TextBox type="tel" class="form-control mt-1" id="inputMatchesPlayed" placeholder="Enter Matches Played" runat="server" />
    </div>
  </div>
  <div class="row mt-3">
    <div class="col">
      <label for="inputTotalRuns">Total Runs</label>
      <asp:TextBox type="tel" class="form-control mt-1" id="inputTotalRuns" placeholder="Enter Total Runs" runat="server" />
    </div>
    <div class="col">
      <label for="inputTotalWickets">Total Wickets</label>
      <asp:TextBox type="tel" class="form-control mt-1" id="inputTotalWickets" placeholder="Enter Total Wickets" runat="server" />
    </div>
  </div>
  <div class="row mt-3 align-items-end">
    <div class="col">
      <label for="inputTeamName">Team</label>
      <asp:DropDownList  id="inputTeamName" class="form-control mt-1" runat="server">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
       </asp:DropDownList>
    </div>
      <div class="col">
  <asp:Button ID="btnAddPlayer" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Add Player" OnClick="btnAddPlayer_Click" />
      </div>
  </div>
 </div>
</asp:Content>
