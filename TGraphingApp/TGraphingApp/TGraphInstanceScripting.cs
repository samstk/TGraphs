using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGraphingApp
{
    public static class TGraphInstanceScripting
    {
        public const int MAX_RENDER_POINTS = 6000;

        public static readonly CSharpCodeProvider Provider = new CSharpCodeProvider();

        public const string SCRIPT_HEADER =
@"
using System;
using System.Collections.Generic;

    public static class TExpression {
        public static object Calculate(double t) {
";

        public const string SCRIPT_FOOTER =
@"
        }

        public static object[] CalculateForAll(double[] t) {
            object[] results = new object[t.Length];
            for (int i = 0; i < t.Length; i++) {
                results[i] = Calculate(t[i]);
            }
            return results;
        }

        public static void Main() { }
    }
";
    }
}
