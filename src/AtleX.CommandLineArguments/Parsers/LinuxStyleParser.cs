﻿using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Linux CLI style ("--key value --key2 value2
  /// --toggle") command line arguments parser
  /// </summary>
  public sealed class LinuxStyleParser
    : PrefixedKeyParser
  {
    /// <summary>
    /// Gets the prefix that indicates a key
    /// </summary>
    private const string KeyPrefix = "--";
    
    /// <summary>
    /// Gets the complete argument that indicates that the user requested help
    /// </summary>
    private const string HelpArgument = KeyPrefix + "help";

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="LinuxStyleParser"/>
    /// </summary>
    public LinuxStyleParser()
      : base(KeyPrefix)
    {
    }
    
    /// <summary>
    /// Gets whether the specified command line arguments contain a Help argument or not
    /// </summary>
    /// <param name="allCommandLineArguments">
    /// The collection of all command line arguments
    /// </param>
    /// <returns>
    /// True when the collection of command line arguments contains a Help argument, false otherwise
    /// </returns>
    protected override bool ContainsHelpArgument(string[] allCommandLineArguments)
    {
      var result = false;

      for (var i = 0; i < allCommandLineArguments.Length; i++)
      {
        var currentArgumentName = allCommandLineArguments[i];
        
        if (currentArgumentName == HelpArgument)
        {
          result = true;
          break;
        }
      }

      return result;
    }
  }
}
