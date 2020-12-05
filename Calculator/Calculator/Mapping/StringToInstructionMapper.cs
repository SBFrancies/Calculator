using Calculator.Interface;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Calculator.Enums;
using System.Text.RegularExpressions;

namespace Calculator.Mapping
{
    /// <summary>
    /// Maps a string to an Instruction.
    /// </summary>
    public class StringToInstructionMapper : IMapper<string, Instruction>
    {
        /// <summary>
        /// Map a single string to a single instruction.
        /// </summary>
        /// <param name="value">The string to map.</param>
        /// <returns>The mapped Instruction.</returns>
        public Instruction Map(string value)
        {
            var parts = Regex.Split(value, "\\s+");

            var op = Enum.Parse<Operation>(parts[0], true);
            var val = int.Parse(parts[1]);

            return new Instruction(op, val);
        }

        /// <summary>
        /// Maps a collection of strings to a collection of instructions.
        /// </summary>
        /// <param name="values">The strings to map.</param>
        /// <returns>The collection of Mapped instructions.</returns>
        public IEnumerable<Instruction> Map(IEnumerable<string> values)
        {
            if (values == null)
            {
                return null;
            }

            return values.Select(this.Map);
        }
    }
}
