using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HAL
{
    class HAL
    {
        static void Main()
        {
            // Load the dictionary from the embedded resource
            // Note: The dictionary should be a text file with one word per line
            string dict = Properties.Resources.dict;
            // Split the dictionary into words and store them in a HashSet for fast lookup
            HashSet<string> words = new HashSet<string>(dict.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            List<WordPair> wordPairs = new List<WordPair>();

            // Initialize variables to track the longest shifted word
            int max = 0;
            string longestWord = "";

            // Iterate through each possible shift (1 to 25)
            for (int j = 1; j < 26; j++)
            {
                foreach (string word in words.AsParallel())
                {
                    var shifted = new StringBuilder(word.Length);

                    foreach (char c in word)
                    {
                        if (char.IsLetter(c))
                            shifted.Append((char)((c - 'a' + j) % 26 + 'a'));
                        else
                            shifted.Append(c);
                    }

                    // Convert the shifted StringBuilder to a string
                    string shiftedWord = shifted.ToString();

                    // Check if the shifted word is in the dictionary
                    if (words.Contains(shiftedWord))
                    {
                        wordPairs.Add(new WordPair(word, shiftedWord, j));

                        if (shiftedWord.Length > max)

                        {
                            max = shiftedWord.Length;
                            longestWord = shiftedWord;
                        }
                    }
                }
            }
            // Print the longest shifted word found
            Console.WriteLine($"Longest shifted word: {longestWord} with length {max}");

            // Print all word pairs found
            foreach (var pair in wordPairs)
            {
                Console.WriteLine(pair.ToString());
            }
        }
    }
}