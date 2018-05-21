using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class CharTypeParserTests
    : NonToggleTypeParserTests

  {
    public CharTypeParserTests() 
      : base(new CharTypeParser())
    {
    }

    [Theory]
    [InlineData("a")]
    [InlineData("A")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("aa")]
    [InlineData("AA")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("A")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("A")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("A")]
    public void ValidArgument_MatchesOutput(string value)
    {
      this.typeParser.TryParse(value, out var parseResult);

      Assert.Equal(value[0], parseResult);
    }
  }
}
