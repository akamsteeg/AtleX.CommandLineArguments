using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="string"/>
  /// </summary>
  public sealed class StringTypeParser
  : TypeParser<string>
  {
    /// <summary>
    /// Tries to parse the specified value to the specified parse result
    /// </summary>
    /// <param name="value">
    /// The value to parse
    /// </param>
    /// <param name="parseResult">
    /// The parsed value
    /// </param>
    /// <returns>
    /// True if value was converted successfully; otherwise, false
    /// </returns>
    public override bool TryParse(string value, out string parseResult)
    {
      if (string.IsNullOrEmpty(value))
        throw new ArgumentNullException(nameof(value));

      parseResult = value; // Yeah, this is silly
      return true;
    }
  }
}
