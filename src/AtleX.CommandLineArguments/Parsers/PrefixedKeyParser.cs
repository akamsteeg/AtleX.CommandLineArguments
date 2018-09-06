using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a <see cref="ICommandLineArgumentsParser"/> for key value pairs with the key indicated by a certain prefix string
  /// </summary>
  public abstract class PrefixedKeyParser
    : CommandLineArgumentsParser
  {
    /// <summary>
    /// Gets the string that indicates the value is a key
    /// </summary>
    private readonly string _keyPrefix;

    /// <summary>
    /// Gets the length of the key indicator
    /// </summary>
    private readonly int _keyPrefixLength;

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="PrefixedKeyParser"/> with the specified key indicator
    /// </summary>
    /// <param name="keyIndicator">
    /// The prefix string that indicates the value is a key
    /// </param>
    public PrefixedKeyParser(string keyIndicator)
    {
      if (string.IsNullOrWhiteSpace(keyIndicator))
        throw new ArgumentNullException(nameof(keyIndicator));

      this._keyPrefix = keyIndicator;
      this._keyPrefixLength = keyIndicator.Length;
    }

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
          key = currentItem.Substring(this._keyPrefixLength);

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
    /// Determines whether the specified argument is a key or not
    /// </summary>
    /// <param name="argument">
    /// The parameter to verify
    /// </param>
    /// <returns>
    /// True when the specified parameter is a key, false otherwise
    /// </returns>
    private bool ArgumentIsKey(string argument)
    {
      var result = argument.StartsWith(this._keyPrefix);

      return result;
    }
  }
}
