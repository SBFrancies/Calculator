using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    /// <summary>
    /// Represents an instruction from a file with the operation and the value the operation is to be performed with.
    /// </summary>
    public struct Instruction
    {
        public Instruction(Operation operation, int value)
        {
            Operation = operation;
            Value = value;
        }

        public Operation Operation { get; }

        public int Value { get; }
    }
}
