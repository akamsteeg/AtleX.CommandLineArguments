using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a type parser for custom types
  /// </summary>
  public interface ITypeParser
  {
    /// <summary>
    /// Gets the <see cref="Type"/> this <see cref="ITypeParser"/> handles
    /// </summary>
    Type Type { get; }

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
    bool TryParse(string value, out object parseResult);
  }
}