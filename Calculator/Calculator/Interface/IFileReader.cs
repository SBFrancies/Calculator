using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface IFileReader
    {
        IList<string> GetFileLines(string filePath);
    }
}
