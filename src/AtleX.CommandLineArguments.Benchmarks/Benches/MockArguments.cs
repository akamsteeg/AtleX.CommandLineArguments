using System;
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

    [Required]
    public string String
    {
      get;
      set;
    }

    [Required]
    public int Int
    {
      get;
      set;
    }

    [Required]
    public DateTime DateTime
    {
      get;
      set;
    }

    [Required]
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
