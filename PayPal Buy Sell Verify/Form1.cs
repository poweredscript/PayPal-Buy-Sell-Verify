using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PayPal_Buy_Sell_Verify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonFacebookMessageCheck.Enabled = false;
            
        }
        List<string> _verifyList = new List<string>();
        [STAThread]
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            buttonCheck.Enabled = false;
            buttonFacebookMessageCheck.Enabled = false;
           
            //labelReport.Text = @"";
            labelReport.Invoke(new MethodInvoker(delegate
            {
                labelReport.ForeColor = Color.Black;
                labelReport.Text = @"กำลังตรวจสอบ โปรดรอสักครู่.";
            }));


            Uri uriResult;
            bool isUrl = Uri.TryCreate(textBox1.Text, UriKind.Absolute, out uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            string upperId;
            if (isUrl)
            {
                upperId = textBox1.Text;
                buttonCheck.Enabled = true;
            }
            else
            {
                upperId = textBox1.Text.ToUpper();

                if (!upperId.StartsWith("PP"))
                {
                    upperId = "PP" + upperId;
                }
                if (!upperId.EndsWith("A"))
                {
                    upperId = upperId + "A";
                }
                if (upperId.Length != 7)
                {
                    labelReport.ForeColor = Color.Orange;
                    labelReport.Text = @"โปรดกรอกข้อมูล ช่อง ID ให้ถูกต้อง เช่น 0123 หรือ PP0123A";
                    buttonCheck.Enabled = true;
                    return;
                }
            }
            try
            {
                labelReport.Text = @"กำลังตรวจสอบ โปรดรอสักครู่..";
                if (_verifyList.Count <= 0)
                {
                    GetVerifyList();
                }
            }
            catch (Exception ex)
            {
                labelReport.ForeColor = Color.Orange;
                labelReport.Text = ex.Message;
                buttonCheck.Enabled = true;
                buttonCheck.Enabled = true;
                return;
            }
            labelReport.Text = @"กำลังตรวจสอบ โปรดรอสักครู่...";
            if (_verifyList.Count < 100)
            {
                labelReport.ForeColor = Color.Orange;
                labelReport.Text = @"ไม่สามารถดาวโหลดรายชื่อ โปรดตรวจสอบการเชื่อมต่ออินเตอร์เน็ต";
                buttonCheck.Enabled = true;
                _verifyList = new List<string>();
                return;
            }
            //MessageBox.Show(_verifyList);
            var profileUrlName2 = textBox1.Text.Contains("?id=") ? Regex.Match(textBox1.Text, @"(?<=\?id=).*?(?=(\&|\?))").Value : Regex.Match(textBox1.Text, @"(?<=\.com\/).*?(?=(\&|\?))").Value;
            if (profileUrlName2 == "")
            {
                profileUrlName2 = Regex.Match(textBox1.Text, @"(?<=\.com\/).*", RegexOptions.IgnoreCase).Value;
            }

            bool found = false;
        
            foreach (var s in _verifyList)
            {

                var profileUrl = Regex.Match(s, @"(?<=href="").*?(?="")").Value;
                var profileUrlName = profileUrl.Contains("?id=") ? Regex.Match(profileUrl, @"(?<=\?id=).*?(?=(\&|\?))").Value : Regex.Match(profileUrl, @"(?<=\.com\/).*?(?=(\&|\?))").Value;

                if (isUrl)
                {
                    if (profileUrlName == profileUrlName2 && profileUrlName != "")
                    {
                        //MessageBox.Show(profileUrlName);
                        //MessageBox.Show(profileUrlName2);
                        found = true;
                        _profileMessageUrl = "https://www.facebook.com/messages/t/" + profileUrlName;
                        labelReport.Text = StripHtml(s);
                        labelReport.ForeColor = s.Contains("ปลด") ? Color.Red : Color.Green;
                        buttonFacebookMessageCheck.Enabled = true;
                        break;
                    }
                    
                }
                if (upperId != Regex.Match(s, @"PP.*?(?=\-)").Value) continue;
                // MessageBox.Show(profileUrl);
                // MessageBox.Show(profileUrlName);
                found = true;
                _profileMessageUrl = "https://www.facebook.com/messages/t/" + profileUrlName;
                labelReport.Text = StripHtml(s);
                labelReport.ForeColor = s.Contains("ปลด") ? Color.Red : Color.Green;
                buttonFacebookMessageCheck.Enabled = true;
                break;
            }
            if (!found)
            {
                labelReport.Text = @"ไม่พบ.";
                labelReport.ForeColor = Color.Black;
            }
            buttonCheck.Enabled = true;
        }
        public static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        public void GetVerifyList()
        {
            string sourceUrl = "https://drive.google.com/uc?export=download&id=0Byc1YSB3Sd7xTUxRS1YyYmRmOFU";
            var downloadStr = "";
            for (int i = 0; i < 5; i++)
            {
                using (var webpage = new WebClient())
                {
                    webpage.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    downloadStr = webpage.DownloadString(sourceUrl);
                }
                //MessageBox.Show(_verifyList.Length.ToString());
                if (downloadStr.Length > 1000)
                {
                    break;
                }
            }
            //MessageBox.Show(downloadStr);
            _verifyList = downloadStr.Replace("<br>", Environment.NewLine).Split('\n').ToList();
            //MessageBox.Show(string.Join("\r\n", _verifyList));
            if (_verifyList.Count > 100)
            {
                labelVerifyListUpdate.Invoke(new MethodInvoker(delegate
                {
                    labelVerifyListUpdate.Text = @"รายการ Verify อัพเดท " + _verifyList[0];
                    labelVerifyListUpdate.ForeColor = Color.DarkGreen;
                }));
            }
        }
        private string _profileMessageUrl;
        private void buttonFacebookMessageCheck_Click(object sender, EventArgs e)
        {
            Process.Start(_profileMessageUrl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            Text += " v" + version;
            var thread = new Thread(delegate()
            {
                try
                {
                    GetVerifyList();
                }
                catch (Exception ex)
                {

                    labelReport.Invoke(new MethodInvoker(delegate
                    {
                        labelReport.ForeColor = Color.Orange;
                        labelReport.Text = ex.Message;
                    }));

                    buttonCheck.Invoke(new MethodInvoker(delegate
                    {
                        buttonCheck.Enabled = true;
                    }));
                    _verifyList = new List<string>();
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            //thread.Join();
        }

        private void verifyListOpen_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/219354214894010/permalink/298543423641755/");
        }
    }
}
