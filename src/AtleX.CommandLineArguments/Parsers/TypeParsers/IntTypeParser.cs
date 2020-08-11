namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="int"/>
  /// </summary>
  internal sealed class IntTypeParser
  : TypeParser<int>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out int parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = int.TryParse(value, out parseResult);
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
