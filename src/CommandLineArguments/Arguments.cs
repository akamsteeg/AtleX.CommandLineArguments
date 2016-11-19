﻿namespace AtleX.CommandLineArguments
{
  /// <summary>
  /// Represents the commandline arguments
  /// </summary>
  public abstract class Arguments
  {
    /// <summary>
    /// Indicates whether these <see cref="Arguments"/>
    /// are valid
    /// </summary>
    /// <returns>
    /// True when all values are valid, false otherwise
    /// </returns>
    public abstract bool IsValid();
  }
}
