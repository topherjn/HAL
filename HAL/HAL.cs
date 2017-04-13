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

            // the followig console write demonstrates the success of the resource
            // import.  You will want to comment it out or delete it eventually
            Console.WriteLine(dict);

        }

    }
}

