<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CricketApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <div class="row">
            <section class="col-md-6 px-4 py-xl-5 row align-items-center" aria-labelledby="gettingStartedTitle">
                <h1 id="gettingStartedTitle">Cricket Score Management</h1>
                <p class="h5">
                    Empowering every cricket enthusiast with <br />
                    real-time scores and statistics.
                </p>
                <p>
                    where every run counts, and every moment matters!
                </p>
                <p>
                    <a class="btn btn-primary" href="UpdateScore.aspx">Create Match &raquo;</a>
                </p>
            </section>
            <section class="col-md-6" aria-labelledby="librariesTitle">
                <img src="hero.jpg" height="400px"  />
            </section>
        </div>
    </main>

</asp:Content>
