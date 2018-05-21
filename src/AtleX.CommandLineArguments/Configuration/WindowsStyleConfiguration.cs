using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the <see cref="WindowsStyleConfiguration"/> for
  /// Windows-style (/key value) command line arguments
  /// </summary>
  public class WindowsStyleConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="WindowsStyleConfiguration"/>
    /// </summary>
    public WindowsStyleConfiguration()
    {
      this.Parser = new WindowsStyleParser();
      this.HelpWriter = new WindowsStyleHelpWriter();
    }
  }
}
