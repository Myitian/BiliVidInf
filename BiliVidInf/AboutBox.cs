using System.Reflection;
using System.Windows.Forms;

namespace BiliVidInf
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = $"关于 - {AssemblyTitle()} {AssemblyFileVersion()}";
        }

        public string AssemblyFileVersion()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            else
            {
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        public string AssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            else
            {
                return ((AssemblyTitleAttribute)attributes[0]).Title;
            }
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
