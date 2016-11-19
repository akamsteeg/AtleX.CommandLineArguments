using AtleX.CommandLineArguments.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// 
  /// </summary>
  public abstract class CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Gets the <see cref="CommandLineArgumentsParser"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsParser Parser
    {
      get;
      protected set;
    }
  }
}
