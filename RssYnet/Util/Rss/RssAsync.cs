using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace rssYnet.Util
{
    public class RssAsync
    {
        string _rssUrl; 
        string _Title;
     
        public string Title
        {
            get { return _Title; }
        }

        private string _Description;
       
        public string Description
        {
            get { return _Description; }
        }

        private DateTime _LastUpdated;
        private Collection<RssItem> _Items = new Collection<RssItem>();
       
        public Collection<RssItem> Items
        {
            get { return _Items; }
        }

        public RssAsync(string rssUrl)
        {
            _rssUrl = rssUrl;
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

        public async void Excute()
        {  
            byte[] stream;

            using (var client = new HttpClient())
            {
                
                using (HttpResponseMessage response = await client.GetAsync(_rssUrl))
                using (HttpContent content = response.Content)
                {

                     stream = await content.ReadAsByteArrayAsync();
                }
            }
            using (var reader = XmlReader.Create(new MemoryStream(stream)))
            {

                var doc = new XmlDocument();
                doc.Load(reader);

                ParseElement(doc.SelectSingleNode("//channel"), "title", ref _Title);
                ParseElement(doc.SelectSingleNode("//channel"), "description", ref _Description);
                ParseItems(doc);

                _LastUpdated = DateTime.Now;

            }
        }

        private void ParseItems(XmlDocument doc)
        {
            _Items.Clear();
            XmlNodeList nodes = doc.SelectNodes("rss/channel/item");

            foreach (XmlNode node in nodes)
            {
                RssItem item = new RssItem();
                ParseElement(node, "title", ref item.Title);
                ParseElement(node, "description", ref item.Description);
                ParseElement(node, "link", ref item.Link);

                string date = null;
                ParseElement(node, "pubDate", ref date);
                DateTime.TryParse(date, out item.Date);

                _Items.Add(item);
            }
        }

     
        private void ParseElement(XmlNode parent, string xPath, ref string property)
        {
            XmlNode node = parent.SelectSingleNode(xPath);
            if (node != null)
                property = node.InnerText;
            else
                property = "Unresolvable";
        }
    }


}

