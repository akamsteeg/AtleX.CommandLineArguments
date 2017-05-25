using System.ComponentModel.DataAnnotations;

namespace AtleX.CommandLineArguments.Benchmarks.Benches
{
  public class MockArguments
    : Arguments
  {
    [Required]
    public bool Toggle
    {
      get;
      set;
    }

    public string String
    {
      get;
      set;
    }

    public ArgumentValues Enum
    {
      get;
      set;
    }
  }

  public enum ArgumentValues
  {
    True,
    False,
    Maybe
  }
}
