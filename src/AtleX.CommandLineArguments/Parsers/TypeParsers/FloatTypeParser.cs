namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="float"/>
  /// </summary>
  internal sealed class FloatTypeParser
  : TypeParser<float>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out float parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = float.TryParse(value, out parseResult);
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
