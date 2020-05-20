using AtleX.CommandLineArguments.Configuration;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace AtleX.CommandLineArguments.Benchmarks.Benches
{
  public class CommandLineArgumentsBenchmarks
  {
    public static IEnumerable<CommandLineArgumentsBenchmarkConfiguration> Configurations
    {
      get
      {
        yield return new CommandLineArgumentsBenchmarkConfiguration
        {
          Arguments = ArgumentsFaker.GetWindowsStyleArguments(),
          Configuration = new WindowsStyleConfiguration(),
        };

        yield return new CommandLineArgumentsBenchmarkConfiguration
        {
          Arguments = ArgumentsFaker.GetLinuxStyleArguments(),
          Configuration = new LinuxStyleConfiguration(),
        };

        yield return new CommandLineArgumentsBenchmarkConfiguration
        {
          Arguments = ArgumentsFaker.GetKeyValueStyleArguments(),
          Configuration = new KeyValueStyleConfiguration(),
        };
      }
    }

    [Benchmark]
    [ArgumentsSource((nameof(Configurations)))]
    public bool CommandLineArgumentsTryParse_SuccessFul(CommandLineArgumentsBenchmarkConfiguration configuration)
    {
      CommandLineArguments.Configuration = configuration.Configuration;

      var result = CommandLineArguments.TryParse(configuration.Arguments, out MockArguments parsedArguments);

      return result;
    }
  }
}
