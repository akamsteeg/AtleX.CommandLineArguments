using System;
using System.Runtime.InteropServices;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents a <see cref="CommandLineArgumentsConfiguration"/> that
  /// autodetects the runtime platform (Windows or Unix) and configures a <see
  /// cref="CommandLineArgumentsParser"/> and <see cref="HelpWriter"/> accordingly
  /// </summary>
  public class AutoDetectConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="AutoDetectConfiguration"/>
    /// </summary>
    public AutoDetectConfiguration()
    {
#if NETSTANDARD1_5
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
#else
      if (Environment.OSVersion.Platform != PlatformID.Unix && Environment.OSVersion.Platform != PlatformID.MacOSX)
#endif
      {
        this.Parser = new WindowsStyleParser();
        this.HelpWriter = new WindowsStyleHelpWriter();
      }
      else
      {
        this.Parser = new LinuxStyleParser();
        this.HelpWriter = new LinuxStyleHelpWriter();
      }
    }
  }
}
