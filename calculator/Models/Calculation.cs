using System;

namespace calculator.Models
{
    public class Calculation
    {
        public DateTime Date { get; set; }
        public string TypeOfCalculation { get; set; }
        public Input Input { get; set; }
        public int Result { get; set; }
    }

    public class Input
    { 
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
    }
}
