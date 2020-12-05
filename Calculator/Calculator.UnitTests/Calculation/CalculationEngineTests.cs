using Calculator.Calculation;
using Calculator.Interface;
using Calculator.Mapping;
using Calculator.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.UnitTests.Calculation
{
    public class CalculationEngineTests
    {
        private readonly Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
        private readonly Mock<IInstructionValidator> mockInstructionValidator = new Mock<IInstructionValidator>();

        [Theory]
        [InlineData(15, "add 2", "multiply 3", "apply 3")]
        [InlineData(45, "multiply 9", "apply 5")]
        [InlineData(0, "add 100", "subtract 20", "multiply 0", "apply 13")]
        [InlineData(22, "add 29", "divideBy 10", "add 10000", "subtract 9981", "apply 1")]
        public void CalculationEngine_CalculateResult_ProducesExpectedResult(int expectedResult, params string[] lines)
        {
            var filePath = "filePath";
            this.mockFileReader.Setup(a => a.GetFileLines(filePath)).Returns(lines);
            this.mockInstructionValidator.Setup(a => a.ValidInstructions(lines)).Returns(true);
            var sut = CreateSystemUnderTest();

            var result = sut.CalculateResult(filePath);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculationEngine_CalculateResult_InvalidFileContentThrowsError()
        {
            var filePath = "filePath";
            this.mockInstructionValidator.Setup(a => a.ValidInstructions(It.IsAny<IList<string>>())).Returns(false);
            var sut = CreateSystemUnderTest();

            Assert.Throws<Exception>(() => sut.CalculateResult(filePath));
        }



        private CalculationEngine CreateSystemUnderTest()
        {
            return new CalculationEngine(
                new CalculationFactory(),
                this.mockInstructionValidator.Object,
                this.mockFileReader.Object,
                new StringToInstructionMapper());
        }
    }
}
