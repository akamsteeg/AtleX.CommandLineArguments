using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;

namespace AtleX.CommandLineArguments.Tests
{
  [TestFixture]
  public class CommandLineArgumentsTests
  {
    [Test]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.TryParse<TestArguments>(null, out _));
    }

    [Test]
    public void TryParse_WithoutConfiguration_Throws()
    {
      var oldConfig = CommandLineArguments.Configuration;

      CommandLineArguments.Configuration = null;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.TryParse<TestArguments>(new string[0], out _));

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Test]
    public void TryParse_WithEmptyArgumentsAndDefaultConfiguration_Succeeds()
    {
      Assert.DoesNotThrow(() => CommandLineArguments.TryParse<TestArguments>(new string[0], out _));
    }

    [Test]
    public void TryParse_WithUnknownArgumentsAndDefaultConfiguration_Succeeds()
    {
      var cliArgs = new string[] { "lorem", "ipsum" };

      Assert.DoesNotThrow(() => CommandLineArguments.TryParse<TestArguments>(cliArgs, out _));
    }
  }
}
