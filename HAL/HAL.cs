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
            foreach(var word in lines)
            {
                Console.WriteLine(word);
            }

            // take each word

            // shift each letter in the word by a number

            // see if there is a hit in the dictionary

            // if yes add to a list of hits



            // the followig console write demonstrates the success of the resource
            // import.  You will want to comment it out or delete it eventually
            Console.WriteLine(dict);

        }

    }
}

