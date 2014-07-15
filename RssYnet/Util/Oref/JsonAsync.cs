using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util
{
    public class JsonAsync
    {
        string _rssUrl;
        int _rowid = 0;
        Collection<MessageAlert> _Items = new Collection<MessageAlert>();
        System.Windows.Forms.Timer _timer;
        public event Action<MessageAlert> Listner = null;
        public event Action<string> Log = null;
        string[] _keywords;

        public Collection<MessageAlert> Items
        {
            get { return _Items; }
        }

        public string RssUrl
        {
            get
            {
                return _rssUrl;
            }
            set
            {
                _rssUrl = value;
            }
        }

        public JsonAsync(string rssUrl)
        {
            _rssUrl = rssUrl;
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 1000;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Excute();
        }

        public async void Excute()
        {
            OrefModel oref = null;
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage response = await client.GetAsync(_rssUrl))
                    using (HttpContent content = response.Content)
                    {

                        var json = await content.ReadAsStringAsync();
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                        {
                            var serializer = new DataContractJsonSerializer(typeof(OrefModel));
                            oref = (OrefModel)serializer.ReadObject(ms);
                        }
                    }
                }
                catch (TaskCanceledException ex)
                {
                    if (Log != null)
                        Log(ex.Message);
                }
                catch (Exception e)
                {
                    if (Log != null)
                        Log(e.Message);
                }
            }
            if (oref != null && oref.data != null && oref.data.Length > 0 && !_Items.Where(d => d.Id.GetHashCode() == oref.id.GetHashCode()).Any())
            {
                var message = new MessageAlert { Id = oref.id, Index = _rowid, Title = oref.Fields, Data = oref.data, DateItem = DateTime.Now };
                if (_keywords != null && _keywords.Any())
                {
                    foreach (var key in _keywords)
                       message.IsSearch = oref.data.Where(d => d.Trim().GetHashCode() == key.GetHashCode()).Any();
                    
                }
                _Items.Add(message);
                _rowid++;
                if (Listner != null)
                    Listner(message);
            }
        }

        internal void Stop()
        {
            _timer.Enabled = false;
            _rowid = 0;
        }

        internal void Play(int interval, string[] keywords = null)
        {
            _keywords = keywords;
            _timer.Interval = interval * 1000;
            _timer.Enabled = true;
            _rowid = 0;
        }
    }
}
