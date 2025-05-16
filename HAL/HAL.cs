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
            int max = 0;
            string longestWord = string.Empty;
            // Split the dictionary into words and store them in a HashSet for fast lookup
            HashSet<string> words = new HashSet<string>(dict.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            HashSet<(string, string, int, int)> uniquePairs = new HashSet<(string, string, int, int)>();

            // Iterate through each possible shift (1 to 25)
            for (int j = 1; j < 26; j++)
            {
                foreach (string word in words.AsParallel())
                {
                    var shifted = new StringBuilder(word.Length);

                    foreach (char c in word)
                    {
                        if (char.IsLetter(c))
                            // Shift the character by j positions in the alphabet
                            shifted.Append((char)((c - 'a' + j) % 26 + 'a'));
                        else
                            shifted.Append(c);
                    }

                    string shiftedWord = shifted.ToString();

                    if (words.Contains(shiftedWord))
                    {
                        // Store word pairs in a consistent order, along with both shift directions
                        if (word.CompareTo(shiftedWord) < 0)
                            uniquePairs.Add((word, shiftedWord, j, 26 - j));
                        else
                            uniquePairs.Add((shiftedWord, word, 26 - j, j));

                        if (shiftedWord.Length > max)
                        {
                            max = shiftedWord.Length;
                            longestWord = shiftedWord;
                        }
                    }
                }
            }

            var longestPair = uniquePairs.FirstOrDefault(pair => pair.Item2 == longestWord || pair.Item1 == longestWord);
            if (longestPair != default)
            {
                Console.WriteLine($"Longest word pair: {longestPair.Item1} - {longestPair.Item2} | Shift: {longestPair.Item3} forward, {longestPair.Item4} backward");
            }

            // Print unique word pairs with shift values
            foreach (var pair in uniquePairs)
            {
                Console.WriteLine($"{pair.Item1} - {pair.Item2} | Shift: {pair.Item3} forward, {pair.Item4} backward");
            }
        }
    }
}