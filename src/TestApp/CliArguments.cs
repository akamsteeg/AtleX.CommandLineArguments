using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtleX.CommandLineArguments;

namespace TestApp
{
  internal sealed class CliArguments
    : Arguments
  {
    [Required(ErrorMessage = "ShowValidationErrors is required", AllowEmptyStrings = true)]
    public bool ShowValidationErrors
    {
      get;
      set;
    }
  }
}
