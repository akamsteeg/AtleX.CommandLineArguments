namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a <see cref="TypeParser{T}"/> for <see cref="byte"/>
  /// </summary>
  internal sealed class ByteTypeParser
  : TypeParser<byte>
  {
    /// <inheritdoc />
    public override bool TryParse(string value, out byte parseResult)
    {
      bool result;

      if (!string.IsNullOrEmpty(value))
      {
        result = byte.TryParse(value, out parseResult);
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
