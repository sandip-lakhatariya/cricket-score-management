<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CricketApp.WebForm13" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <section class="bg-light py-3 py-md-5">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-12 col-sm-10 col-md-8 col-lg-6 col-xl-5 col-xxl-4">
          <div class="card border border-light-subtle rounded-3 shadow-sm">
            <div class="card-body p-3 p-md-4 p-xl-5">
              <div class="text-center mb-3">
                <h3>Cricket Score Management</h3>
              </div>
              <h2 class="fs-6 fw-normal text-center text-secondary mb-4">Admin Login</h2>

                <div class="d-flex flex-column align-items-center justify-content-center">
              <div class="row">
                <div class="col-12"> <!-- Set full width for the input field -->
                  <asp:RequiredFieldValidator ID="rq_username" runat="server" ControlToValidate="txt_Username" ErrorMessage="username required !" ForeColor="Red"></asp:RequiredFieldValidator>
                  <asp:TextBox runat="server" ID="txt_Username" style="width: 300px;" CssClass="form-control p-2" placeholder="Enter Username"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-12 mb-3"> <!-- Set full width for the input field -->
                  <asp:RequiredFieldValidator ID="rq_password" runat="server" ControlToValidate="txt_Password" ErrorMessage="password required !" ForeColor="Red"></asp:RequiredFieldValidator>
                  <asp:TextBox runat="server" ID="txt_Password" style="width: 300px;" TextMode="Password" CssClass="form-control p-2" placeholder="Enter Password"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-12"> <!-- Set full width for the button -->
                  <div class="d-grid my-3">
                    <asp:Button runat="server" ID="btn_Login" style="width: 300px;" CssClass="btn btn-primary btn-lg" Text="Log in" OnClick="btn_Login_Click" />
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-12"> <!-- Set full width for the label -->
                  <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="Red" Text="Wrong Username or Password!"></asp:Label>
                </div>
              </div>
            </div>
                </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>

