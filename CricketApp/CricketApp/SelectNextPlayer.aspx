<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectNextPlayer.aspx.cs" Inherits="CricketApp.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center" >
         <p class="h3">Its Wicket, Select Next Player</p>
  <div class="row mt-4 w-100 justify-content-center align-items-center">
      <div class="col-4">
          <label for="NewPlayer">Next Player</label>
      </div>
    <div class="col-4">
      
      <asp:DropDownList  id="NewPlayer" class="form-control" runat="server">
        <asp:ListItem selected="True">Choose...</asp:ListItem>
      </asp:DropDownList>
      <asp:HiddenField id="NewPlayerIdHidden" runat="server" />
    </div>
  </div>

     <div class="col mt-4">
  <asp:Button ID="btnNext" CssClass=" btn btn-primary mt-3" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Next" OnClick="btnNext_Click" />
      </div>
 </div>
</asp:Content>
