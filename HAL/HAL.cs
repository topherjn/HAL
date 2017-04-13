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
            int max = 0;
            string longestWord = String.Empty;

            // break up into an array of strings
            char[] delimiters = new char[] { '\r', '\n' };
            string[] lines = dict.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // insert each word into a binary tree
            SortedDictionary<string, string> d = new SortedDictionary<string, string>();

            foreach(var word in lines)
            {
                d.Add(word, word);
            }

            //foreach(var pair in d)
            //{
            //    Console.WriteLine(pair.Key + " " + pair.Value);
            //}

            // number of times to shift
            for(int j = 1; j < 26; j++)
            {
                // for each dictionary entry
                foreach(var pair in d)
                {
                    // create a string builder
                    StringBuilder shift = new StringBuilder();
                    string word = pair.Value;

                    // convert the word into an array of characters
                    char[] letters = word.ToCharArray();

                    // iterate over all the characters in the word
                    for(int i = 0; i < letters.Length; i++)
                    {
                        int letter = (int)letters[i];

                        if (letter + j > 'z') letter -= (26 - j);
                        else letter += j;

                        letters[i] = (char)letter;
                        shift.Append(letters[i]);
                    }

                    if(d.ContainsKey(shift.ToString()))
                    {
                        if(shift.Length > max)
                        {
                            max = shift.Length;
                            longestWord = shift.ToString();
                        }
                        Console.WriteLine("Shifted by {2}: {0} {1}", word, shift, j);
                    }
                }
            }

            Console.WriteLine("{0} is the longest word at a length of {1}", longestWord, longestWord.Length);
        }
    }
}

