using Calculator.Enums;
using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Validation
{
    public class InstructionValidator : IInstructionValidator
    {
        public bool ValidInstructions(IList<string> instructions)
        {
            if(instructions == null)
            {
                throw new ArgumentNullException(nameof(instructions));
            }

            if(instructions.Count == 0)
            {
                return false;
            }

            return
                instructions.All(a => a != null)
                && instructions.Take(instructions.Count - 1).All(a => this.ValidInstruction(a))
                && this.ValidFinalInstruction(instructions.Last());
        }

        private bool ValidInstruction(string instruction)
        {
            var operationNames = Enum.GetNames(typeof(Operation)).ToList();
            operationNames.Remove(nameof(Operation.Apply));

            var regex = $"^({string.Join("|", operationNames)})\\s+-?\\d{{1,10}}$";

            return Regex.IsMatch(instruction, regex, RegexOptions.IgnoreCase);
        }

        private bool ValidFinalInstruction(string instruction)
        {
            var regex = $"^{nameof(Operation.Apply)}\\s+-?\\d{{1,10}}$";

            return Regex.IsMatch(instruction, regex, RegexOptions.IgnoreCase);
        }
    }
}
