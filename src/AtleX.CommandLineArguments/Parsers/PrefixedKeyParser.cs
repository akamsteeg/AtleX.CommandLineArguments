using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a <see cref="ICommandLineArgumentsParser"/> for key value pairs with the key indicated by a certain prefix string
  /// </summary>
  public class PrefixedKeyParser
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
      value = null;

      var previousItemWasCorrectKey = false;

      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var currentItem = allCommandLineArguments[i];
        var currentItemIsKey = currentItem.StartsWith(this._keyPrefix, StringComparison.OrdinalIgnoreCase);

        // Previous key wasn't correct and current item is a key
        if (!previousItemWasCorrectKey && currentItemIsKey)
        {
          var keyName = currentItem.Substring(this._keyPrefixLength);

          previousItemWasCorrectKey = (string.Compare(argumentToFind, keyName, StringComparison.OrdinalIgnoreCase) == 0);

          result = previousItemWasCorrectKey;
        }
        // Current value is not a key (so it's a value) and the previous value was the correct key
        else if (previousItemWasCorrectKey && !currentItemIsKey)
        {
          value = currentItem;
          break;
        }
        //Previous value was the correct key, current one is a key too. So, empty value
        else if (previousItemWasCorrectKey && currentItemIsKey)
        {
          value = null;
          break;
        }
        else
        {
          previousItemWasCorrectKey = false;
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
      var completeHelpArgument = this._keyPrefix + "help";

      var result = false;

      for (var i = 0; i < allCommandLineArguments.Length && !result; i++)
      {
        result = (allCommandLineArguments[i] == completeHelpArgument);
      }

      return result;
    }
  }
}
