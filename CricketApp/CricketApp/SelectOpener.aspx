<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectOpener.aspx.cs" Inherits="CricketApp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center" >
     <div class="row w-100 justify-content-center align-items-center text-center mb-5">
        <h2>Select Opener</h2>
      </div>
  <div class="row w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="PlayerName1">Striker-End</label>
      </div>
    <div class="col-4">
      
      <asp:DropDownList  id="PlayerName1" class="form-control" runat="server" OnSelectedIndexChanged="PlayerName1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
      </asp:DropDownList>
      <asp:HiddenField id="Player1IdHidden" runat="server" />
    </div>
  </div>
      <div class="row mt-3 w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="PlayerName2">Non-Striker-End</label>
      </div>
    <div class="col-4">
      
      <asp:DropDownList  id="PlayerName2" class="form-control" runat="server">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
       </asp:DropDownList>
        <asp:HiddenField id="Player2IDHidden" runat="server" />
    </div>
  </div>
     <div class="row mt-3 w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="Bowler">Bowler</label>
      </div>
    <div class="col-4">
      
      <asp:DropDownList  id="Bowler" class="form-control" runat="server">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
       </asp:DropDownList>
        <asp:HiddenField id="BowlerId" runat="server" />
    </div>
  </div>
     <div class="col mt-4">
  <asp:Button ID="btnNext" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Next" OnClick="btnNext_Click" />
      </div>
 </div>
</asp:Content>
