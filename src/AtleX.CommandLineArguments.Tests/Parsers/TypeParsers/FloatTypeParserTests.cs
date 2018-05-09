using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class FloatTypeParserTests
    : NonToggleTypeParserTests
  {
    public FloatTypeParserTests()
      : base(new FloatTypeParser())
    {

    }

    [Theory]
    [InlineData("0")]
    [InlineData("0.1")]
    [InlineData("10.11")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("a")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("0.1")]
    [InlineData("10.11")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("0.1")]
    [InlineData("10.11")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
