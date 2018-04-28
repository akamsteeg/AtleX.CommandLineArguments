using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;

namespace AtleX.CommandLineArguments.Tests
{
  [TestFixture]
  internal class CommandLineArgumentsTests
  {
    [Test]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.TryParse<TestArguments>(null, out _));
    }

    [Test]
    public void Configuration_SetNull_Throws()
    {
      var oldConfig = CommandLineArguments.Configuration;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.Configuration = null);

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Test]
    public void Configuration_SetConfigWithoutParser_Throws()
    {
      var oldConfig = CommandLineArguments.Configuration;

      var newConfig = new CommandLineArgumentsConfiguration()
      {
        Parser = new MockParser(),
        HelpWriter = null
      };

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.Configuration = newConfig);

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Test]
    public void Configuration_SetConfigWithoutHelpWriter_Throws()
    {
      var oldConfig = CommandLineArguments.Configuration;

      var newConfig = new CommandLineArgumentsConfiguration()
      {
        Parser = null,
        HelpWriter = new MockHelpWriter()
      };

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.Configuration = newConfig);

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }
  }
}
