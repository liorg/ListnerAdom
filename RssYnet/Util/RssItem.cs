using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util
{

    #region RssItem struct

    /// <summary>
    /// Represents a RSS feed item.
    /// </summary>
    [Serializable]
    public struct RssItem
    {
        
        /// <summary>
        /// The publishing date.
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// The title of the item.
        /// </summary>
        public string Title;

        /// <summary>
        /// A description of the content or the content itself.
        /// </summary>
        public string Description;

        /// <summary>
        /// The link to the webpage where the item was published.
        /// </summary>
        public string Link;
    }

    #endregion
}
