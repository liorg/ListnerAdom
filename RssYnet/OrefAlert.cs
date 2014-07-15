using rssYnet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssYnet
{
    public partial class OrefAlert : Form
    {
        static object o = new object();
        Locations _locations;
        bool isPlay = false;
        string _subPath = @"resources\data.json";
        string[] _keywords;
        int _interval;
        JsonAsync _alert; 
        string _rssUrl = "http://www.oref.org.il/WarningMessages/alerts.json";
        public OrefAlert()
        {
            InitializeComponent();
            _interval = 2; 

            _alert = new JsonAsync(_rssUrl);
            _alert.Listner += Alert_Listner;
            _alert.Log += Alert_Log;
        }

        void Alert_Log(string obj)
        {
            lstLog.Items.Insert(0, DateTime.Now.ToString() +obj);
        }

        void Alert_Listner(MessageAlert obj)
        {
            lock (o)
            {
                listBox1.Items.Insert(0, obj);
                notifyIcon1.BalloonTipText = Transalte(obj.Data);
                notifyIcon1.BalloonTipTitle = "אזעקת צבע אדום" + "[" + obj.DateItem.ToString() + "]";
                if (obj.IsSearch)
                {

                    notifyIcon1.ShowBalloonTip(3000);
                     Console.Beep();
                     Console.Beep(); Console.Beep(); Console.Beep(); Console.Beep();
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(500);
                    Console.Beep();
                  
                }
            }

        }

        string Transalte(string[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                try
                {
                    if (_locations.YeshovimLocations.ContainsKey(item))
                    {
                        var j = string.Join(",",_locations.YeshovimLocations[item].ToArray());
                        sb.AppendLine(j);
                    }
                    else
                       sb.AppendLine(item);
                    
                }
                catch 
                {
                    sb.AppendLine(item);
                }
            }

            return sb.ToString();
            
        }

        void Excute()
        {
            _alert.RssUrl = _rssUrl;
            if (!isPlay)
            {
                _alert.Stop();
                isPlay = true;
                btnExcute.Text = "הפעל";
                toolStripExcute.Text = "הפעל";
                toolFilter.Enabled = true;
                configurationToolStripMenuItem.Enabled = true; toolStripStatusLabel1.Text = "לא מאזין";
            }
            else
            {
                
                _alert.Play(_interval,_keywords);
                listBox1.Items.Clear();
                btnExcute.Text = "עצור"; 
                toolStripExcute.Text = "עצור";
                isPlay = false;
                toolFilter.Enabled = false; toolStripStatusLabel1.Text = " מאזין";
               configurationToolStripMenuItem.Enabled = false;
            }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void OrefAlert_Load(object sender, EventArgs e)
        {
           
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            isPlay = true;
            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);
            var json = System.IO.File.ReadAllText(fullPath);
            _locations = SerializeObject.JsonDeserializeToObject<Locations>(json);
           
            Excute();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form=this;
            // force window to have focus
            uint foreThread =win32.GetWindowThreadProcessId(win32.GetForegroundWindow(), IntPtr.Zero);
            uint appThread = win32.GetCurrentThreadId();
            const uint SW_SHOW = 5;
            if (foreThread != appThread)
            {
                win32.AttachThreadInput(foreThread, appThread, true);
                win32.BringWindowToTop(form.Handle);
                win32.ShowWindow(form.Handle, SW_SHOW);
               win32. AttachThreadInput(foreThread, appThread, false);
            }
            else
            {
               win32.BringWindowToTop(form.Handle);
                win32.ShowWindow(form.Handle, SW_SHOW);
            }
            form.Activate();
            //Show();
            //this.TopMost = true; BringToFront();
          
            //Focus();
         
     
        }

        private void OrefAlert_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }

        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripExcute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void יציאהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxLiorGrossman l = new AboutBoxLiorGrossman();
            l.ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrefConfig conf = new OrefConfig(_interval, _rssUrl);
            if (conf.ShowDialog() == DialogResult.OK)
            {
                _rssUrl = conf.RssFeed;
                _interval = conf.Interval;
            }
        }

        private void OrefAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Hide();
            }
            }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           var alert= listBox1.SelectedItem as MessageAlert;
           if (alert != null)
            {

                var tran = Transalte(alert.Data);
              MessageBox.Show(alert.DateItem+"=>"+tran )  ;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolFilter_Click(object sender, EventArgs e)
        {
            AddFilters filters = new AddFilters(_locations,_keywords);
            if (filters.ShowDialog() == DialogResult.OK){
              _keywords = filters.Search.ToArray();
              var search = string.Join(",", _keywords); ;
           //   lblFilter.Text = search;
              toolStripStatusLabel2.Text = search;
            }

            
        }

       
      
    }
}
