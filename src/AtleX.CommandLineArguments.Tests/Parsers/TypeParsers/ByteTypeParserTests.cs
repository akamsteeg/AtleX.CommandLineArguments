using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class ByteTypeParserTests
    : NonToggleTypeParserTests
  {
    public ByteTypeParserTests()
      : base(new ByteTypeParser())
    {

    }

    [Theory]
    [InlineData("0")]
    [InlineData("128")]
    [InlineData("255")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("-256")]
    [InlineData("256")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("128")]
    [InlineData("255")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("128")]
    [InlineData("255")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
