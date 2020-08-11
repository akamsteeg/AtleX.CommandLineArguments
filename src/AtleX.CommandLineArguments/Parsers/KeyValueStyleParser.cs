using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a key/value ("key1=value1 key2=value2 toggle") command line arguments parser
  /// </summary>
  public sealed class KeyValueStyleParser
    : CommandLineArgumentsParser
  {
    /// <inheritdoc />
    protected override bool TryFindRawArgumentValue(string[] allCommandLineArguments, string argumentToFind, out string value)
    {
      var result = false;
      value = null;

      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var argumentParts = GetArgumentParts(allCommandLineArguments[i]);

        if (argumentParts.Key.Equals(argumentToFind, StringComparison.InvariantCultureIgnoreCase))
        {
          value = argumentParts.Value;

          result = true;
          break;
        }
      }

      return result;
    }

    /// <inheritdoc />
    protected override bool ContainsHelpArgument(string[] allCommandLineArguments)
    {
      var result = false;
      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var currentArgumentName = allCommandLineArguments[i];

        // Accept "?" and "help" as help arguments
        if (currentArgumentName == "?" || currentArgumentName.Equals("help", StringComparison.InvariantCultureIgnoreCase))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private static (string Key, string Value) GetArgumentParts(string argument)
    {
      var separatorPosition = argument.IndexOf('=');

      var key = argument; // For empty arguments
      string value = null;

      if (separatorPosition != -1)
      {
        key = argument.Substring(0, separatorPosition);
        value = argument.Substring(separatorPosition + 1);
      }

      return (key, value);

    }
  }
}
