using rssYnet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using rssYnet.Util.exstention;
namespace rssYnet
{
    public partial class OrefAlert : Form
    {
        static object o = new object();
        Locations _locations;
        SoundPlayer _azahakaSound;
        bool isPlay = false;
        string _subPath = @"resources\data.json";
        string _subPathWav = @"resources\ding.wav";
        string _subPathFilter = @"resources\filterTemp.json";
        string _subPathSetting = @"resources\Setting.json";
        Task _taskPlayAsync;
        const int _timeLoopPlayer = 20;

        string[] _keywords;
        int _interval;
        JsonAsync _alert;
        string _rssUrl = "http://www.oref.org.il/WarningMessages/alerts.json";
        string _filterPath;
        bool _isBeep;
        string _fullPathWave;
     

        public OrefAlert()
        {
            InitializeComponent();
            _interval = 2;
            _fullPathWave = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPathWav);
            _filterPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPathFilter);

            _azahakaSound = new SoundPlayer(_fullPathWave);

            _alert = new JsonAsync(_rssUrl);
            _alert.Listner += Alert_Listner;
            _alert.Log += Alert_Log;
        }

        void Alert_Log(string obj)
        {
            lstLog.Items.Insert(0, DateTime.Now.ToString() + obj);
        }
      
        void Alert_Listner(MessageAlert obj)
        {
            lock (o)
            {
                listBox2.Items.Insert(0, obj);
                notifyIcon1.BalloonTipText = Transalte(obj.Data);
                notifyIcon1.BalloonTipTitle = "אזעקת צבע אדום" + "[" + obj.DateItem.ToString() + "]";
                if (obj.IsSearch)
                {

                    notifyIcon1.ShowBalloonTip(3000);
                    Console.Beep();
                    //if (_azahakaSound == null)
                    //    _azahakaSound = new SoundPlayer(_fullPathWave);
                    Console.Beep();

                    if (!((_taskPlayAsync != null) && (_taskPlayAsync.IsCompleted == false ||
                                   _taskPlayAsync.Status == TaskStatus.Running ||
                                   _taskPlayAsync.Status == TaskStatus.WaitingToRun ||
                                   _taskPlayAsync.Status == TaskStatus.WaitingForActivation)))
                    {

                        _taskPlayAsync = Task.Factory.StartNew(() => PlaySound(_timeLoopPlayer));
                    }
                  
                  //  _azahakaSound.Play();
                   //  _azahakaSound.PlayLooping();
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(500);
                    if (_isBeep)  
                        Console.Beep();
                }
            }
        }

        string Transalte(string[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var itemOref in data)
            {
                try
                {
                    //var itemMer ="מרחב "+ item;
                    var itemMer = itemOref.RemoveMer();
                    //if (_locations.YeshovimLocations.ContainsKey(item) || _locations.YeshovimLocations.ContainsKey(itemMer))
                    if (_locations.YeshovimLocations.ContainsKey(itemMer))
                   // if(_locations.YeshovimLocations.Keys.Where(k=>k.LastIndexOf(item)).Count>0)
                    {
                        var j = string.Join(",", _locations.YeshovimLocations[itemMer].ToArray());

                        sb.AppendLine(j);
                    }
                    else
                        sb.AppendLine(itemMer);

                }
                catch
                {
                    sb.AppendLine(itemOref);
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

                _alert.Play(_interval, _keywords);
                if (listBox2.Items != null)
                    listBox2.Items.Clear();
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
          //  _azahakaSound.Play();
            if (File.Exists(_filterPath))
            {
                var jsonFilter = System.IO.File.ReadAllText(_filterPath);
                _keywords = SerializeObject.JsonDeserializeToObject<string[]>(jsonFilter);
                toolStripStatusLabel2.Text = string.Join(",", _keywords);
            }
            var json = System.IO.File.ReadAllText(fullPath);
            _locations = SerializeObject.JsonDeserializeToObject<Locations>(json);

            Excute();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = this;
            // force window to have focus
            uint foreThread = win32.GetWindowThreadProcessId(win32.GetForegroundWindow(), IntPtr.Zero);
            uint appThread = win32.GetCurrentThreadId();
            const uint SW_SHOW = 5;
            if (foreThread != appThread)
            {
                win32.AttachThreadInput(foreThread, appThread, true);
                win32.BringWindowToTop(form.Handle);
                win32.ShowWindow(form.Handle, SW_SHOW);
                win32.AttachThreadInput(foreThread, appThread, false);
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
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
            OrefConfig conf = new OrefConfig(_interval, _rssUrl,_isBeep);
            if (conf.ShowDialog() == DialogResult.OK)
            {
                _rssUrl = conf.RssFeed;
                _interval = conf.Interval;
                _isBeep = conf.iSbeep;
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

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            var alert = listBox2.SelectedItem as MessageAlert;
            if (alert != null)
            {
                var tran = Transalte(alert.Data);
                MessageBox.Show(alert.DateItem + "=>" + tran);
            }
        }

        private void toolFilter_Click(object sender, EventArgs e)
        {
            AddFilters filters = new AddFilters(_locations, _keywords);
            if (filters.ShowDialog() == DialogResult.OK)
            {
                _keywords = filters.Search.ToArray();
                toolStripStatusLabel2.Text = string.Join(",", _keywords);
                var toJsonType = SerializeObject.JsonSerializeObject(_keywords);
                File.WriteAllText(_filterPath, toJsonType);
            }
        }

        private void stopHazaka_Click(object sender, EventArgs e)
        {
            if (_azahakaSound != null)
                _azahakaSound.Stop();
        }

        private void PlaySound(int n)
        {
            try
            {

                if (_azahakaSound == null)
                  _azahakaSound = new SoundPlayer(_fullPathWave);
                

                for (; n > 0; n--)
                {
                    //if(ct.IsCancellationRequested)
                    //    return;
                    // ct.ThrowIfCancellationRequested();
                    _azahakaSound.Play();
                    Thread.Sleep(1000);
                }
            }
            catch
            {

            }
            Thread.Sleep(1000);

        }
    }
}
