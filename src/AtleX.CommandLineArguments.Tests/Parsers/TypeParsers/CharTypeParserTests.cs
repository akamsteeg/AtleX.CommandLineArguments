using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  public class CharTypeParserTests
    : NonToggleTypeParserTests<CharTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("a", "A")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("aa", "AA")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("a", "A")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("a", "A")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }

    [Test]
    public void ValidArgument_MatchesOutput([Values("a", "A")] string value)
    {
      this.typeParser.TryParse(value, out var parseResult);

      Assert.AreEqual(value[0], parseResult);
    }
  }
}
