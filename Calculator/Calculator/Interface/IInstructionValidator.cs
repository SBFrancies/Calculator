using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface IInstructionValidator
    {
        bool ValidInstructions(IList<string> instructions);
    }
}
