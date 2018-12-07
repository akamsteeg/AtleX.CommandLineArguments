using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Linux CLI style ("--key value --key2 value2
  /// --toggle") command line arguments parser
  /// </summary>
  public sealed class LinuxStyleParser
    : PrefixedKeyParser
  {
    /// <summary>
    /// Gets the prefix that indicates a key
    /// </summary>
    private const string KeyPrefix = "--";

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="LinuxStyleParser"/>
    /// </summary>
    public LinuxStyleParser()
      : base(KeyPrefix)
    {
    }
  }
}
