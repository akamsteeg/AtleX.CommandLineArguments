namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="string"/>
  /// </summary>
  internal sealed class StringTypeParser
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
      bool result = true; // Everything is valid, even empty strings

      if (!string.IsNullOrEmpty(value))
      {
        parseResult = value; // Yeah, this is silly
      }
      else
      {
        parseResult = string.Empty;
      }

      return result;
    }
  }
}
