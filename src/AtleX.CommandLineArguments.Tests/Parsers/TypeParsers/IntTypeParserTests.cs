using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  public class IntTypeParserTests
    : NonToggleTypeParserTests<IntTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("-10", "0", "10")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("a", "0.1")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("-10", "0", "10")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("-10", "0", "10")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
