using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class StringTypeParserTests
    : ToggleTypeParserTests
  {
    public StringTypeParserTests()
      : base(new StringTypeParser())
    {

    }

    [Theory]
    [InlineData("")]
    [InlineData("arguments")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    // It's a string, nothing is invalid. So no, I didn't forget to check for the invalid values

    //[Fact]
    //public override void InvalidArgument_ReturnsFalse([Values("a")] string value)
    //{
    //  base.InvalidArgument_ReturnsFalse(value);
    //}

    [Theory]
    [InlineData("")]
    [InlineData("arguments")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("arguments")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
