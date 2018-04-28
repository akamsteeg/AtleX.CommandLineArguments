using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  internal class ShortTypeParserTests
    : NonToggleTypeParserTests<ShortTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("0", "-127", "32767")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("a", "32768")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("0", "-127", "32767")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("0", "-127", "32767")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
