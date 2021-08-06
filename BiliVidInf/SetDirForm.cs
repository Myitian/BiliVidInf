using System;
using System.IO;
using System.Windows.Forms;

namespace BiliVidInf
{
    public partial class SetDirForm : Form
    {
        public SetDirForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dir.Text = Program.savedir;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return && dir.Focused)
            {
                Confirm.PerformClick();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if(!(dir.Text.EndsWith(@"/")|| dir.Text.EndsWith(@"\")))
            {
                dir.Text += @"\";
            }
            if (!Directory.Exists(dir.Text))//如果不存在就创建 dir 文件夹
            {
                DialogResult dr = MessageBox.Show("路径不存在！是否创建路径？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    Directory.CreateDirectory(dir.Text);
                    Program.savedir = dir.Text;
                    Close();
                }
                else
                {
                    Program.savedir = dir.Text;
                    Close();
                }
            }
            else
            {
                    Program.savedir = dir.Text;
                    Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            string foldPath = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath + @"\";
            }
            dir.Text = foldPath;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}
