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
        string _rssUrl; private string _Title;
    
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
            string xmlPage ="";
            using (XmlReader reader = XmlReader.Create(_rssUrl, new XmlReaderSettings() { Async = true }))
            {


              await reader.MoveToContentAsync();
             //  await  reader.ReadAsync(); 

                xmlPage = await reader.ReadOuterXmlAsync();
           
                
                
         

            }
          ////  var client = new HttpClient();
          //  //var st = await client.GetStreamAsync(_rssUrl);
          //  byte[] stream;
          //  //string xmlPage = await client.GetStringAsync(_rssUrl);
          //  string xmlPage;
          //  using (HttpClient client = new HttpClient())
          //  {
          //      client.DefaultRequestHeaders.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
          //      client.DefaultRequestHeaders.Add("Accept", "*/*");
          //      client.DefaultRequestHeaders.Add("Accept-Language", "en-gb,en;q=0.5;");
          //      //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          //      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
          //      using (HttpResponseMessage response = await client.GetAsync(_rssUrl))
          //      using (HttpContent content = response.Content)
          //      {

          //         // stream = await content.ReadAsByteArrayAsync();

          //          // ... Read the string.
          //           xmlPage = await content.ReadAsStringAsync();


          //      }
          //  }
          // xmlPage= System.Text.UTF8Encoding.UTF8.GetString(stream);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlPage);

            ParseElement(doc.SelectSingleNode("//channel"), "title", ref _Title);
            ParseElement(doc.SelectSingleNode("//channel"), "description", ref _Description);
            ParseItems(doc);

            _LastUpdated = DateTime.Now;

            var xml = XElement.Parse(xmlPage);

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

