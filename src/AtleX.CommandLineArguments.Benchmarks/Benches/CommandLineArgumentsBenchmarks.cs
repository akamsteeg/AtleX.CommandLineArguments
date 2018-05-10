using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;
using BenchmarkDotNet.Attributes;

namespace AtleX.CommandLineArguments.Benchmarks.Benches
{
  public class CommandLineArgumentsBenchmarks
  {
    private string[] _commandLineArguments;

    [GlobalSetup]
    public void GlobalSetup()
    {
      this._commandLineArguments = ArgumentsFaker.GetWindowsStyleArguments();
    }

    [Benchmark]
    public bool CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul()
    {
      CommandLineArguments.Configuration = new CommandLineArgumentsConfiguration()
      {
        HelpWriter = new WindowsStyleHelpWriter(),
        Parser = new WindowsStyleParser(),
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
        Parser = new WindowsStyleParser(),
      };

      bool result = ParseCommandLineArguments();

      return result;
    }

    private bool ParseCommandLineArguments()
    {
      var result = CommandLineArguments.TryParse(this._commandLineArguments, out MockArguments arguments);
      return result;
    }
  }
}
