using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class BoolTypeParserTests
    : TypeParserTests
  {

    public BoolTypeParserTests()
      : base(new BoolTypeParser())
    {

    }

    [Fact]
    public void InvalidArgument_ReturnsTrue_WithParseResultFalse()
    {
      var result = this.typeParser.TryParse("maybe", out var parseResult);

      Assert.False(result);
      Assert.IsType<bool>(parseResult);
      Assert.False((bool)parseResult);
    }

    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
