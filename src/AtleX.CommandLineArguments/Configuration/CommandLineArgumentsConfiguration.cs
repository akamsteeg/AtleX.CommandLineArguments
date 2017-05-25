using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the configuration for <see cref="AtleX.CommandLineArguments.CommandLineArguments"/>
  /// </summary>
  public abstract class CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Gets the <see cref="List{T}"/> of <see cref="ArgumentValidator"/> to
    /// validate the command line arguments with
    /// </summary>
    public List<ArgumentValidator> Validators
    {
      get;
      set;
    }

    /// <summary>
    /// Gets the <see cref="CommandLineArgumentsParser"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsParser Parser
    {
      get;
      protected set;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsConfiguration()
    {
      this.Validators = new List<ArgumentValidator>();
    }
  }
}
