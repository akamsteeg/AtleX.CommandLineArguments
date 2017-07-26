using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="decimal"/>
  /// </summary>
  public sealed class DecimalTypeParser
  : TypeParser<decimal>
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
    public override bool TryParse(string value, out decimal parseResult)
    {
      if (string.IsNullOrEmpty(value))
        throw new ArgumentNullException(nameof(value));

      var result = decimal.TryParse(value, out parseResult);
      return result;
    }
  }
}
