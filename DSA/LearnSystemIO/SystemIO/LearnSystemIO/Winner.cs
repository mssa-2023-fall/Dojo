using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSystemIO
{
    internal class Winner
    {
        public int Index { get; set; }
        public int Year { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Movie { get; set; }

        public Winner(string input)
        {
            //parse the input string
            // read from 0 to first occurance of ",", do an int.Parse to fill an Index
            //Index = input[0..input].IndexOf(',');
            string[] inputArr = input.Split(", ", 5);
            Index = Convert.ToInt32(inputArr[0]);
            Year = Convert.ToInt32(inputArr[1]);
            Age = Convert.ToInt32(inputArr[2]);
            Name = inputArr[3];
            Movie = inputArr[4];


        }
    }
}
