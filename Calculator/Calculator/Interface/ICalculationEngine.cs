using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface ICalculationEngine
    {
        int CalculateResult(string filePath);
    }
}
