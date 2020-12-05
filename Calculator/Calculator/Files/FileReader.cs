using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator.Files
{
    /// <summary>
    /// Wrapper around static System.IO methods for testing.
    /// </summary>
    public class FileReader : IFileReader
    {
        /// <summary>
        /// Gets the line content of a given file.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The collection of lines in the file.</returns>
        public IList<string> GetFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
