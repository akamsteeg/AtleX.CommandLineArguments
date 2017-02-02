using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;

namespace AtleX.CommandLineArguments.Tests
{
  [TestFixture]
  public class CommandLineArgumentsTests
  {
    [Test]
    public void Parse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.Parse<TestArguments>(null));
    }

    [Test]
    public void Parse_WithoutConfiguration_Throws()
    {
      CommandLineArguments.Configuration = null;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.Parse<TestArguments>(new string[0]));
    }

    [Test]
    public void Parse_WithoutParser_Throws()
    {
      CommandLineArguments.Configuration = new TestCommandLineArgumentsConfiguration(null);

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.Parse<TestArguments>(new string[0]));
    }
  }
}
