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
            string dict = Properties.Resources.dict;
            HashSet<string> words = new HashSet<string>(dict.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));

            string shiftedWord;

            int max = 0;
            string longestWord = "";

            for (int j = 1; j < 26; j++)
            {
                foreach (string word in words.AsParallel()) // Parallelizing for efficiency
                {
                    var shifted = new StringBuilder(word.Length);

                    foreach (char c in word)
                    {
                        if (char.IsLetter(c))
                            shifted.Append((char)((c - 'a' + j) % 26 + 'a'));
                        else
                            shifted.Append(c);
                    }

                    shiftedWord = shifted.ToString();
                    if (words.Contains(shiftedWord))
                    {
                        Console.WriteLine($"Shifted by {j}: {word} -> {shiftedWord}");

                        if (shiftedWord.Length > max)

                        {
                            max = shiftedWord.Length;
                            longestWord = shiftedWord;
                        }
                    }
                }
            }
        }
    }
}