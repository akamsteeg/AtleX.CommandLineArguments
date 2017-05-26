using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Microsoft Windows CLI style ("/key value /key2 value2
  /// /toggle") command line arguments parser
  /// </summary>
  public sealed class WindowsStyleCommandLineArgumentsParser
    : CommandLineArgumentsParser
  {
    /// <summary>
    /// The character indicating a key
    /// </summary>
    private const string keyIndicatorCharacter = "/";

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
      string key;
      value = null;

      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var currentItem = allCommandLineArguments[i];
        if (ArgumentIsKey(currentItem))
        {
          key = currentItem.Substring(1);

          if (string.Compare(key, argumentToFind, ignoreCase: true) == 0)
          {
            // Look ahead for the next argument, because they're separated by a space
            if (i + 1 != allCommandLineArguments.Length)
            {
              var possibleValue = allCommandLineArguments[i + 1];
              if (!ArgumentIsKey(possibleValue))
              {
                value = possibleValue;
                i++;
              }
              else
              {
                value = null;
              }
            }
            else
            {
              value = null;
            }

            result = true;
            break; // We found everything we need
          }
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

        // Accept /? and /help as help arguments
        if (currentArgumentName == "/?" || currentArgumentName.Equals("/help", StringComparison.OrdinalIgnoreCase))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// Determines whether the specified argument is a key or not
    /// </summary>
    /// <param name="argument">
    /// The parameter to verify
    /// </param>
    /// <returns>
    /// True when the specified parameter is a key, false otherwise
    /// </returns>
    private static bool ArgumentIsKey(string argument)
    {
      var result = argument.StartsWith(keyIndicatorCharacter);

      return result;
    }

    
  }
}
