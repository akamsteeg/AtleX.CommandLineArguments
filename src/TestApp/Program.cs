using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments;
using AtleX.CommandLineArguments.Validators;

namespace TestApp
{
  class Program
  {
    static void Main(string[] args)
    {

      if (!CommandLineArguments.TryParse(args, out CliArguments cliArguments, out IEnumerable<ValidationResult> validationResults))
      {
        Console.WriteLine("Validation results;");

        foreach (var currentValidationResults in validationResults)
        {
          Console.WriteLine($"* {currentValidationResults.ArgumentName}: {currentValidationResults.ValidationMessage} ({currentValidationResults.IsValid})");
        }
      }

      Console.ReadKey();
    }
  }
}
