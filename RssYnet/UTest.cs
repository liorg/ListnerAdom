using rssYnet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssYnet
{
    public partial class UTest : Form
    {
        string _subPathWav = @"resources\test.wav"; string _fullPathWave;

        private Task _taskPlayAsync;

        // Task _taskPlayAsync;
        CancellationTokenSource _cts1;

        public UTest()
        {
            _fullPathWave = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPathWav);

            _cts1 = new CancellationTokenSource();
            InitializeComponent();
            _simpleSound = new SoundPlayer(_fullPathWave);
            //  var token = _cts1.Token;
            //  _taskPlayAsync = Task.Factory.StartNew(() => PlaySound(token, 10), token);
            //   _taskPlayAsync = new Task(() => PlaySound(_token, 10), token);


        }
        SoundPlayer _simpleSound; Task _runAzaka;

        CancellationTokenSource _ts = new CancellationTokenSource();

        private void button1_Click(object sender, EventArgs e)
        {

            //for (int i = 0; i < 10; i++)
            //{
            //  simpleSound.Play(

            // _simpleSound.PlayLooping();
            // }
            _runAzaka = Task.Run(() =>
            {
                int i = 0;
                //Capture the thread
                while (i < 10)
                {
                    _simpleSound.Play();
                    Thread.Sleep(1000);
                    i++;
                }

                //Simulate work (usually from 3rd party code)
                Thread.Sleep(1000);

                //If you comment out thread.Abort(), then this will be displayed
                Console.WriteLine("Task finished!");
            });

            MessageBox.Show("ddd");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // _simpleSound.Stop();
            //if (_cts1 != null)
            //    _cts1.Cancel();

        }
        private void UTest_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //    if(_taskPlayAsync==null)
            //       _taskPlayAsync = new Task(() => PlaySound(_cts1.Token, 10), _cts1.Token);
            //if(_taskPlayAsync.Status==TaskStatus.Canceled)
            //    _taskPlayAsync.sto
            //if (_taskPlayAsync ==null ||(_taskPlayAsync != null && _taskPlayAsync.IsCompleted))
            //_taskPlayAsync = Task.Factory.StartNew(() => PlaySound(10));

            //  _taskPlayAsync.Start();

            if (!((_taskPlayAsync != null) && (_taskPlayAsync.IsCompleted == false ||
                           _taskPlayAsync.Status == TaskStatus.Running ||
                           _taskPlayAsync.Status == TaskStatus.WaitingToRun ||
                           _taskPlayAsync.Status == TaskStatus.WaitingForActivation)))
            {

                _taskPlayAsync = Task.Factory.StartNew(() => PlaySound(10));
            }
        }

        void PlaySound(int n)
        {
            try
            {

                if (_simpleSound == null)
                {
                    _simpleSound = new SoundPlayer();
                }

                for (; n > 0; n--)
                {
                    //if(ct.IsCancellationRequested)
                    //    return;
                    // ct.ThrowIfCancellationRequested();
                    _simpleSound.Play();
                    Thread.Sleep(1000);
                }
            }
            catch
            {


            }



            //int i = 0;
            ////Capture the thread
            //while (i < n)
            //{
            //    _simpleSound.Play();
            //    Thread.Sleep(1000);
            //    i++;
            //}

            //Simulate work (usually from 3rd party code)
            Thread.Sleep(1000);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _subPathFilter = @"resources\filterTemp.json";
            var _filterPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPathFilter);

            var jsonFilter = System.IO.File.ReadAllText(_filterPath);
            var _keywords = SerializeObject.JsonDeserializeToObject<string[]>(jsonFilter);
            int _rowid = 0;
            OrefModel oref = new OrefModel();
            oref.id = "1";
            oref.title = "dd";

            List<string> daList = new List<string>();
            daList.Add(null);
            daList.Add("שפלה 174");
            daList.Add("שפלה 168");
            daList.Add("שפלה 183");
            daList.Add("דן 157");
            daList.Add("שפלה 173");
            daList.Add("דן 160");
            daList.Add(null);
            oref.data = daList.ToArray();

            if (oref != null && oref.data != null && oref.data.Length > 0 )
            {
                var message = new MessageAlert { Id = oref.id, Index = _rowid, Title = oref.Fields, Data = oref.data, DateItem = DateTime.Now };
                if (_keywords != null && _keywords.Any())
                {
                    foreach (var key in _keywords)
                    {
                        var isSearch = oref.data.Where(d =>!String.IsNullOrEmpty(d) && d.Trim() == key).Any();
                        message.IsSearch = isSearch;
                        //if (isSearch)
                        //    break;
                        //var isSearch = oref.data.Where(d => d.Trim().GetHashCode() == key.GetHashCode()).Any();
                        //message.IsSearch = isSearch;
                        //if (isSearch)
                        //    break;
                    }
                }

                //_Items.Add(message);
                //_rowid++;
                //if (Listner != null)
                //    Listner(message);
            }
        }
    }
}
