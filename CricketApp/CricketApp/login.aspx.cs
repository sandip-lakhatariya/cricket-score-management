using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CricketApp
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblError.Visible = false;
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string unm = txt_Username.Text;
            string psw = txt_Password.Text;
            
            if(unm == "CrickApp01" &&  psw == "Password@123")
            {
                Session["Username"] = unm;
                Response.Redirect("CreateTeam.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}