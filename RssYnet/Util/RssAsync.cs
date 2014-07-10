using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace rssYnet.Util
{
    public class RssAsync
    {
        string _rssUrl; private string _Title;
        /// <summary>
        /// Gets the title of the RSS feed.
        /// </summary>
        public string Title
        {
            get { return _Title; }
        }

        private string _Description;
        /// <summary>
        /// Gets the description of the RSS feed.
        /// </summary>
        public string Description
        {
            get { return _Description; }
        }

        private DateTime _LastUpdated;
        private Collection<RssItem> _Items = new Collection<RssItem>();
        /// <summary>
        /// Gets all the items in the RSS feed.
        /// </summary>
        public Collection<RssItem> Items
        {
            get { return _Items; }
        }
        public RssAsync(string rssUrl)
        {
            _rssUrl = rssUrl;
        }

        public async void Excute()
        {
            var client = new HttpClient();
            string xmlPage = await client.GetStringAsync(_rssUrl);

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

        /// <summary>
        /// Parses the XmlNode with the specified XPath query 
        /// and assigns the value to the property parameter.
        /// </summary>
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

