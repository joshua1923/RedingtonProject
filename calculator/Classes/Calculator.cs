using calculator.Classes.enums;
using calculator.Interfaces;
using calculator.Models;

namespace calculator.Classes
{
    public class Calculator : ICalculator
    {
        public int Calculate(Calculation calculation)
        {
            
            if (calculation.TypeOfCalculation == TypeOfCalculaton.CombinedWith.ToString())
            {
                calculation.Result = calculation.Input.FirstValue * calculation.Input.SecondValue;
            }
            else if (calculation.TypeOfCalculation == TypeOfCalculaton.Either.ToString())
            {
                calculation.Result = calculation.Input.FirstValue + calculation.Input.SecondValue - calculation.Input.FirstValue * calculation.Input.SecondValue;
            }

            return calculation.Result;
        }
    }
}
