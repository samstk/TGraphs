using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TGraphingApp
{
    public static class TGraphRegexExpressions
    {
        public static Regex DecimalNumberCharacters = new Regex(@"[0-9\.\-]+");
    }
}
