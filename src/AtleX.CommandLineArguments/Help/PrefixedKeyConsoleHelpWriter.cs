using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="ConsoleHelpWriter"/> for key value pairs with the key indicated by a certain prefix string
  /// </summary>
  public abstract class PrefixedKeyConsoleHelpWriter
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

    /// <summary>
    /// Gets the exact name of an argument how it should be used on the command
    /// line, including prefixes
    /// </summary>
    /// <param name="argumentName">
    /// The name of the argument to get the exact commandline usage for
    /// </param>
    /// <returns>
    /// The exact name of an argument how it should be used on the command line,
    /// including prefixes
    /// </returns>
    protected override string GetExactCommandlineNameOfArgument(string argumentName)
    {
      var result = this._keyPrefix + argumentName;
      return result;
    }
  }
}
