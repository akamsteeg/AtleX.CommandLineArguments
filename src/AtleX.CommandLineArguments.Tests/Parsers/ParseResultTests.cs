using System;
using System.Linq;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  public class ParseResultTests
  {
    [Fact]
    public void Ctor_WithNullCommandLineArguments_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => 
        new ParseResult<TestArguments>(null, Enumerable.Empty<ValidationError>()));
    }

    [Fact]
    public void Ctor_WithNullValidationErrors_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ParseResult<TestArguments>(new TestArguments(), null));
    }
  }
}
