using System;
using System.ComponentModel.DataAnnotations;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestArguments
    : Arguments
  {
    #region Primitives
    public byte Byte
    {
      get;
      set;
    }

    public short Short
    {
      get;
      set;
    }
    public int Int
    {
      get;
      set;
    }
    public long Long
    {
      get;
      set;
    }

    public float Float
    {
      get;
      set;
    }
    public double Double
    {
      get;
      set;
    }

    public decimal Decimal
    {
      get;
      set;
    }

    public bool Bool
    {
      get;
      set;
    }


    public DateTime DateTime
    {
      get;
      set;
    }

    public char Char
    {
      get;
      set;
    }
    public string String
    {
      get;
      set;
    }
    #endregion

    #region Empty
    public bool Toggle
    {
      get;
      set;
    }
    #endregion


    #region Required
    [Required(ErrorMessage = "Required needs a value")]
    public bool Required
    {
      get;
      set;
    }

    [Required(ErrorMessage = "RequiredToggle needs a value", AllowEmptyStrings =true)]
    public bool RequiredToggle
    {
      get;
      set;
    }
    #endregion
  }
}
