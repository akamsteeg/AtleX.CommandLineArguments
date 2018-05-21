using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="bool"/>
  /// </summary>
  [Obsolete("This class will be removed in a future version")]
  public sealed class BoolTypeParser
  : TypeParser<bool>
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
    public override bool TryParse(string value, out bool parseResult)
    {
      bool result;

      if (string.IsNullOrEmpty(value))
      {
        parseResult = true;
        result = true;
      }
      else
      {
        result = bool.TryParse(value, out parseResult);
      }

      return result;
    }
  }
}
