using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the <see cref="WindowsStyleCommandLineArgumentsConfiguration"/> for
  /// Windows-style (/key value) command line arguments
  /// </summary>
  public class WindowsStyleCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="WindowsStyleCommandLineArgumentsConfiguration"/>
    /// </summary>
    public WindowsStyleCommandLineArgumentsConfiguration()
    {
      this.Parser = new WindowsStyleCommandLineArgumentsParser();
      this.HelpWriter = new WindowsStyleHelpWriter();
    }
  }
}
