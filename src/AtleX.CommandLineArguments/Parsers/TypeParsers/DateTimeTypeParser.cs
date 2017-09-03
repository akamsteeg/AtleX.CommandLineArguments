using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="DateTime"/>
  /// </summary>
  public sealed class DateTimeTypeParser
  : TypeParser<DateTime>
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
    public override bool TryParse(string value, out DateTime parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = DateTime.TryParse(value, out parseResult);
      }
      else
      {
        parseResult = default(DateTime);
        result = false;
      }

      return result;
    }
  }
}
