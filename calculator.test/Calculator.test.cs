using calculator.Classes;
using calculator.Interfaces;
using calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace calculator.test
{
    [TestClass]
    public class CalculatorTest
    {
        Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            Mock<IFormula> mock = new Mock<IFormula>();
            mock.Setup(c => c.CombinedWith(It.IsAny<int>(),It.IsAny<int>())).Returns(20);
            mock.Setup(c => c.Either(It.IsAny<int>(), It.IsAny<int>())).Returns(34);
            calculator = new Calculator(mock.Object);
        }

        [TestMethod]
        public void Calculate_values_ReturnsCombinedWith()
        {
            //Arrange
            var calculation = new Calculation
            {
                TypeOfCalculation = "CombinedWith",
                Input = new Input
                {
                    FirstValue = 5,
                    SecondValue = 4
                },
                Result = 0
            };

            //Act
            var result = calculator.Calculate(calculation);

            //Assert
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void Calculate_values_ReturnsEither()
        {
            //Arrange
            var calculation = new Calculation
            {
                TypeOfCalculation = "Either",
                Input = new Input
                {
                    FirstValue = -10,
                    SecondValue = 4
                },
                Result = 0
            };

            //Act
            var result = calculator.Calculate(calculation);

            //Assert
            Assert.AreEqual(result, 34);
        }
    }
}
