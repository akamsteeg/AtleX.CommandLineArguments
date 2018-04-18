using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
using BenchmarkDotNet.Attributes;

namespace AtleX.CommandLineArguments.Benchmarks.Benches
{
  public class CommandLineArgumentsBenchmarks
  {
    [Benchmark(Baseline = true)]
    public bool CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul()
    {
      CommandLineArguments.Configuration = new CommandLineArgumentsConfiguration()
      {
        HelpWriter = new WindowsStyleHelpWriter(),
        Parser = new WindowsStyleCommandLineArgumentsParser(),
      };

      bool result = ParseCommandLineArguments();

      return result;
    }

    [Benchmark]
    public bool CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndHelpWriter_SuccessFul()
    {
      CommandLineArguments.Configuration = new CommandLineArgumentsConfiguration()
      {
        HelpWriter = new WindowsStyleHelpWriter(),
        Parser = new WindowsStyleCommandLineArgumentsParser(),
      };

      bool result = ParseCommandLineArguments();

      return result;
    }

    private static bool ParseCommandLineArguments()
    {
      var cliArguments = ArgumentsFaker.GetWindowsStyleArguments();

      var result = CommandLineArguments.TryParse(cliArguments, out MockArguments arguments);
      return result;
    }
  }
}
