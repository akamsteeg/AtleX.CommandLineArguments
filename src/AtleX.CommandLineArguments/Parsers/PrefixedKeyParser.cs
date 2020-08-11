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

    /// <inheritdoc />
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

    /// <inheritdoc />
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
