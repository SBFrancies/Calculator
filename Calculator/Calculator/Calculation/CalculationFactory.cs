using Calculator.Enums;
using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Calculation
{
    /// <summary>
    /// This class returns the appropriate mathematical operation for a given operation type.
    /// </summary>
    public class CalculationFactory : ICalculationFactory
    {
        /// <summary>
        /// Get the mathematical operation for a given operation type.
        /// </summary>
        /// <param name="operation">The operation type.</param>
        /// <returns>The mathematical operation.</returns>
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
