using Calculator.Enums;
using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Calculation
{
    public class CalculationFactory : ICalculationFactory
    {
        public Func<int,int, int> GetCalculation(Operation operation)
        {
            switch(operation)
            {
                case Operation.Add:
                    return (a, b) => a + b;
                case Operation.Subtract:
                    return (a, b) => a - b;
                case Operation.Multiply:
                    return (a, b) => a * b;
                case Operation.DivideBy:
                    return (a, b) => a / b;
                case Operation.Modulo:
                    return (a, b) => a % b;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
