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
            char[] validSeparators = { '.', ',' };

            return input.All(c => char.IsDigit(c) || validSeparators.Contains(c))
                   && input.Count(c => validSeparators.Contains(c)) <= 1; 
        }
    }
}
