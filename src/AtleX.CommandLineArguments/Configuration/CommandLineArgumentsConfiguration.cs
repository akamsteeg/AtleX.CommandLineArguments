using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

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
    /// 
    /// </summary>
    public List<TypeParser> TypeParsers
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="ICommandLineArgumentsParser"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public ICommandLineArgumentsParser Parser
    {
      get;
      protected set;
    }

    /// <summary>
    /// Gets the <see cref="HelpWriter"/> for this <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public HelpWriter HelpWriter
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
      this.TypeParsers = new List<TypeParser>();
    }

    /// <summary>
    /// Gets the default <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    public static CommandLineArgumentsConfiguration Default
    {
      get
      {
        var result = ConfigurationBuilder.For(new WindowsStyleCommandLineArgumentsParser())
          .With(new WindowsStyleHelpWriter())
          .With(new RequiredArgumentValidator())
          .With(new BoolTypeParser())
          .With(new ByteTypeParser())
          .With(new CharTypeParser())
          .With(new DateTimeTypeParser())
          .With(new DecimalTypeParser())
          .With(new DoubleTypeParser())
          .With(new FloatTypeParser())
          .With(new IntTypeParser())
          .With(new LongTypeParser())
          .With(new ShortTypeParser())
          .With(new StringTypeParser());

        return result;
      }
    }
  }
}
