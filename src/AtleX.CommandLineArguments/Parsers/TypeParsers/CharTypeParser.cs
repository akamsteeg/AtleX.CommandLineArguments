namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="char"/>
  /// </summary>
  internal sealed class CharTypeParser
  : TypeParser<char>
  {
    /// <inheritdoc />
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
