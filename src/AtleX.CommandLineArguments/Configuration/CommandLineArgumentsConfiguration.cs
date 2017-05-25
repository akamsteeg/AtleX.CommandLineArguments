using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the configuration for <see cref="AtleX.CommandLineArguments.CommandLineArguments"/>
  /// </summary>
  public class CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Gets or sets the <see cref="CommandLineArgumentsParser"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsParser Parser
    {
      get;
      set;
    }
  }
}
