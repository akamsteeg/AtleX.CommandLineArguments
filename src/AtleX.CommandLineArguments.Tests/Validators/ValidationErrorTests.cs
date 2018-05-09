using System;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Validators
{
  public class ValidationErrorTests
  {
    [Fact]
    public void Ctor_WithNullArgumentName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError(null, "validatorName", ""));
    }

    [Fact]
    public void Ctor_WithEmptyArgumentName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("", "validatorName", ""));
    }

    [Fact]
    public void Ctor_WithNullValidatorName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("argumentName", null, ""));
    }

    [Fact]
    public void Ctor_WithEmptyValidatorName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("argumentName", "", ""));
    }

    [Fact]
    public void Ctor_WithEmptyValidatorErrorMessage_DoesNotThrow()
    {
      new ValidationError("argumentName", "validatorName", "");
    }
  }
}
