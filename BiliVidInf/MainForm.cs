using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BiliVidInf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Err(string s)
        {
            err.ForeColor = Color.FromArgb(255, 0, 0);
            err.Text = s;
            bvid0.Text = "BV";
            aid0.Text = "AV";
            videos0.Text = "P数：";
            tname0.Text = "分区：";
            pic0.Image = null;
            title0.Text = "";
            pubdate0.Text = "";
            desc1.Text = "";
            mid0.Text = "UID:";
            name0.Text = "";
            face0.Image = null;
            view0.Text = "播放量：";
            danmaku0.Text = "弹幕数";
            reply0.Text = "评论数：";
            favorite0.Text = "收藏数：";
            coin0.Text = "硬币数：";
            share0.Text = "转发数：";
            like0.Text = "点赞数：";
            DV2.Value = 0;
            LV2.Value = 0;
            CV2.Value = 0;
            FV2.Value = 0;
            SV2.Value = 0;
            RV2.Value = 0;
            DV0.Text = "弹幕/播放比：";
            LV0.Text = "点赞/播放比：";
            CV0.Text = "硬币/播放比：";
            FV0.Text = "收藏/播放比：";
            SV0.Text = "转发/播放比：";
            RV0.Text = "评论/播放比：";
        }

        string loc = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\BiliVidDat",
                locJSON = @"\TempJSON.json", locINI = @"\TempINI.ini", locPIC = @"\TempPIC.",
                bvid = "",
                aid = "",
                videos = "",
                tname = "",
                pic = "",
                title = "",
                pubdate = "",
                desc = "",
                mid = "",
                name = "",
                face = "",
                view = "",
                danmaku = "",
                reply = "",
                favorite = "",
                coin = "",
                share = "",
                like = "",
                picn = "",
                ctime = "",
                tid = "",
                his_rank = "";
        string[] cid, page, from, part;

        private void About_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void CopyBVID_Click(object sender, EventArgs e)
        {
            if (readok)
            {
                Clipboard.SetText(bvid, TextDataFormat.UnicodeText);
            }
        }

        private void CopyUrl_Click(object sender, EventArgs e)
        {
            if (readok)
            {
                Clipboard.SetText("b23.tv/av" + aid, TextDataFormat.UnicodeText);
            }
        }

        private void CopyAID_Click(object sender, EventArgs e)
        {
            if (readok)
            {
                Clipboard.SetText(aid, TextDataFormat.UnicodeText);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            DV2.Width = DV1.Width;
            DV2.Height = DV1.Height;
            LV2.Width = LV1.Width;
            LV2.Height = LV1.Height;
            CV2.Width = CV1.Width;
            CV2.Height = CV1.Height;
            FV2.Width = FV1.Width;
            FV2.Height = FV1.Height;
            SV2.Width = SV1.Width;
            SV2.Height = SV1.Height;
            RV2.Width = RV1.Width;
            RV2.Height = RV1.Height;
        }

        bool dlok1 = false, dlok2 = false, picok = false, readok = false;
        double DV, LV, CV, FV, SV, RV;
        int DVI, LVI, CVI, FVI, SVI, RVI;
        string DVT, LVT, CVT, FVT, SVT, RVT;

        MyProgressBar DV2 = new MyProgressBar();
        MyProgressBar LV2 = new MyProgressBar();
        MyProgressBar CV2 = new MyProgressBar();
        MyProgressBar FV2 = new MyProgressBar();
        MyProgressBar SV2 = new MyProgressBar();
        MyProgressBar RV2 = new MyProgressBar();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return && ID.Focused)
            {
                GetVidDat.PerformClick();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void GetVidDat_Click(object sender, EventArgs e)
        {
            readok = false;
            Regex
                BVUrlL = new Regex(@"^(https?://)?www\.bilibili\.com/video/[Bb][Vv][1-9a-km-zA-HJ-NP-Z]{10}(\S*)$?", RegexOptions.ExplicitCapture),
                BVUrlS = new Regex(@"^(https?://)?b23\.tv/[Bb][Vv][1-9a-km-zA-HJ-NP-Z]{10}(\S*)?$", RegexOptions.ExplicitCapture),
                AVUrlL = new Regex(@"^(https?://)?www\.bilibili\.com/video/[Aa][Vv]\d+(\S*)?$", RegexOptions.ExplicitCapture),
                AVUrlS = new Regex(@"^(https?://)?b23\.tv/[Aa][Vv]\d+(\S*)?$", RegexOptions.ExplicitCapture),
                BIDreg = new Regex(@"^[Bb][Vv][1-9a-km-zA-HJ-NP-Z]{10}$", RegexOptions.ExplicitCapture),
                AIDreg = new Regex(@"^[Aa][Vv]\d+$", RegexOptions.ExplicitCapture),
                BIDreg2 = new Regex(@"^[1-9a-km-zA-HJ-NP-Z]{10}$", RegexOptions.ExplicitCapture),
                AIDreg2 = new Regex(@"^\d+$", RegexOptions.ExplicitCapture),
                BID2 = new Regex(@"[Bb][Vv][1-9a-km-zA-HJ-NP-Z]{10}", RegexOptions.ExplicitCapture),
                AID2 = new Regex(@"[Aa][Vv]\d+", RegexOptions.ExplicitCapture);
            string idi = ID.Text;
            bool matchok = false;
            if (BVUrlL.IsMatch(idi))
            {
                bvid = BID2.Match(idi).ToString();
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?bvid=" + bvid, loc + locJSON);
            }
            else if (BVUrlS.IsMatch(idi))
            {
                bvid = BID2.Match(idi).ToString();
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?bvid=" + bvid, loc + locJSON);
            }
            else if (AVUrlL.IsMatch(idi))
            {
                aid = AID2.Match(idi).ToString();
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?aid=" + aid.Substring(2), loc + locJSON);
            }
            else if (AVUrlS.IsMatch(idi))
            {
                aid = AID2.Match(idi).ToString();
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?aid=" + aid.Substring(2), loc + locJSON);
            }
            else if (BIDreg.IsMatch(idi))
            {
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?bvid=" + ID.Text, loc + locJSON);
            }
            else if (AIDreg.IsMatch(idi))
            {
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?aid=" + ID.Text.Substring(2), loc + locJSON);
            }
            else if (BIDreg2.IsMatch(idi))
            {
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?bvid=BV" + ID.Text, loc + locJSON);
            }
            else if (AIDreg2.IsMatch(idi))
            {
                matchok = true;
                dlok1 = DownloadFile(@"https://api.bilibili.com/x/web-interface/view?aid=" + ID.Text, loc + locJSON);
            }
            else
            {
                err.ForeColor = Color.FromArgb(255, 0, 0);
                err.Text = "地址错误！";
            }
            if (matchok)
            {
                if (dlok1)
                {
                    DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                    string jsonText = File.ReadAllText(loc + locJSON);
                    RootObject rb = JsonConvert.DeserializeObject<RootObject>(jsonText);
                    if (rb.code != 0)
                    {
                        Err("视频不存在！错误信息： code:" + rb.code.ToString() + " message:" + rb.message);
                    }
                    else
                    {
                        cid = new string[rb.data.videos];
                        page = new string[rb.data.videos];
                        from = new string[rb.data.videos];
                        part = new string[rb.data.videos];

                        bvid = rb.data.bvid;
                        bvid0.Text = bvid;

                        aid = rb.data.aid.ToString();
                        aid0.Text = "AV" + aid;

                        videos = rb.data.videos.ToString();
                        videos0.Text = "P数：" + videos;

                        tid = rb.data.tid.ToString();

                        tname = rb.data.tname;
                        tname0.Text = "分区：" + tname;

                        pic = rb.data.pic;
                        picok = true;
                        Regex picregjpg = new Regex(@"^http:\S+\.hdslb\.com/\S+\.jpg$", RegexOptions.ExplicitCapture);
                        Regex picreggif = new Regex(@"^http:\S+\.hdslb\.com/\S+\.gif$", RegexOptions.ExplicitCapture);
                        Regex picregpng = new Regex(@"^http:\S+\.hdslb\.com/\S+\.png$", RegexOptions.ExplicitCapture);
                        Regex picregwebp = new Regex(@"^http:\S+\.hdslb\.com/\S+\.webp$", RegexOptions.ExplicitCapture);
                        if (pic == "http://static.hdslb.com/images/transparent.gif")
                        {
                            pic0.ImageLocation = pic;
                        }
                        else if (picregjpg.IsMatch(pic))
                        {
                            pic0.ImageLocation = pic + "_224x140.jpg";
                        }
                        else if (picreggif.IsMatch(pic))
                        {
                            pic0.ImageLocation = pic + "_224x140.gif";
                        }
                        else if (picregpng.IsMatch(pic))
                        {
                            pic0.ImageLocation = pic + "_224x140.png";
                        }
                        else if (picregwebp.IsMatch(pic))
                        {
                            pic0.Image = Properties.Resource.DoNotSupportWEBP;
                            //、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、、
                        }

                        title = rb.data.title;
                        title0.Text = title;

                        pubdate = rb.data.pubdate.ToString();
                        pubdate0.Text = "发布时间：" + startTime.AddSeconds(double.Parse(pubdate)).ToString();

                        ctime = rb.data.ctime.ToString();
                        ctime0.Text = "更新时间：" + startTime.AddSeconds(double.Parse(ctime)).ToString();

                        desc = rb.data.desc;
                        string temp = Regex.Replace(desc, @"\r\n", Environment.NewLine);
                        temp = Regex.Replace(temp, @"(\r|\n)", Environment.NewLine);
                        desc1.Text = temp;

                        mid = rb.data.owner.mid.ToString();
                        mid0.Text = "UID:" + mid;

                        name = rb.data.owner.name;
                        name0.Text = name;

                        face = rb.data.owner.face;
                        Regex faceregjpg = new Regex(@"^http:\S+\.hdslb\.com/\S+\.jpg$");
                        Regex facereggif = new Regex(@"^http:\S+\.hdslb\.com/\S+\.gif$");
                        Regex faceregpng = new Regex(@"^http:\S+\.hdslb\.com/\S+\.png$");
                        Regex faceregwebp = new Regex(@"^http:\S+\.hdslb\.com/\S+\.webp$");
                        if (faceregwebp.IsMatch(face))
                        {
                            face0.Image = Properties.Resource.DoNotSupportWEBP;
                        }
                        else if (faceregjpg.IsMatch(face))
                        {
                            face0.ImageLocation = face + "_48x48.jpg";
                        }
                        else if (facereggif.IsMatch(face))
                        {
                            face0.ImageLocation = face + "_48x48.gif";
                        }
                        else if (faceregpng.IsMatch(face))
                        {
                            face0.ImageLocation = face + "_48x48.png";
                        }

                        view = rb.data.stat.view.ToString();
                        view0.Text = "播放量：" + view;

                        danmaku = rb.data.stat.danmaku.ToString();
                        danmaku0.Text = "弹幕数：" + danmaku;

                        reply = rb.data.stat.reply.ToString();
                        reply0.Text = "评论数：" + reply;

                        favorite = rb.data.stat.favorite.ToString();
                        favorite0.Text = "收藏数：" + favorite;

                        coin = rb.data.stat.coin.ToString();
                        coin0.Text = "硬币数：" + coin;

                        share = rb.data.stat.share.ToString();
                        share0.Text = "转发数：" + share;

                        like = rb.data.stat.like.ToString();
                        like0.Text = "点赞数：" + like;

                        his_rank = rb.data.stat.his_rank.ToString();
                        if (his_rank == "0")
                        {
                            his_rank0.Text = "历史排名：无";
                        }
                        else
                        {
                            his_rank0.Text = "历史排名：" + his_rank;
                        }

                        videos1.Items.Clear();
                        for (int i = 0; i < rb.data.videos; i++)
                        {
                            cid[i] = rb.data.pages[i].cid.ToString();
                            page[i] = rb.data.pages[i].page.ToString();
                            from[i] = rb.data.pages[i].from;
                            part[i] = rb.data.pages[i].part;
                            videos1.Items.Add("P" + page[i] + " - " + part[i]);
                        }
                        double
                                V2 = Convert.ToDouble(view),
                                D2 = Convert.ToDouble(danmaku),
                                L2 = Convert.ToDouble(like),
                                C2 = Convert.ToDouble(coin),
                                F2 = Convert.ToDouble(favorite),
                                S2 = Convert.ToDouble(share),
                                R2 = Convert.ToDouble(reply);
                        if (V2 != 0)
                        {
                            DV = D2 / V2;
                            LV = L2 / V2;
                            CV = C2 / V2;
                            FV = F2 / V2;
                            SV = S2 / V2;
                            RV = R2 / V2;
                            DVI = Convert.ToInt32(10000000 * DV);
                            LVI = Convert.ToInt32(10000000 * LV);
                            CVI = Convert.ToInt32(10000000 * CV);
                            FVI = Convert.ToInt32(10000000 * FV);
                            SVI = Convert.ToInt32(10000000 * SV);
                            RVI = Convert.ToInt32(10000000 * RV);
                            DVT = DVI.ToString();
                            LVT = LVI.ToString();
                            CVT = CVI.ToString();
                            FVT = FVI.ToString();
                            SVT = SVI.ToString();
                            RVT = RVI.ToString();
                            if (DVT.Length < 8)
                            {
                                DVT = DVT.PadLeft(8, '0');
                            }
                            if (LVT.Length < 8)
                            {
                                LVT = LVT.PadLeft(8, '0');
                            }
                            if (CVT.Length < 8)
                            {
                                CVT = CVT.PadLeft(8, '0');
                            }
                            if (FVT.Length < 8)
                            {
                                FVT = FVT.PadLeft(8, '0');
                            }
                            if (SVT.Length < 8)
                            {
                                SVT = SVT.PadLeft(8, '0');
                            }
                            if (RVT.Length < 8)
                            {
                                RVT = RVT.PadLeft(8, '0');
                            }
                            DVT = DVT.Substring(0, DVT.Length - 7) + "." + StrRight(DVT, 7);
                            LVT = LVT.Substring(0, LVT.Length - 7) + "." + StrRight(LVT, 7);
                            CVT = CVT.Substring(0, CVT.Length - 7) + "." + StrRight(CVT, 7);
                            FVT = FVT.Substring(0, FVT.Length - 7) + "." + StrRight(FVT, 7);
                            SVT = SVT.Substring(0, SVT.Length - 7) + "." + StrRight(SVT, 7);
                            RVT = RVT.Substring(0, RVT.Length - 7) + "." + StrRight(RVT, 7);
                            DV0.Text = "弹幕/播放比：" + DVT;
                            LV0.Text = "点赞/播放比：" + LVT;
                            CV0.Text = "硬币/播放比：" + CVT;
                            FV0.Text = "收藏/播放比：" + FVT;
                            SV0.Text = "转发/播放比：" + SVT;
                            RV0.Text = "评论/播放比：" + RVT;
                            if (DV < 1)
                            {
                                DV2.Value = DVI;
                            }
                            else
                            {
                                DV2.Value = 10000000;
                            }
                            if (LV < 1)
                            {
                                LV2.Value = LVI;
                            }
                            else
                            {
                                LV2.Value = 10000000;
                            }
                            if (CV < 1)
                            {
                                CV2.Value = CVI;
                            }
                            else
                            {
                                CV2.Value = 10000000;
                            }
                            if (FV < 1)
                            {
                                FV2.Value = FVI;
                            }
                            else
                            {
                                FV2.Value = 10000000;
                            }
                            if (SV < 1)
                            {
                                SV2.Value = SVI;
                            }
                            else
                            {
                                SV2.Value = 10000000;
                            }
                            if (RV < 1)
                            {
                                RV2.Value = RVI;
                            }
                            else
                            {
                                RV2.Value = 10000000;
                            }
                        }
                        else
                        {
                            DV2.Value = 0;
                            LV2.Value = 0;
                            CV2.Value = 0;
                            FV2.Value = 0;
                            SV2.Value = 0;
                            RV2.Value = 0;
                            DV0.Text = "弹幕/播放比：";
                            LV0.Text = "点赞/播放比：";
                            CV0.Text = "硬币/播放比：";
                            FV0.Text = "收藏/播放比：";
                            SV0.Text = "转发/播放比：";
                            RV0.Text = "评论/播放比：";
                        }
                        readok = true;
                    }
                }
                else
                {
                    err.ForeColor = Color.FromArgb(255, 0, 0);
                    err.Text = "未知错误！";
                }
            }
        }

        private bool DownloadFile(string URL, string filename)
        {
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(filename, FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, by.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(loc))//如果不存在就创建 dir 文件夹  
                Directory.CreateDirectory(loc);
            DV2.Parent = DV1;
            DV2.Minimum = 0;//进度条显示最小值
            DV2.Maximum = 10000000;//进度条显示最大值
            DV2.Width = DV1.Width;
            DV2.Height = DV1.Height;
            DV2.BackColor = Color.FromArgb(230, 230, 230);
            LV2.Parent = LV1;
            LV2.Minimum = 0;//进度条显示最小值
            LV2.Maximum = 10000000;//进度条显示最大值
            LV2.Width = LV1.Width;
            LV2.Height = LV1.Height;
            LV2.BackColor = Color.FromArgb(230, 230, 230);
            CV2.Parent = CV1;
            CV2.Minimum = 0;//进度条显示最小值
            CV2.Maximum = 10000000;//进度条显示最大值
            CV2.Width = CV1.Width;
            CV2.Height = CV1.Height;
            CV2.BackColor = Color.FromArgb(230, 230, 230);
            FV2.Parent = FV1;
            FV2.Minimum = 0;//进度条显示最小值
            FV2.Maximum = 10000000;//进度条显示最大值
            FV2.Width = FV1.Width;
            FV2.Height = FV1.Height;
            FV2.BackColor = Color.FromArgb(230, 230, 230);
            SV2.Parent = SV1;
            SV2.Minimum = 0;//进度条显示最小值
            SV2.Maximum = 10000000;//进度条显示最大值
            SV2.Width = SV1.Width;
            SV2.Height = SV1.Height;
            SV2.BackColor = Color.FromArgb(230, 230, 230);
            RV2.Parent = RV1;
            RV2.Minimum = 0;//进度条显示最小值
            RV2.Maximum = 10000000;//进度条显示最大值
            RV2.Width = RV1.Width;
            RV2.Height = RV1.Height;
            RV2.BackColor = Color.FromArgb(230, 230, 230);
        }

        public class MyProgressBar : ProgressBar
        {
            public MyProgressBar()
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }

            //重写OnPaint方法
            protected override void OnPaint(PaintEventArgs e)
            {
                Pen pen = new Pen(Color.FromArgb(188, 188, 188));
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);

                bounds.Height -= 4;
                bounds.Width = ((int)(bounds.Width * (((double)Value) / Maximum))) - 4;
                SolidBrush brush = new SolidBrush(Color.FromArgb(6, 170, 37));
                e.Graphics.DrawRectangle(pen, rec);
                e.Graphics.FillRectangle(brush, 2, 2, bounds.Width, bounds.Height);
            }
        }

        public class IniFiles
        {
            public string inipath;

            //声明API函数

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            /// <summary> 
            /// 构造方法 
            /// </summary> 
            /// <param name="INIPath">文件路径</param> 
            public IniFiles(string INIPath)
            {
                inipath = INIPath;
            }

            public IniFiles() { }

            /// <summary> 
            /// 写入INI文件 
            /// </summary> 
            /// <param name="Section">项目名称(如 [TypeName] )</param> 
            /// <param name="Key">键</param> 
            /// <param name="Value">值</param> 
            public void IniWriteValue(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.inipath);
            }
            /// <summary> 
            /// 读出INI文件 
            /// </summary> 
            /// <param name="Section">项目名称(如 [TypeName] )</param> 
            /// <param name="Key">键</param> 
            public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(500);
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
                return temp.ToString();
            }
            /// <summary> 
            /// 验证文件是否存在 
            /// </summary> 
            /// <returns>布尔值</returns> 
            public bool ExistINIFile()
            {
                return File.Exists(inipath);
            }
        }

        private void DLPic_Click(object sender, EventArgs e)
        {
            if (readok && picok)
            {
                Regex picregjpg = new Regex(@"^http://\S+\.hdslb\.com/\S+\.jpg$", RegexOptions.ExplicitCapture);
                Regex picreggif = new Regex(@"^http://\S+\.hdslb\.com/\S+\.gif$", RegexOptions.ExplicitCapture);
                Regex picregpng = new Regex(@"^http://\S+\.hdslb\.com/\S+\.png$", RegexOptions.ExplicitCapture);
                Regex picregwebp = new Regex(@"^http://\S+\.hdslb\.com/\S+\.webp$", RegexOptions.ExplicitCapture);
                if (picregwebp.IsMatch(pic))
                {
                    picn = loc + locPIC + "webp";
                    dlok2 = DownloadFile(pic, picn);
                    SaveFile(picn, Program.savedir + "AV" + aid + " 的视频封面.webp");
                }
                else if (picregjpg.IsMatch(pic))
                {
                    picn = loc + locPIC + "jpg";
                    dlok2 = DownloadFile(pic, picn);
                    SaveFile(picn, Program.savedir + "AV" + aid + " 的视频封面.jpg");
                }
                else if (picreggif.IsMatch(pic))
                {
                    picn = loc + locPIC + "gif";
                    dlok2 = DownloadFile(pic, picn);
                    SaveFile(picn, Program.savedir + "AV" + aid + " 的视频封面.gif");
                }
                else if (picregpng.IsMatch(pic))
                {
                    picn = loc + locPIC + "png";
                    dlok2 = DownloadFile(pic, picn);
                    SaveFile(picn, Program.savedir + "AV" + aid + " 的视频封面.png");
                }
                else
                {
                    string[] picsp = pic.Split('.');
                    picn = loc + locPIC + picsp[picsp.Length - 1];
                    dlok2 = DownloadFile(pic, picn);
                    SaveFile(picn, Program.savedir + "AV" + aid + " 的视频封面." + picsp[picsp.Length - 1]);
                }
            }
        }

        private void SaveInf_Click(object sender, EventArgs e)
        {
            if (readok)
            {
                IniFiles ini = new IniFiles(loc + locINI);

                string temp = Regex.Replace(desc, @"\r\n", "\\r\\n");
                temp = Regex.Replace(temp, @"\r", "\\r");
                string desc_o = Regex.Replace(temp, @"\n", "\\n");

                ini.IniWriteValue("Bilibili 视频数据", "标题", title);
                ini.IniWriteValue("Bilibili 视频数据", "AV号", "AV" + aid);
                ini.IniWriteValue("Bilibili 视频数据", "BV号", bvid);
                ini.IniWriteValue("Bilibili 视频数据", "分区号", tid);
                ini.IniWriteValue("Bilibili 视频数据", "分区", tname);
                ini.IniWriteValue("Bilibili 视频数据", "发布时间", pubdate);
                ini.IniWriteValue("Bilibili 视频数据", "发布时间", ctime);
                ini.IniWriteValue("Bilibili 视频数据", "封面地址", pic);
                ini.IniWriteValue("Bilibili 视频数据", "简介", desc_o);
                ini.IniWriteValue("Bilibili 视频数据", "播放量", view);
                ini.IniWriteValue("Bilibili 视频数据", "弹幕数", danmaku);
                ini.IniWriteValue("Bilibili 视频数据", "点赞数", like);
                ini.IniWriteValue("Bilibili 视频数据", "硬币数", coin);
                ini.IniWriteValue("Bilibili 视频数据", "收藏数", favorite);
                ini.IniWriteValue("Bilibili 视频数据", "转发数", share);
                ini.IniWriteValue("Bilibili 视频数据", "评论数", reply);
                ini.IniWriteValue("Bilibili 视频数据", "历史排名", his_rank);
                ini.IniWriteValue("Bilibili 视频数据", "UP主", name);
                ini.IniWriteValue("Bilibili 视频数据", "UP主UID", mid);
                ini.IniWriteValue("Bilibili 视频数据", "UP主头像", face);
                ini.IniWriteValue("Bilibili 视频数据", "P数", videos);
                ini.IniWriteValue("Bilibili 视频数据", "弹幕/播放比：", DVT);
                ini.IniWriteValue("Bilibili 视频数据", "点赞/播放比：", LVT);
                ini.IniWriteValue("Bilibili 视频数据", "硬币/播放比：", CVT);
                ini.IniWriteValue("Bilibili 视频数据", "收藏/播放比：", FVT);
                ini.IniWriteValue("Bilibili 视频数据", "转发/播放比：", SVT);
                ini.IniWriteValue("Bilibili 视频数据", "评论/播放比：", RVT);

                SaveFile(loc + locINI, Program.savedir + "AV" + aid + " 的视频数据.ini");
            }
        }

        private void GoToPG_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://b23.tv/" + bvid);
        }

        private void SetDir_Click(object sender, EventArgs e)
        {
            SetDirForm sdf = new SetDirForm();
            sdf.ShowDialog();
        }

        public static string StrRight(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }

        public static void SaveFile(string input, string output)
        {
            if (File.Exists(output))
            {
                DialogResult dr = MessageBox.Show("文件已存在！是否覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    File.Copy(input, output, true);
                }
            }
            else
            {
                File.Copy(input, output, false);
            }
        }
    }

    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public int ttl { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string bvid { get; set; }
        public int aid { get; set; }
        public int videos { get; set; }
        public int tid { get; set; }
        public string tname { get; set; }
        public int copyright { get; set; }
        public string pic { get; set; }
        public string title { get; set; }
        public int pubdate { get; set; }
        public int ctime { get; set; }
        public string desc { get; set; }
        public Owner owner { get; set; }
        public Stat stat { get; set; }
        public string dynamic { get; set; }
        public int cid { get; set; }
        public List<Pages> pages { get; set; }
    }
    public class Owner
    {
        public int mid { get; set; }
        public string name { get; set; }
        public string face { get; set; }
    }
    public class Stat
    {
        public int view { get; set; }
        public int danmaku { get; set; }
        public int reply { get; set; }
        public int favorite { get; set; }
        public int coin { get; set; }
        public int share { get; set; }
        public int now_rank { get; set; }
        public int his_rank { get; set; }
        public int like { get; set; }
    }
    public class Pages
    {
        public int cid { get; set; }
        public int page { get; set; }
        public string from { get; set; }
        public string part { get; set; }
    }
    public class Subtitle
    {
        public string allow_submit { get; set; }
        public List<List> list { get; set; }
    }
    public class List
    {
        public int id { get; set; }
        public string lan { get; set; }
        public string lan_doc { get; set; }
        public bool is_lock { get; set; }
        public string subtitle_url { get; set; }
    }
}
