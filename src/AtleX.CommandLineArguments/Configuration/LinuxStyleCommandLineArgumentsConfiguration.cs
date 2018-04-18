using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;


namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the <see cref="CommandLineArgumentsConfiguration"/> for
  /// Linux-style (--key value) command line arguments
  /// </summary>
  public class LinuxStyleCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="LinuxStyleCommandLineArgumentsConfiguration"/>
    /// </summary>
    public LinuxStyleCommandLineArgumentsConfiguration()
    {
      this.Parser = new LinuxStyleCommandLineArgumentsParser();
      this.HelpWriter = new LinuxStyleHelpWriter();
    }
  }
}
