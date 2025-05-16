using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL
{
    internal class WordPair
    {
        // class variables - two strings and an integer for shift amount
        string originalWord;
        string shiftedWord;
        int shiftAmount;

        // constructor to initialize the variables
        public WordPair(string originalWord, string shiftedWord, int shiftAmount)
        {
            this.originalWord = originalWord;
            this.shiftedWord = shiftedWord;
            this.shiftAmount = shiftAmount;
        }

        // Override ToString method to return the original word, shifted word, and shift amount
        public override string ToString()
        {
            return $"Original: {originalWord}, Shifted: {shiftedWord}, Shift Amount: {shiftAmount}";
        }
    }
}
