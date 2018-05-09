using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the <see cref="CommandLineArgumentsConfiguration"/> for
  /// key/value-style (key=value) command line arguments
  /// </summary>
  public class KeyValueStyleConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="KeyValueStyleConfiguration"/>
    /// </summary>
    public KeyValueStyleConfiguration()
    {
      this.Parser = new KeyValueStyleParser();
      this.HelpWriter = new KeyValueStyleHelpWriter();
    }

  }
}
