using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  internal class ByteTypeParserTests
    : NonToggleTypeParserTests<ByteTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("0", "128", "255")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("-256", "256")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("0", "128", "255")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("0", "128", "255")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
