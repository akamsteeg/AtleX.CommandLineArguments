using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  [TestFixture]
  internal class DateTimeTypeParserTests
    : NonToggleTypeParserTests<DateTimeTypeParser>
  {
    [Test]
    public override void ValidArgument_ReturnsTrue([Values("01-02-1903", "01-01-2000 00:00:01", "december 25, 2100 17:00")] string value)
    {
      base.ValidArgument_ReturnsTrue(value);
    }

    [Test]
    public override void InvalidArgument_ReturnsFalse([Values("aa", "60:61", "32-13-9999")] string value)
    {
      base.InvalidArgument_ReturnsFalse(value);
    }

    [Test]
    public override void ValidArgument_OutArgumentIsNotNull([Values("01-02-1903", "01-01-2000 00:00:01", "december 25, 2100 17:00")] string value)
    {
      base.ValidArgument_OutArgumentIsNotNull(value);
    }

    public override void ValidArgument_OutParamIsOfValidType([Values("01-02-1903", "01-01-2000 00:00:01", "december 25, 2100 17:00")] string value)
    {
      base.ValidArgument_OutParamIsOfValidType(value);
    }
  }
}
