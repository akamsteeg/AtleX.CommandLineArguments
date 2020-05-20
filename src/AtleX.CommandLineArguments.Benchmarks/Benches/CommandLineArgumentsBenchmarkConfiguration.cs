using AtleX.CommandLineArguments.Configuration;

namespace AtleX.CommandLineArguments.Benchmarks.Benches
{
  public sealed class CommandLineArgumentsBenchmarkConfiguration
  {
    public string[] Arguments { get; set; }

    public CommandLineArgumentsConfiguration Configuration { get; set; }

    public override string ToString()
    {
      var result = this.Configuration.GetType().Name;

      return result;
    }
  }
}
