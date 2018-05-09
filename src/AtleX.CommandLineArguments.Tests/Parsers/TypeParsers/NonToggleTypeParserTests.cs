using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public abstract class NonToggleTypeParserTests
    : TypeParserTests
  {
    public NonToggleTypeParserTests(TypeParser parser)
      : base(parser)
    {

    }

    [Fact]
    public void EmptyArgument_ReturnsFalse()
    {
      Assert.False(this.typeParser.TryParse("", out _));
    }

    [Fact]
    public void NullArgument_ReturnsFalse()
    {
      Assert.False(this.typeParser.TryParse(null, out _));
    }

#pragma warning disable xUnit1013 // Public method should be marked as test
    public virtual void InvalidArgument_ReturnsFalse(string value)
#pragma warning restore xUnit1013 // Public method should be marked as test
    {
      var result = this.typeParser.TryParse(value, out _);

      Assert.False(result);
    }
  }
}
