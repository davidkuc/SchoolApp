using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp2.Enums
{
    public static class EnumHelper
    {
        public static IEnumerable<string> GetActivityForms()
        {
            var b = Enum.GetNames(typeof(ActivityFormEnum));
            foreach (var a in b)
            {
                yield return a.ToString();
            }
        }

        public static IEnumerable<string> GetCodes()
        {
            var b = Enum.GetNames(typeof(CodeEnum));
            foreach (var a in b)
            {
                yield return a.ToString();
            }
        }

    }
}
