using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="DateTime"/>
  /// </summary>
  internal sealed class DateTimeTypeParser
  : TypeParser<DateTime>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out DateTime parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = DateTime.TryParse(value, out parseResult);
      }
      else
      {
        parseResult = default;
        result = false;
      }

      return result;
    }
  }
}
