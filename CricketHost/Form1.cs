using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CricketHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost sh1 = null, sh2 = null, sh3=null;
        private void Form1_Load(object sender, EventArgs e)
        {
            sh1 = new ServiceHost(typeof(PlayerService.PlayerService));
            sh1.Open();

            sh2 = new ServiceHost(typeof(TeamService.TeamService));
            sh2.Open();

            sh3 = new ServiceHost(typeof(ScoreUpdate.ScoreUpdate));
            sh3.Open();

            label1.Text = "Service is running...";
        }
    }
}
