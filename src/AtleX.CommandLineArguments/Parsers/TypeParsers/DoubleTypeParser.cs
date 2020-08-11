namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="double"/>
  /// </summary>
  internal sealed class DoubleTypeParser
  : TypeParser<double>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out double parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = double.TryParse(value, out parseResult);
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
