namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestArguments
    : Arguments
  {
    public override bool AreValid
    {
      get;
      protected set;
    }

    public string FirstKey
    {
      get;
      set;
    }

    public bool SecondKey
    {
      get;
      set;
    }

    public string ThirdKey
    {
      get;
      set;
    }
  }
}
