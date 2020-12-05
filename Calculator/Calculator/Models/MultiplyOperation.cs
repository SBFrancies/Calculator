using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class MultiplyOperation : IOperation
    {
        public int Calculate(int arg1, int arg2)
        {
            return arg1 * arg2;
        }
    }
}
