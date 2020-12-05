using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface ICalculationFactory
    {
        Func<int, int, int> GetCalculation(Operation operation);
    }
}
