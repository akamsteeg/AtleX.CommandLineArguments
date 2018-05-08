using System;
using AtleX.CommandLineArguments.Validators;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Validators
{
  [TestFixture]
  public class ValidationErrorTests
  {
    [Test]
    public void Ctor_WithNullArgumentName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError(null, "validatorName", ""));
    }

    [Test]
    public void Ctor_WithEmptyArgumentName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("", "validatorName", ""));
    }

    [Test]
    public void Ctor_WithNullValidatorName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("argumentName", null, ""));
    }

    [Test]
    public void Ctor_WithEmptyValidatorName_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        new ValidationError("argumentName", "", ""));
    }

    [Test]
    public void Ctor_WithEmptyValidatorErrorMessage_DoesNotThrow()
    {
      Assert.DoesNotThrow(() =>
        new ValidationError("argumentName", "validatorName", ""));
    }
  }
}
