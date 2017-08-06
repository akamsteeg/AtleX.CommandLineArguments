using System;
using System.Collections.Generic;
using System.Text;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="double"/>
  /// </summary>
  public sealed class DoubleTypeParser
  : TypeParser<double>
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
    public override bool TryParse(string value, out double parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = double.TryParse(value, out parseResult);
      }
      else
      {
        parseResult = default(double);
        result = false;
      }

      return result;
    }
  }
}
