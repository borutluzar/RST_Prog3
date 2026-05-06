using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public static class Extensions
    {
        public static int CountVowels(this string word)
        {
            List<char> lstVowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            int counter = 0;
            foreach(var ch in word)
            {
                if (lstVowels.Contains(char.ToLower(ch)))
                    counter++;
            }
            return counter;
        }
    }
}
