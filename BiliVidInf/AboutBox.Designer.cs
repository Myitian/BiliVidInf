namespace BiliVidInf
{
    partial class AboutBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.License = new System.Windows.Forms.TabControl();
            this.BiliVidInfLicense = new System.Windows.Forms.TabPage();
            this.BiliVidInfLicense_TB = new System.Windows.Forms.TextBox();
            this.NewtonsoftJsonLicense = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LabelAuthor = new System.Windows.Forms.Label();
            this.LabelProjSite = new System.Windows.Forms.Label();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelLicense = new System.Windows.Forms.Label();
            this.LinkLabelProjSite = new System.Windows.Forms.LinkLabel();
            this.License.SuspendLayout();
            this.BiliVidInfLicense.SuspendLayout();
            this.NewtonsoftJsonLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // License
            // 
            this.License.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.License.Controls.Add(this.BiliVidInfLicense);
            this.License.Controls.Add(this.NewtonsoftJsonLicense);
            this.License.Location = new System.Drawing.Point(12, 93);
            this.License.Name = "License";
            this.License.SelectedIndex = 0;
            this.License.Size = new System.Drawing.Size(510, 317);
            this.License.TabIndex = 0;
            // 
            // BiliVidInfLicense
            // 
            this.BiliVidInfLicense.Controls.Add(this.BiliVidInfLicense_TB);
            this.BiliVidInfLicense.Location = new System.Drawing.Point(4, 22);
            this.BiliVidInfLicense.Name = "BiliVidInfLicense";
            this.BiliVidInfLicense.Padding = new System.Windows.Forms.Padding(3);
            this.BiliVidInfLicense.Size = new System.Drawing.Size(502, 291);
            this.BiliVidInfLicense.TabIndex = 0;
            this.BiliVidInfLicense.Text = "BiliVidInf许可证：GPL-3.0-or-later";
            this.BiliVidInfLicense.UseVisualStyleBackColor = true;
            // 
            // BiliVidInfLicense_TB
            // 
            this.BiliVidInfLicense_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BiliVidInfLicense_TB.Location = new System.Drawing.Point(3, 3);
            this.BiliVidInfLicense_TB.Multiline = true;
            this.BiliVidInfLicense_TB.Name = "BiliVidInfLicense_TB";
            this.BiliVidInfLicense_TB.ReadOnly = true;
            this.BiliVidInfLicense_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiliVidInfLicense_TB.Size = new System.Drawing.Size(496, 285);
            this.BiliVidInfLicense_TB.TabIndex = 2;
            // 
            // NewtonsoftJsonLicense
            // 
            this.NewtonsoftJsonLicense.Controls.Add(this.textBox1);
            this.NewtonsoftJsonLicense.Location = new System.Drawing.Point(4, 22);
            this.NewtonsoftJsonLicense.Name = "NewtonsoftJsonLicense";
            this.NewtonsoftJsonLicense.Padding = new System.Windows.Forms.Padding(3);
            this.NewtonsoftJsonLicense.Size = new System.Drawing.Size(502, 291);
            this.NewtonsoftJsonLicense.TabIndex = 1;
            this.NewtonsoftJsonLicense.Text = "Newtonsoft.Json许可证：MIT";
            this.NewtonsoftJsonLicense.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(496, 285);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // LabelAuthor
            // 
            this.LabelAuthor.AutoSize = true;
            this.LabelAuthor.Location = new System.Drawing.Point(17, 18);
            this.LabelAuthor.Name = "LabelAuthor";
            this.LabelAuthor.Size = new System.Drawing.Size(83, 12);
            this.LabelAuthor.TabIndex = 1;
            this.LabelAuthor.Text = "作者：Myitian";
            // 
            // LabelProjSite
            // 
            this.LabelProjSite.AutoSize = true;
            this.LabelProjSite.Location = new System.Drawing.Point(17, 63);
            this.LabelProjSite.Name = "LabelProjSite";
            this.LabelProjSite.Size = new System.Drawing.Size(65, 12);
            this.LabelProjSite.TabIndex = 2;
            this.LabelProjSite.Text = "项目地址：";
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Location = new System.Drawing.Point(17, 33);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(185, 12);
            this.LabelEmail.TabIndex = 3;
            this.LabelEmail.Text = "Email：miaoyitian233@gmail.com";
            // 
            // LabelLicense
            // 
            this.LabelLicense.AutoSize = true;
            this.LabelLicense.Location = new System.Drawing.Point(17, 48);
            this.LabelLicense.Name = "LabelLicense";
            this.LabelLicense.Size = new System.Drawing.Size(293, 12);
            this.LabelLicense.TabIndex = 4;
            this.LabelLicense.Text = "许可证：GNU General Public License v3.0 or later";
            // 
            // LinkLabelProjSite
            // 
            this.LinkLabelProjSite.AutoSize = true;
            this.LinkLabelProjSite.Location = new System.Drawing.Point(77, 63);
            this.LinkLabelProjSite.Name = "LinkLabelProjSite";
            this.LinkLabelProjSite.Size = new System.Drawing.Size(227, 12);
            this.LinkLabelProjSite.TabIndex = 5;
            this.LinkLabelProjSite.TabStop = true;
            this.LinkLabelProjSite.Text = "https://github.com/Myitian/BiliVidInf";
            this.LinkLabelProjSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelProjSite_LinkClicked);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 421);
            this.Controls.Add(this.LinkLabelProjSite);
            this.Controls.Add(this.LabelLicense);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.LabelProjSite);
            this.Controls.Add(this.LabelAuthor);
            this.Controls.Add(this.License);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.License.ResumeLayout(false);
            this.BiliVidInfLicense.ResumeLayout(false);
            this.BiliVidInfLicense.PerformLayout();
            this.NewtonsoftJsonLicense.ResumeLayout(false);
            this.NewtonsoftJsonLicense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl License;
        private System.Windows.Forms.TabPage BiliVidInfLicense;
        private System.Windows.Forms.TabPage NewtonsoftJsonLicense;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox BiliVidInfLicense_TB;
        private System.Windows.Forms.Label LabelAuthor;
        private System.Windows.Forms.Label LabelProjSite;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Label LabelLicense;
        private System.Windows.Forms.LinkLabel LinkLabelProjSite;
    }
}
