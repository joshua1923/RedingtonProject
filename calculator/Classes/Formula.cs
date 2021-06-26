using calculator.Interfaces;

namespace calculator.Classes
{
    public class Formula : IFormula
    {
        public int CombinedWith(int a, int b)
        {
            return a * b;
        }

        public int Either(int a, int b)
        {
            return a + b - a * b;
        }
    }
}
