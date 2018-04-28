using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  internal class DoubleTypeParserTests
    : NonToggleTypeParserTests<DoubleTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("0", "0.1", "10.11")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("a")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("0", "0.1", "10.11")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("0", "0.1", "10.11")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
