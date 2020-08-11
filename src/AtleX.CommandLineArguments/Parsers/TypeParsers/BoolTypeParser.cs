namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="bool"/>
  /// </summary>
  internal sealed class BoolTypeParser
  : TypeParser<bool>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out bool parseResult)
    {
      bool result;

      if (string.IsNullOrEmpty(value))
      {
        parseResult = true;
        result = true;
      }
      else
      {
        result = bool.TryParse(value, out parseResult);
      }

      return result;
    }
  }
}
