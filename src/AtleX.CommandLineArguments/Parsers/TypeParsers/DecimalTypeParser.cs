namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="decimal"/>
  /// </summary>
  internal sealed class DecimalTypeParser
  : TypeParser<decimal>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out decimal parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = decimal.TryParse(value, out parseResult);
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
