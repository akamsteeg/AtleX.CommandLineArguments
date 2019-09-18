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
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/>
    /// to validate the command line arguments with
    /// </summary>
    public IEnumerable<IArgumentValidator> Validators
    {
      get
      {
        return this._validators;
      }
    }

    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to
    /// parse the command line arguments with
    /// </summary>
    public IEnumerable<ITypeParser> TypeParsers
    {
      get
      {
        return this._typeParsers;
      }
    }

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
    /// Gets the <see cref="List{T}"/> of <see cref="IArgumentValidator"/> to
    /// validate the command line arguments with
    /// </summary>
    private readonly List<IArgumentValidator> _validators;

    /// <summary>
    /// Gets the <see cref="List{T}"/> of <see cref="ITypeParser"/> to
    /// parse the command line arguments with
    /// </summary>
    private readonly List<ITypeParser> _typeParsers;

    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public CommandLineArgumentsConfiguration()
    {
      this._validators = CreateBuiltInValidators();

      this._typeParsers = CreateBuiltInTypeParsers();
    }

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="CommandLineArgumentsConfiguration"/> with the specified <see cref="IArgumentValidator"/>
    /// </summary>
    /// <param name="argumentValidator">
    /// The <see cref="IArgumentValidator"/> to use in addition to the built-in validators
    /// </param>
    public CommandLineArgumentsConfiguration(IArgumentValidator argumentValidator)
      : this()
    {
      _ = argumentValidator ?? throw new ArgumentNullException(nameof(argumentValidator));

      this._validators.Add(argumentValidator);
    }

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="CommandLineArgumentsConfiguration"/> with the specified <see
    /// cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/>
    /// </summary>
    /// <param name="argumentValidators">
    /// The <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/> to
    /// use in addition to the built-in validators
    /// </param>
    public CommandLineArgumentsConfiguration(IEnumerable<IArgumentValidator> argumentValidators)
      : this()
    {
      _ = argumentValidators ?? throw new ArgumentNullException(nameof(argumentValidators));

      this._validators.AddRange(argumentValidators);
    }

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="CommandLineArgumentsConfiguration"/> with the specified <see cref="ITypeParser"/>
    /// </summary>
    /// <param name="typeParser">
    /// The <see cref="ITypeParser"/> to use in addition to the built-in validators
    /// </param>
    public CommandLineArgumentsConfiguration(ITypeParser typeParser)
      : this()
    {
      _ = typeParser ?? throw new ArgumentNullException(nameof(typeParser));

      this._typeParsers.Add(typeParser);
    }

    /// <summary>
    /// Initializes a new instance of <see
    /// cref="CommandLineArgumentsConfiguration"/> with the specified <see
    /// cref="IEnumerable{T}"/> of <see cref="ITypeParser"/>
    /// </summary>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to
    /// use in addition to the built-in validators
    /// </param>
    public CommandLineArgumentsConfiguration(IEnumerable<ITypeParser> typeParsers)
      : this()
    {
      _ = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));

      this._typeParsers.AddRange(typeParsers);
    }

    /// <summary>
    /// Add the specified <see cref="IArgumentValidator"/> to the validators to
    /// use for validating the commandline arguments
    /// </summary>
    /// <param name="validator">
    /// The <see cref="IArgumentValidator"/> to add
    /// </param>
    public void Add(IArgumentValidator validator)
    {
      _ = validator ?? throw new ArgumentNullException(nameof(validator));

      this._validators.Add(validator);
    }

    /// <summary>
    /// Add the specified <see cref="ITypeParser"/> to the type parsers to
    /// use for parsing the commandline arguments
    /// </summary>
    /// <param name="typeParser">
    /// The <see cref="TypeParser"/> to add
    /// </param>
    public void Add(ITypeParser typeParser)
    {
      _ = typeParser ?? throw new ArgumentNullException(nameof(typeParser));

      this._typeParsers.Add(typeParser);
    }

    /// <summary>
    /// Add the specified <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/> to the validators to
    /// use for validating the commandline arguments
    /// </summary>
    /// <param name="validators">
    /// The <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/> to add
    /// </param>
    public void AddRange(IEnumerable<IArgumentValidator> validators)
    {
      _ = validators ?? throw new ArgumentNullException(nameof(validators));

      this._validators.AddRange(validators);
    }

    /// <summary>
    /// Add the specified <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to the validators to
    /// use for parsing the commandline arguments
    /// </summary>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to add
    /// </param>
    public void AddRange(IEnumerable<ITypeParser> typeParsers)
    {
      _ = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));

      this._typeParsers.AddRange(typeParsers);
    }

    /// <summary>
    /// Create a <see cref="List{T}"/> with an instance of all built-in type validators
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> with an instance of all built-in type validators
    /// </returns>
    private static List<IArgumentValidator> CreateBuiltInValidators()
    {
      var result = new List<IArgumentValidator>()
      {
          new RequiredArgumentValidator(),
      };

      return result;
    }

    /// <summary>
    /// Create a <see cref="List{T}"/> with an instance of all built-in type parsers
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> with an instance of all built-in type parsers
    /// </returns>
    private static List<ITypeParser> CreateBuiltInTypeParsers()
    {
      /*
       * PERF
       * 
       * A List<T> has an initial capacity of 4 and doubles when the capacity is 
       * reached (4, 8, 16, etc.). We  want to avoid too much resizing so we
       * set the initial capacity to the next larger power of two that's larger 
       * than or equal to the number of built-in type parsers we add
       */
      var result = new List<ITypeParser>(16)
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

      return result;
    }
  }
}
