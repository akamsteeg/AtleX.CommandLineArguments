using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the default <see cref="CommandLineArgumentsConfiguration"/>
  /// </summary>
  public sealed class DefaultCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new <see cref="DefaultCommandLineArgumentsConfiguration"/>
    /// </summary>
    public DefaultCommandLineArgumentsConfiguration()
      : base(new WindowsStyleCommandLineArgumentsParser())
    {
      this.HelpWriter = new WindowsStyleHelpWriter();
      this.Validators.Add(new RequiredArgumentValidator())
;
    }
  }
}
