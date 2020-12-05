using Calculator.Calculation;
using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.UnitTests.Calculation
{
    public class CalculationFactoryTests
    {
        [Theory]
        [InlineData(Operation.Add, 1, 22, 23)]
        [InlineData(Operation.Subtract, 10000, 5001, 4999)]
        [InlineData(Operation.Multiply, 13, 13, 169)]
        [InlineData(Operation.DivideBy, 23, 2, 11)]
        [InlineData(Operation.Modulo, 22, 5, 2)]
        public void CalculationFactory_GetCalculation_ShouldReturnCorrectFunction(Operation operation, int a, int b, int expectedResult)
        {
            var sut = CreateSystemUnderTest();

            var func = sut.GetCalculation(operation);
            var result = func(a, b);

            Assert.Equal(expectedResult, result);
        }

        private CalculationFactory CreateSystemUnderTest()
        {
            return new CalculationFactory();
        }
    }
}
