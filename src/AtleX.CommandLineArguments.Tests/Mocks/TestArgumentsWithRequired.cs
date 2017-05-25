using System.ComponentModel.DataAnnotations;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestArgumentsWithRequired
    : TestArguments
  {
    #region Required
    [Required(ErrorMessage = "IsRequired needs a value")]
    public bool IsRequired
    {
      get;
      set;
    }
    #endregion
  }
}
