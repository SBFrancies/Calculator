using Calculator.Calculation;
using Calculator.Files;
using Calculator.Interface;
using Calculator.Mapping;
using Calculator.Models;
using Calculator.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator
{
    public class Program
    {
        private static IServiceProvider ServiceProvider;

        public static void Main(string[] args)
        {
            if(args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            RegisterServices();

            var calculationEngine = ServiceProvider.GetRequiredService<ICalculationEngine>();

            foreach(var filePath in args)
            {
                Console.WriteLine(calculationEngine.CalculateResult(filePath));
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<ICalculationEngine, CalculationEngine>();
            collection.AddSingleton<ICalculationFactory, CalculationFactory>();
            collection.AddSingleton<IFileReader, FileReader>();
            collection.AddSingleton<IInstructionValidator, InstructionValidator>();
            collection.AddSingleton<IMapper<string, Instruction>, StringToInstructionMapper>();

            ServiceProvider = collection.BuildServiceProvider();
        }
    }
}
