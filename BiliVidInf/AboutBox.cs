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
    }
}
