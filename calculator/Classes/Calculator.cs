using calculator.Classes.enums;
using calculator.Interfaces;
using calculator.Models;

namespace calculator.Classes
{
    public class Calculator : ICalculator
    {
        private readonly IFormula _formula;

        public Calculator(IFormula formula)
        {
            _formula = formula;
        }

        public int Calculate(Calculation calculation)
        {

            if (calculation.TypeOfCalculation == TypeOfCalculaton.CombinedWith.ToString())
            {
                calculation.Result = _formula.CombinedWith(calculation.Input.FirstValue, calculation.Input.SecondValue);
            }
            else if (calculation.TypeOfCalculation == TypeOfCalculaton.Either.ToString())
            {
                calculation.Result = _formula.Either(calculation.Input.FirstValue, calculation.Input.SecondValue);
            }

            return calculation.Result;
        }
    }
}
