using Calculator.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.UnitTests.Validation
{
    public class InstructionValidatorTests
    {
        [Theory]
        [InlineData("Add 1231", "apply     2")]
        [InlineData("SUBTRACT     1", "APPLY 79")]
        [InlineData("multiply 0", "Apply 2")]
        [InlineData("divideby  -129999", "apPLY 1233")]
        [InlineData("moDulo      2147483647", "apply 2")]
        public void InstructionValidator_ValidInstructions_ReturnsTrueForValidString(string instruction1, string instruction2)
        {
            var sut = CreateSystemUnderTest();

            var result = sut.ValidInstructions(new string[] { instruction1, instruction2 });

            Assert.True(result);
        }

        [Theory]
        [InlineData("add 1231", null)]
        [InlineData("SUBTRACT 1", "Apply1")]
        [InlineData("multiply", "apply 2")]
        [InlineData("divide  1299.123", "apply 4458")]
        [InlineData("moDulo 21474836471", "subtract 221")]
        [InlineData("aPpLy 13", "apply 12")]
        public void InstructionValidator_ValidInstructions_ReturnsFalseForInvalidString(string instruction1, string instruction2)
        {
            var sut = CreateSystemUnderTest();

            var result = sut.ValidInstructions(new string[] { instruction1, instruction2 });

            Assert.False(result);
        }

        private InstructionValidator CreateSystemUnderTest()
        {
            return new InstructionValidator();
        }
    }
}
