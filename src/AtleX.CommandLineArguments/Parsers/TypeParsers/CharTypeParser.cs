namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="char"/>
  /// </summary>
  internal sealed class CharTypeParser
  : TypeParser<char>
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
    public override bool TryParse(string value, out char parseResult)
    {
      var result = (!string.IsNullOrEmpty(value) && value.Length == 1);

      if (result)
      {
        parseResult = value[0];
      }
      else
      {
        parseResult = default;
      }

      return result;
    }
  }
}
