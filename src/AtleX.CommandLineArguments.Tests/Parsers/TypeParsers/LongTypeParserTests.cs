using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class LongTypeParserTests
    : NonToggleTypeParserTests
  {
    public LongTypeParserTests()
      : base(new LongTypeParser())
    {

    }

    [Theory]
    [InlineData("-10")]
    [InlineData("0")]
    [InlineData("10")]
    [InlineData("9223372036854775807")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("0.1")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("-10")]
    [InlineData("0")]
    [InlineData("10")]
    [InlineData("9223372036854775807")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("-10")]
    [InlineData("0")]
    [InlineData("10")]
    [InlineData("9223372036854775807")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
