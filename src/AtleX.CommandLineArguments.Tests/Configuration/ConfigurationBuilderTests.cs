using System;
using System.Linq;
using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Configuration
{
  [TestFixture]
  public class ConfigurationBuilderTests
  {
    [Test]
    public void ConfigurationBuilderFor_NoParser_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => ConfigurationBuilder.For(null));
    }

    [Test]
    public void ConfigurationBuilderFor_WithParser()
    {
      var configuration = ConfigurationBuilder.For(new WindowsStyleCommandLineArgumentsParser());

      Assert.IsNotNull(configuration);
      Assert.IsNotNull(configuration.Parser);
    }

    [Test]
    public void ConfigurationBuilderFor_WithArgumentValidator()
    {
      var configuration = ConfigurationBuilder
        .For(new WindowsStyleCommandLineArgumentsParser())
        .With(new RequiredArgumentValidator());

      Assert.IsNotNull(configuration);
      Assert.IsNotNull(configuration.Validators);
      Assert.IsTrue(configuration.Validators.Any(x => x.GetType() == typeof(RequiredArgumentValidator)));
    }
  }
}
