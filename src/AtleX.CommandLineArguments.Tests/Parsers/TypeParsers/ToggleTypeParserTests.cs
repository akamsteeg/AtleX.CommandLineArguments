using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public abstract class ToggleTypeParserTests
    : TypeParserTests
  {
    public ToggleTypeParserTests(TypeParser parser)
      : base(parser)
    {

    }

    [Fact]
    public void EmptyArgument_ReturnsTrue()
    {
      var result = this.typeParser.TryParse("", out _);

      Assert.True(result);
    }
  }
}
