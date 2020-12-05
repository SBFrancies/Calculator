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
    public class StringToInstructionMapper : IMapper<string, Instruction>
    {
        public Instruction Map(string value)
        {
            var parts = Regex.Split(value, "\\s+");

            var op = Enum.Parse<Operation>(parts[0], true);
            var val = int.Parse(parts[1]);

            return new Instruction(op, val);
        }

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
