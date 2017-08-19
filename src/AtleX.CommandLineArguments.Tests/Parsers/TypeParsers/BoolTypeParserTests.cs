using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  public class BoolTypeParserTests
    : TypeParserTests<BoolTypeParser>
  {
    [Test]
    public void InvalidArgument_ReturnsTrue_WithParseResultFalse()
    {
      var result = this.typeParser.TryParse("maybe", out var parseResult);

      Assert.IsFalse(result);
      Assert.IsInstanceOf<bool>(parseResult);
      Assert.IsFalse((bool)parseResult);
    }

    [Test]
    public override void ValidArgument_ReturnsTrue([Values("true", "false")]string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("true", "false")]string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    [Test]
    public override void ValidArgument_OutParamIsOfValidType([Values("true", "false")]string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
