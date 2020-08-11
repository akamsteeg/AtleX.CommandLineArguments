namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="long"/>
  /// </summary>
  internal sealed class LongTypeParser
  : TypeParser<long>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out long parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = long.TryParse(value, out parseResult);
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
