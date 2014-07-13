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
    public partial class RssEventSearch : Form
    {

        static object o = new object();
        bool isPlay = false;
        RssSearchKeys rss;
        string[] _searchKey = null;
        int _interval;
        string _rssUrl;

        public RssEventSearch()
        {
            InitializeComponent();
        }

        private void rss_Listner(MessageItem obj)
        {
            lock (o)
            {
                listBox1.Items.Insert(0, obj);
                if (obj.IsSearch)
                {
                    notifyIcon1.BalloonTipText = obj.Title;
                    notifyIcon1.BalloonTipTitle = "תוצאת חיפוש" + "[" + obj.DateItem.ToString() + "]";
                    notifyIcon1.ShowBalloonTip(500);
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                }
            }

        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            SearchCategory category = new SearchCategory();
           // category
            Excute();
        }

        void Excute()
        {
            rss.Rss = _rssUrl;
            if (!isPlay)
            {
                rss.Stop();
                isPlay = true;
                btnExcute.Text = "הפעל";
                toolStripExcute.Text = "הפעל";
                searchToolStripMenuItem.Enabled = true;
                configurationToolStripMenuItem.Enabled = true;
            }
            else
            {
                if (_searchKey == null || !_searchKey.Any())
                {
                    MessageBox.Show("יש לבחור חיפוש");
                    return;
                }
                rss.Play(_interval, _searchKey);
                listBox1.Items.Clear();
                btnExcute.Text = "עצור"; toolStripExcute.Text = "עצור";
                isPlay = false;
                searchToolStripMenuItem.Enabled = false;
                configurationToolStripMenuItem.Enabled = false;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch(_searchKey);
            DialogResult res = search.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                _searchKey = search.Items.ToArray();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxLiorGrossman l = new AboutBoxLiorGrossman();
            l.ShowDialog();
        }

        private void RssEventSearch_Load(object sender, EventArgs e)
        {
            //  _searchKey = new string[] { "אזעקה גוש דן", "אזעקה", "אזעקת גוש דן" };
            _searchKey = new string[] { 
                "אזעקה | אזעקות| אזעקת | צבע אדום",
               " אזעקה | אזעקת + תל אביב| פתח תקווה| בני ברק |רמת גן | תל-אביב | תל - אביב |גוש דן"
           ," אזעקה | אזעקת + אשקלון| אזור התעשיה אשקלון"
             ," אזעקה | אזעקת + מועצת |מועצה + אשכול "
             ,"אזעקה | אזעקת + אשדוד"
                 ,"אזעקה | אזעקת + ראשון לציון| רשל\"צ | חולון |בת ים|בת-ים|בת - ים| גוש דן "
           };

            //   _searchKey = new string[] {   "  אזעקה | אזעקת + תל אביב| פתח תקווה| בני ברק |רמת גן | תל-אביב | תל - אביב  " };

            _interval = 2; 
            isPlay = true;
            _rssUrl = "http://rss.walla.co.il/?w=/1/22/0/@rss";// "http://www.ynet.co.il/Integration/StoryRss1854.xml";
            rss = new RssSearchKeys(_rssUrl);
            rss.Listner += rss_Listner;
            Excute();

        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config conf = new Config(_interval, _rssUrl);
            if (conf.ShowDialog() == DialogResult.OK)
            {
                _rssUrl = conf.RssFeed;
                _interval = conf.Interval;
            }
        }

        private void toolStripExcute_Click(object sender, EventArgs e)
        {
            Excute();
        }

        private void RssEventSearch_Resize(object sender, EventArgs e)
        {
            Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void toolShow_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void יציאהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
