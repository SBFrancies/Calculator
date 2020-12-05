using Calculator.Calculation;
using Calculator.Enums;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.UnitTests.Calculation
{
    public class CalculationFactoryTests
    {
        [Theory]
        [InlineData(Operation.Add, 1, 22, 23, typeof(AddOperation))]
        [InlineData(Operation.Subtract, 10000, 5001, 4999, typeof(SubtractOperation))]
        [InlineData(Operation.Multiply, 13, 13, 169, typeof(MultiplyOperation))]
        [InlineData(Operation.DivideBy, 23, 2, 11, typeof(DivideByOperation))]
        [InlineData(Operation.Modulo, 22, 5, 2, typeof(ModuloOperation))]
        public void CalculationFactory_GetCalculation_ShouldReturnCorrectFunction(Operation operation, int a, int b, int expectedResult, Type type)
        {
            var sut = CreateSystemUnderTest();

            var op = sut.GetCalculation(operation);
            var result = op.Calculate(a, b);

            Assert.IsType(type, op);
            Assert.Equal(expectedResult, result);
        }

        private CalculationFactory CreateSystemUnderTest()
        {
            return new CalculationFactory();
        }
    }
}
