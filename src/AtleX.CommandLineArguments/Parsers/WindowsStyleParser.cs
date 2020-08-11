using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Microsoft Windows CLI style ("/key value /key2 value2
  /// /toggle") command line arguments parser
  /// </summary>
  public sealed class WindowsStyleParser
    : PrefixedKeyParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="WindowsStyleParser"/>
    /// </summary>
    public WindowsStyleParser()
      : base("/")
    {
    }

    /// <inheritdoc />
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
