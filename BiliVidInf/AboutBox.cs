using System.Windows.Forms;

namespace BiliVidInf
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void LinkLabelProjSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Myitian/BiliVidInf");
        }

        private void AboutBox_Load(object sender, System.EventArgs e)
        {
            BiliVidInfLicense_TB.Text = Properties.Resources.LICENSE;
        }
    }
}
