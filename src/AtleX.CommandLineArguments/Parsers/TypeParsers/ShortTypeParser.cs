namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="short"/>
  /// </summary>
  internal sealed class ShortTypeParser
  : TypeParser<short>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out short parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = short.TryParse(value, out parseResult);
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
