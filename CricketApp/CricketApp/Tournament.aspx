<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tournament.aspx.cs" Inherits="CricketApp.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container shadow h-100 w-75 bg-light p-4" >
        <asp:Literal ID="litTable" runat="server"></asp:Literal>

        <table id="dynamicTable" runat="server">
            
            <thead>
                <tr>
                    <th scope='col'>#</th>
                    <th scope='col'>Match</th>
                    <th scope='col'>Winner</th>
                    <th scope='col'>ScoreCard</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>

     </div>

</asp:Content>
