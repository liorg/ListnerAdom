using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace rssYnet.Util
{
   public static class Utils
    {

       public static  string[] keySearchSplitter(string s)
        {
           // List<string> keySearch = new List<string>();
            //var pattern = @"\|\| | \&\& ";
            //var pattern = @"\+";
            //    var s = "lior && dd || ttt llll || 222 x && ss || ss";
           // var data = s.Split(new[] { "&&", "||" }, StringSplitOptions.None).ToList();
            //var data = s.Split(new[] { "+"}, StringSplitOptions.None).ToList();
            return s.Split(new[] { "+" }, StringSplitOptions.None);
            
            
            //Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            //MatchCollection matches = rgx.Matches(s);
            //var ch = data.GetEnumerator();
            //var opeartor = matches.GetEnumerator();
            //while (ch.MoveNext())
            //{
            //    if (!String.IsNullOrWhiteSpace(ch.Current))
            //    {
            //        keySearch.Add(ch.Current);
            //        bool isMoveNextOpeartor = opeartor.MoveNext();
            //        if (isMoveNextOpeartor)
            //            keySearch.Add(opeartor.Current.ToString());
            //    }
            //    else
            //        opeartor.MoveNext();
            //}
            //return keySearch.ToArray();
        }
    }
}
