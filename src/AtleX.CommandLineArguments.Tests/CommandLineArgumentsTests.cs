using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Tests.Mocks;
using System;
using Xunit;

namespace AtleX.CommandLineArguments.Tests
{
  [Collection("NotInParallel")]
  public class CommandLineArgumentsTests
  {
    [Fact]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.TryParse<TestArguments>(null, out _));
    }

    [Fact]
    public void Configuration_SetNull_Throws()
    {
      var oldConfig = CommandLineArguments.Configuration;

      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.Configuration = null);

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Fact]
    public void Configuration_SetConfigWithoutParser_Throws()
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

    [Fact]
    public void Configuration_SetConfigWithoutHelpWriter_Throws()
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

    [Fact]
    public void ParserConfigurationProperty_SetToNullBeforeTryParse_ThrowsInvalidOperationException()
    {
      var oldConfig = CommandLineArguments.Configuration;

      var config = new CommandLineArgumentsConfiguration()
      {
        Parser = new MockParser(),
        HelpWriter = new MockHelpWriter()
      };

      CommandLineArguments.Configuration = config;

      config.Parser = null;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.TryParse<TestArguments>(new string[0], out _));

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Fact]
    public void HelpWriterConfigurationProperty_SetToNullBeforeTryParse_ThrowsInvalidOperationException()
    {
      var oldConfig = CommandLineArguments.Configuration;

      var config = new CommandLineArgumentsConfiguration()
      {
        Parser = new MockParser(),
        HelpWriter = new MockHelpWriter()
      };

      CommandLineArguments.Configuration = config;

      config.HelpWriter = null;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.DisplayHelp(new TestArguments()));

      CommandLineArguments.Configuration = oldConfig; // The beauty of static, we need to restore the configuration
    }

    [Fact]
    public void DisplayHelp_WithNullArgumentsObject_ThrowsArgumentNullException()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.DisplayHelp((TestArguments)null));
    }
  }
}
