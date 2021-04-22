using System;
using System.Collections.Generic;
using System.Text;

namespace ISBN
{
    public static class ISBNInputValidator
    {
        public static string Filter(string input)
        {
            List<char> charsToRemove = new List<char>() { '@', '_', ',', '.', '-', '%', '#', '!', '*', '&', '$' };

            foreach (char c in charsToRemove)
            {
                input = input.Replace(c.ToString(), String.Empty);
            }

            return input.Trim();
        }
    }
}
