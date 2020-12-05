using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
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
