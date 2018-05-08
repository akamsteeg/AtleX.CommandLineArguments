using System;
using System.Linq;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using AtleX.CommandLineArguments.Validators;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  [TestFixture]
  public class ParseResultTests
  {
    [Test]
    public void Ctor_WithNullCommandLineArguments_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => 
        new ParseResult<TestArguments>(null, Enumerable.Empty<ValidationError>()));
    }

    [Test]
    public void Ctor_WithNullValidationErrors_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ParseResult<TestArguments>(new TestArguments(), null));
    }
  }
}
