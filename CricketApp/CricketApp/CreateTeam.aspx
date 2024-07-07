<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTeam.aspx.cs" Inherits="CricketApp.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center " >
      <div class="row w-100 justify-content-center align-items-center text-center mb-5">
        <h2>Schedule New Match</h2>
      </div>
      <div class="row w-100 justify-content-center align-items-center">
        <div class="col-4">
            <label for="matchNumber">Match Number</label>
        </div>
          <div class="col-4">
            <asp:TextBox type="tel" class="form-control" id="matchNumber" placeholder="Enter Match Number" runat="server" />
          </div>
      </div>

    <div class="row mt-3 w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="TeamA">Batting Team</label>
      </div>
      <div class="col-4">
      
      <asp:DropDownList  id="TeamA" class="form-control" runat="server" OnSelectedIndexChanged="PlayerName1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
      </asp:DropDownList>
      <asp:HiddenField id="TeamAId" runat="server" />
    </div>
    </div>
      <div class="row mt-3 w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="TeamB">Bowling Team</label>
      </div>
    <div class="col-4">
      
      <asp:DropDownList  id="TeamB" class="form-control" runat="server">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
       </asp:DropDownList>
        <asp:HiddenField id="TeamBId" runat="server" />
    </div>

  </div>
      <div class="row mt-3 w-100 justify-content-center align-items-center">
        <div class="col-4">
            <label for="Over">Overs</label>
        </div>
          <div class="col-4">
            <asp:TextBox type="text" class="form-control" id="Over" placeholder="Enter Number of Overs" runat="server" />
          </div>
        </div>
     <div class="col mt-4">
        <asp:Button ID="btnCreateTeam" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Start Match" OnClick="btnCreateTeam_Click" />
      </div>
 </div>
</asp:Content>
