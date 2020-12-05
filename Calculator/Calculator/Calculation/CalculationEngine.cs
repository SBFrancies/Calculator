using Calculator.Interface;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Calculation
{
    public class CalculationEngine : ICalculationEngine
    {
        private readonly ICalculationFactory calculationFactory;
        private readonly IInstructionValidator instructionValidator;
        private readonly IFileReader fileReader;
        private readonly IMapper<string, Instruction> instructionMapper;

        public CalculationEngine(
            ICalculationFactory calculationFactory,
            IInstructionValidator instructionValidator,
            IFileReader fileReader,
            IMapper<string, Instruction> instructionMapper
            )
        {
            this.calculationFactory = calculationFactory ?? throw new ArgumentNullException(nameof(calculationFactory));
            this.instructionValidator = instructionValidator ?? throw new ArgumentNullException(nameof(instructionValidator));
            this.fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            this.instructionMapper = instructionMapper ?? throw new ArgumentNullException(nameof(instructionMapper));
        }

        public int CalculateResult(string filePath)
        {
            var lines = this.fileReader.GetFileLines(filePath);
            bool valid = this.instructionValidator.ValidInstructions(lines);

            if(!valid)
            {
                throw new Exception("Invalid file content");
            }

            var instructions = this.instructionMapper.Map(lines);

            var value = instructions.Last().Value;

            foreach (var instruction in instructions.Take(instructions.Count() - 1))
            {
                var func = this.calculationFactory.GetCalculation(instruction.Operation);
                value = func(value, instruction.Value);
            }

            return value;
        }
    }
}
