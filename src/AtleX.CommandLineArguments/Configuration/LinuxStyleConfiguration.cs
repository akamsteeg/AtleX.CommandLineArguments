using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the <see cref="CommandLineArgumentsConfiguration"/> for
  /// Linux-style (--key value) command line arguments
  /// </summary>
  public class LinuxStyleConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="LinuxStyleConfiguration"/>
    /// </summary>
    public LinuxStyleConfiguration()
    {
      this.Parser = new LinuxStyleCommandLineArgumentsParser();
      this.HelpWriter = new LinuxStyleHelpWriter();
    }
  }
}
