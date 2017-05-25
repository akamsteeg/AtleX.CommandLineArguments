using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
﻿using System;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the configuration for <see cref="AtleX.CommandLineArguments.CommandLineArguments"/>
  /// </summary>
  public class CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Gets the <see cref="List{T}"/> of <see cref="ArgumentValidator"/> to
    /// validate the command line arguments with
    /// </summary>
    public List<ArgumentValidator> Validators
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="CommandLineArgumentsParser"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsParser Parser
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="CommandLineArgumentsConfiguration"/> with the specified <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    /// <param name="parser">
    /// The <see cref="CommandLineArgumentsParser"/> to use
    /// </param>
    public CommandLineArgumentsConfiguration(CommandLineArgumentsParser parser)
    {
      this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
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
