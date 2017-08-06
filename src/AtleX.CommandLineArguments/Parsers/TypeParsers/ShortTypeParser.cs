using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="short"/>
  /// </summary>
  public sealed class ShortTypeParser
  : TypeParser<short>
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
    public override bool TryParse(string value, out short parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = short.TryParse(value, out parseResult);
      }
      else
      {
        parseResult = default(short);
        result = false;
      }

      return result;
    }
  }
}
