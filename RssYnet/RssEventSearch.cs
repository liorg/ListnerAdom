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
            _rssUrl = "http://www.ynet.co.il/Integration/StoryRss1854.xml";
            rss = new RssSearchKeys(_rssUrl);
            rss.Listner += rss_Listner;
            Excute();
        }

        private void rss_Listner(MessageItem obj)
        {
            lock (o)
            {
                listBox1.Items.Insert(0, obj);
            }

        }
       
        private void btnExcute_Click(object sender, EventArgs e)
        {
            Excute();

        }


        void Excute()
        {
            rss.Rss = _rssUrl;
            // if (btnExcute.Text == "עצור")
            if (!isPlay)
            {
                // txtSearch.Enabled = false;
                rss.Stop();
                isPlay = true;
                btnExcute.Text = "הפעל";
                toolStripExcute.Text = "הפעל";


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
            liorgrossman l = new liorgrossman();
            l.ShowDialog();
        }

        private void RssEventSearch_Load(object sender, EventArgs e)
        {
            _searchKey = new string[] { "אזעקה גוש דן", "אזעקה", "אזעקת גוש דן" };
            _interval = 2;
          
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

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
}
