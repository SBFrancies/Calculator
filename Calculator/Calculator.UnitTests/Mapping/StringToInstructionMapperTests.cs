using Calculator.Enums;
using Calculator.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.UnitTests.Mapping
{
    public class StringToInstructionMapperTests
    {
        [Theory]
        [InlineData("add    22", Operation.Add, 22)]
        [InlineData("subtract 123456789", Operation.Subtract, 123456789)]
        [InlineData("Multiply               -34", Operation.Multiply, -34)]
        [InlineData("divideBY  2002", Operation.DivideBy, 2002)]
        [InlineData("MoDuLo  1345", Operation.Modulo, 1345)]
        [InlineData("APPLY      1", Operation.Apply, 1)]
        public void StringToInstructionMapper_Map_MapsToExpectedValues(string line, Operation operation, int value)
        {
            var sut = CreateSystemUnderTest();

            var result = sut.Map(line);

            Assert.Equal(operation, result.Operation);
            Assert.Equal(value, result.Value);
        }

        private StringToInstructionMapper CreateSystemUnderTest()
        {
            return new StringToInstructionMapper();
        }
    }
}
