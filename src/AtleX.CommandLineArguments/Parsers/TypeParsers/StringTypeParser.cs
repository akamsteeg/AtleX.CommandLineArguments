namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="string"/>
  /// </summary>
  internal sealed class StringTypeParser
  : TypeParser<string>
  {
    /// <inheritdoc />
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
