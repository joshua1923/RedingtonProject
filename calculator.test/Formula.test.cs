using calculator.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace calculator.test
{
    [TestClass]
    public class FormulaTests
    {
        Formula formula;

        [TestMethod]
        public void Formula_Calculate_ReturnsCombinedWith()
        {
            //Act
            formula = new Formula();

            //Arrange
            var result = formula.CombinedWith(5, 4);

            //Assert
            Assert.AreEqual(result, 20);
        }


        [TestMethod]
        public void Formula_Calculate_ReturnsEither()
        {
            //Act
            formula = new Formula();

            //Arrange
            var result = formula.Either(-10, 4);

            //Assert
            Assert.AreEqual(result, 34);
        }
    }
}
