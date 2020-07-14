using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a key/value ("key1=value1 key2=value2 toggle") command line arguments parser
  /// </summary>
  public sealed class KeyValueStyleParser
    : CommandLineArgumentsParser
  {
    /// <summary>
    /// Try to find an argument with the specified name in the specified
    /// collection of all command line arguments
    /// </summary>
    /// <param name="allCommandLineArguments">
    /// The collection of all command line arguments
    /// </param>
    /// <param name="argumentToFind">
    /// The name of the argument to find
    /// </param>
    /// <param name="value">
    /// The value of the argument, if found
    /// </param>
    /// <returns>
    /// True when the argument with the specified name to find is found, false otherwise
    /// </returns>
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
