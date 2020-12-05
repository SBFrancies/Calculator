using Calculator.Enums;
using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Validation
{
    /// <summary>
    /// Used to validate a provided instruction string.
    /// </summary>
    public class InstructionValidator : IInstructionValidator
    {
        /// <summary>
        /// Tests if all the instructions in the provided collection of strings are valid.
        /// </summary>
        /// <param name="instructions">The collection of instructions.</param>
        /// <returns>Whether all the provided instructions are valid.</returns>
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
