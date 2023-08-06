using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class MainFormUtilities
    {
        public static bool IsValidDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }
    }
}
