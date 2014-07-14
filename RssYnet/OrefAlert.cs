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
        bool isPlay = false; 
        string _searchKey;
        int _interval;
        JsonAsync _alert; 
        string _rssUrl = "http://www.oref.org.il/WarningMessages/alerts.json";
        public OrefAlert()
        {
            InitializeComponent();
            _interval = 2; _searchKey = "";

            _alert = new JsonAsync(_rssUrl);
            _alert.Listner += Alert_Listner;
        }

        void Alert_Listner(MessageAlert obj)
        {
            lock (o)
            {
                listBox1.Items.Insert(0, obj);
               // if (obj.IsSearch)
               // {
                    notifyIcon1.BalloonTipText = obj.VerticalMessage;
                    notifyIcon1.BalloonTipTitle = "אזעקת צבע אדום" + "[" + obj.DateItem.ToString() + "]";
                    notifyIcon1.ShowBalloonTip(500);
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
               // }
            }

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
                //searchToolStripMenuItem.Enabled = true;
                configurationToolStripMenuItem.Enabled = true;
            }
            else
            {
                //if (_searchKey == null || !_searchKey.Any())
                //{
                //    MessageBox.Show("יש לבחור חיפוש");
                //    return;
                //}
                _alert.Play(_interval, _searchKey);
                listBox1.Items.Clear();
                btnExcute.Text = "עצור"; 
                toolStripExcute.Text = "עצור";
                isPlay = false;
               // searchToolStripMenuItem.Enabled = false;
               configurationToolStripMenuItem.Enabled = false;
            }
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void OrefAlert_Load(object sender, EventArgs e)
        {
            isPlay = true;
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
    }
}
