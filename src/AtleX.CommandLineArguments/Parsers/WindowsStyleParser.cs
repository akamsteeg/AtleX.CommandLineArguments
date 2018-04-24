using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Microsoft Windows CLI style ("/key value /key2 value2
  /// /toggle") command line arguments parser
  /// </summary>
  public sealed class WindowsStyleParser
    : PrefixedKeyCommandLineArgumentsParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="WindowsStyleParser"/>
    /// </summary>
    public WindowsStyleParser()
      : base("/")
    {
    }

    /// <summary>
    /// Gets whether the specified command line arguments contain a Help argument or not
    /// </summary>
    /// <param name="allCommandLineArguments">
    /// The collection of all command line arguments
    /// </param>
    /// <returns>
    /// True when the collection of command line arguments contains a Help argument, false otherwise
    /// </returns>
    protected override bool ContainsHelpArgument(string[] allCommandLineArguments)
    {
      var result = false;
      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var currentArgumentName = allCommandLineArguments[i];

        // Accept /? and /help as help arguments
        if (currentArgumentName == "/?" || currentArgumentName.Equals("/help", StringComparison.OrdinalIgnoreCase))
        {
          result = true;
          break;
        }
      }

      return result;
    }
  }
}
