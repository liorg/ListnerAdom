using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util.exstention
{
    public static class csExs
    {
       public static string RemoveMer(this string s)
       {
          return s.Trim().Replace("מרחב", "").Trim();

       }
    }
}
