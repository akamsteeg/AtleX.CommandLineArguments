using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class ShortTypeParserTests
    : NonToggleTypeParserTests
  {
    public ShortTypeParserTests()
      : base(new ShortTypeParser())
    {

    }

    [Theory]
    [InlineData("0")]
    [InlineData("-127")]
    [InlineData("32767")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("32768")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-127")]
    [InlineData("32767")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-127")]
    [InlineData("32767")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
