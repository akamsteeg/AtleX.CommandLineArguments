using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using System;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the configuration for <see cref="AtleX.CommandLineArguments.CommandLineArguments"/>
  /// </summary>
  public class CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/>
    /// to validate the command line arguments with
    /// </summary>
    public IEnumerable<ArgumentValidator> Validators
    {
      get
      {
        return this._validators;
      }
    }

    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="TypeParser"/> to
    /// parse the command line arguments with
    /// </summary>
    public IEnumerable<TypeParser> TypeParsers
    {
      get
      {
        return this._typeParsers;
      }
    }

    /// <summary>
    /// Gets the <see cref="List{T}"/> of <see cref="ArgumentValidator"/> to
    /// validate the command line arguments with
    /// </summary>
    private readonly List<ArgumentValidator> _validators;

    /// <summary>
    /// Gets the <see cref="List{T}"/> of <see cref="TypeParser"/> to
    /// parse the command line arguments with
    /// </summary>
    private readonly List<TypeParser> _typeParsers;

    /// <summary>
    /// Gets the <see cref="ICommandLineArgumentsParser"/> to parse the command
    /// line arguments with
    /// </summary>
    public ICommandLineArgumentsParser Parser
    {
      get;
      set;
    }

    /// <summary>
    /// Gets the <see cref="IHelpWriter"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public IHelpWriter HelpWriter
    {
      get;
      set;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsConfiguration()
    {
      this._validators = new List<ArgumentValidator>()
      {
          new RequiredArgumentValidator(),
      };

      this._typeParsers = new List<TypeParser>()
      {
        /*
        This is ordered by most likely type parsers first so searching
        for the correct type parser can be slightly faster for the most
        used types
        */
        new StringTypeParser(),
        new BoolTypeParser(),
        new IntTypeParser(),

        new FloatTypeParser(),
        new DoubleTypeParser(),
        new DateTimeTypeParser(),

        new ByteTypeParser(),
        new CharTypeParser(),
        new DecimalTypeParser(),
        new LongTypeParser(),
        new ShortTypeParser(),
      };
    }

    /// <summary>
    /// Add the specified <see cref="ArgumentValidator"/> to the validators to
    /// use for validating the commandline arguments
    /// </summary>
    /// <param name="validator">
    /// The <see cref="ArgumentValidator"/> to add
    /// </param>
    public void Add(ArgumentValidator validator)
    {
      _ = validator ?? throw new ArgumentNullException(nameof(validator));

      this._validators.Add(validator);
    }

    /// <summary>
    /// Add the specified <see cref="TypeParser"/> to the type parsers to
    /// use for parsing the commandline arguments
    /// </summary>
    /// <param name="typeParser">
    /// The <see cref="TypeParser"/> to add
    /// </param>
    public void Add(TypeParser typeParser)
    {
      _ = typeParser ?? throw new ArgumentNullException(nameof(typeParser));

      this._typeParsers.Add(typeParser);
    }
  }
}
