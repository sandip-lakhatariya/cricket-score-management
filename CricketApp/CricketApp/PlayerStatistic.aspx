<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerStatistic.aspx.cs" Inherits="CricketApp.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container shadow h-100 w-75 bg-light p-4 d-flex flex-column align-items-center " >
        <div class="row mt-3 w-100 justify-content-center align-items-center">
          <div class="col-4">
              <label for="Team">Select Team</label>
          </div>
          <div class="col-4">
      
          <asp:DropDownList  id="Team" class="form-control" runat="server" OnSelectedIndexChanged="Team_SelectedIndexChanged" AutoPostBack="true">
            
          </asp:DropDownList>
          <asp:HiddenField id="TeamId" runat="server" />
        </div>
       </div>
     </div>
     <div class="container shadow h-100 w-75 bg-light p-4" >
        <asp:Literal ID="litTable" runat="server"></asp:Literal>
         <div class="mt-3 d-flex justify-content-end">
            <asp:Button ID="btnAddPlayer" CssClass=" btn btn-primary" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: 1.25rem; --bs-btn-font-size: 1.2rem;" runat="server" Text="Add Player" OnClick="btnAddPlayer_Click" />
         </div>
     </div>
</asp:Content>
