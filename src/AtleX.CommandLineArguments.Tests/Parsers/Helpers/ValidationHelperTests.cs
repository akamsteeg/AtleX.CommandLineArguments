using System;
using System.Collections.Generic;
using System.Linq;
using AtleX.CommandLineArguments.Parsers.Helpers;
using AtleX.CommandLineArguments.Tests.Mocks;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.Helpers
{
  public class ValidationHelperTests
  {
    [Fact]
    public void TryValidate_WithNullValidatorsArgument_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        ValidationHelper.TryValidate(null, null, true, "", out _)
      );
    }

    [Fact]
    public void TryValidate_WithNullPropertyInfoArgument_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        ValidationHelper.TryValidate(Enumerable.Empty<ArgumentValidator>(), null, true, "", out _)
      );
    }

    [Fact]
    public void TryValidate_WithValidArguments_Succeeds()
    {
      var validators = new List<ArgumentValidator>()
      {
        new RequiredArgumentValidator(),
      };

      var propertyInfo = typeof(TestArguments).GetProperties().First();

      ValidationHelper.TryValidate(validators, propertyInfo, true, "", out _);
    }
  }
}
 