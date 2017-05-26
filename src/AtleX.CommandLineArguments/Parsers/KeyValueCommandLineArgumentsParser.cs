using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a key/value ("key1=value1 key2=value2 toggle") command line arguments parser
  /// </summary>
  public sealed class KeyValueCommandLineArgumentsParser
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

      string key;

      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var argumentParts = allCommandLineArguments[i].Split('=');

        key = argumentParts[0];

        if (string.Compare(key, argumentToFind) == 0)
        {
          if (argumentParts.Length == 2)
          {
            value = argumentParts[1];
          }
          else
          {
            value = null;
          }

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
        if (currentArgumentName == "?" || currentArgumentName.Equals("help", StringComparison.OrdinalIgnoreCase))
        {
          result = true;
          break;
        }
      }

      return result;
    }
  }
}
