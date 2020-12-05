using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator.Files
{
    public class FileReader : IFileReader
    {
        public IList<string> GetFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
