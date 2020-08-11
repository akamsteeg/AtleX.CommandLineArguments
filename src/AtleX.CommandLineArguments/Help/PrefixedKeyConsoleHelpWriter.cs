using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="ConsoleHelpWriter"/> for key value pairs with the key indicated by a certain prefix string
  /// </summary>
  public class PrefixedKeyConsoleHelpWriter
    : ConsoleHelpWriter
  {
    /// <summary>
    /// The character indicating a key
    /// </summary>
    private readonly string _keyPrefix;

    /// <summary>
    /// Initializes a new instance of <see cref="PrefixedKeyConsoleHelpWriter"/>
    /// with the specified key prefix
    /// </summary>
    /// <param name="keyPrefix">
    /// The prefix string that indicates the value is a key
    /// </param>
    public PrefixedKeyConsoleHelpWriter(string keyPrefix)
    {
      if (string.IsNullOrWhiteSpace(keyPrefix))
        throw new ArgumentNullException(nameof(keyPrefix));

      this._keyPrefix = keyPrefix;
    }

    /// <inheritdoc />
    protected override string GetExactCommandlineNameOfArgument(string argumentName)
    {
      var result = this._keyPrefix + argumentName;
      return result;
    }
  }
}
