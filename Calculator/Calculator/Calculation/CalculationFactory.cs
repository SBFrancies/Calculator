using Calculator.Enums;
using Calculator.Interface;
using Calculator.Models;
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
        public IOperation GetCalculation(Operation operation)
        {
            switch(operation)
            {
                case Operation.Add:
                    return new AddOperation();
                case Operation.Subtract:
                    return new SubtractOperation();
                case Operation.Multiply:
                    return new MultiplyOperation();
                case Operation.DivideBy:
                    return new DivideByOperation();
                case Operation.Modulo:
                    return new ModuloOperation();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
