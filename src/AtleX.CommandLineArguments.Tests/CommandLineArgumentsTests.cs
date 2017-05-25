using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;
using AtleX.CommandLineArguments.Validators;
using System.Collections.Generic;

namespace AtleX.CommandLineArguments.Tests
{
  [TestFixture]
  public class CommandLineArgumentsTests
  {
    [Test]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => CommandLineArguments.TryParse<TestArguments>(null, out TestArguments a));
    }

    [Test]
    public void TryParse_WithoutConfiguration_Throws()
    {
      CommandLineArguments.Configuration = null;

      Assert.Throws<InvalidOperationException>(() => CommandLineArguments.TryParse<TestArguments>(new string[0], out TestArguments a));
    }
  }
}
