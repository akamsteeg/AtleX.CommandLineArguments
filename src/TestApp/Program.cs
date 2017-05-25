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

      if (!CommandLineArguments.TryParse(args, out CliArguments cliArguments, out IEnumerable<ValidationError> validationErrors) || cliArguments.ShowValidationErrors)
      {
        Console.WriteLine("Validation results;");

        foreach (var currentValidationError in validationErrors)
        {
          Console.WriteLine($"* {currentValidationError.ArgumentName}: {currentValidationError.ErrorMessage} ({currentValidationError.ValidatorName})");
        }

        CommandLineArguments.DisplayHelp(cliArguments);
      }
      if (cliArguments.IsHelpRequested)
      {
        Console.Write("HELP:");

        CommandLineArguments.DisplayHelp(cliArguments);
      }
      else
      {
        Console.WriteLine("All arguments are okay");
      }

      Console.WriteLine("(Press a key to exit)");
      Console.ReadKey();
    }
  }
}
