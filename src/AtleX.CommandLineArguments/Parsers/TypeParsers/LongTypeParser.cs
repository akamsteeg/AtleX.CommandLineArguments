﻿using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="long"/>
  /// </summary>
  public sealed class LongTypeParser
  : TypeParser<long>
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
    public override bool TryParse(string value, out long parseResult)
    {
      if (string.IsNullOrEmpty(value))
        throw new ArgumentNullException(nameof(value));

      var result = long.TryParse(value, out parseResult);
      return result;
    }
  }
}
