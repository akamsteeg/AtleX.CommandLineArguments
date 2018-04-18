using System;
using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Validators;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Configuration
{
  [TestFixture]
  public class CommandLineArgumentsConfigurationTests
  {
    [Test]
    public void Add_TypeParser_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((TypeParser)null));
    }

    [Test]
    public void Add_ArgumentValidator_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((ArgumentValidator)null));
    }
  }
}
