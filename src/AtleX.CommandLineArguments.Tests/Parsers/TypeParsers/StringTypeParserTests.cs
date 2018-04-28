using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  internal class StringTypeParserTests
    : ToggleTypeParserTests<StringTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("", "arguments")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    // It's a string, nothing is invalid. So no, I didn't forget to check for the invalid values

    //[Test]
    //public override void InvalidArgument_ReturnsFalse([Values("a")] string value)
    //{
    //  base.InvalidArgument_ReturnsFalse(value);
    //}

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("", "arguments")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("", "arguments")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
