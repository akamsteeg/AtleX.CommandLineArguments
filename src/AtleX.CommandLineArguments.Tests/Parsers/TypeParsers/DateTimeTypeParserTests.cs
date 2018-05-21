using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public class DateTimeTypeParserTests
    : NonToggleTypeParserTests
  {
    public DateTimeTypeParserTests()
      : base(new DateTimeTypeParser())
    {

    }

    [Theory]
    [InlineData("01-02-1903")]
    [InlineData("01-01-2000 00:00:01")]
    [InlineData("december 25, 2100 17:00")]
    public override void ValidArgument_ReturnsTrue(string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Theory]
    [InlineData("aa")]
    [InlineData("60:61")]
    [InlineData("32-13-9999")]
    public override void InvalidArgument_ReturnsFalse(string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Theory]
    [InlineData("01-02-1903")]
    [InlineData("01-01-2000 00:00:01")]
    [InlineData("december 25, 2100 17:00")]
    public override void ValidArgument_OutArgumentIsNotNull(string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Theory]
    [InlineData("01-02-1903")]
    [InlineData("01-01-2000 00:00:01")]
    [InlineData("december 25, 2100 17:00")]
    public override void ValidArgument_OutParamIsOfValidType(string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
