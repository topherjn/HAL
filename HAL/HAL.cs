using System;
using System.Text;
using System.Collections.Generic;


namespace HAL
{
    class HAL
    {
        static void Main(string[] args)
        {
            // import the entire dictionary into one string
            string dict = Properties.Resources.dict;

            // break up into an array of strings
            char[] delimiters = new char[] { '\r', '\n' };
            string[] lines = dict.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // insert each word into a binary tree
            SortedDictionary<string, string> d = new SortedDictionary<string, string>();

            foreach(var word in lines)
            {
                d.Add(word, word);
            }

            foreach(var pair in d)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
        
        }

    }
}

