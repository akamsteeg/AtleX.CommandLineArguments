﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a writer for help information for the arguments
  /// </summary>
  public abstract class HelpWriter
  {
    /// <summary>
    /// Gets the cached <see cref="Type"/> of <see cref="DisplayAttribute"/>
    /// </summary>
    private readonly Type cachedDisplayAttributeType;

    /// <summary>
    /// Gets the cached <see cref="Type"/> of <see cref="RequiredAttribute"/>
    /// </summary>
    private readonly Type cachedRequiredAttributeType;

    /// <summary>
    /// Initializes a new instance of <see cref="HelpWriter"/>
    /// </summary>
    public HelpWriter()
    {
      this.cachedDisplayAttributeType = typeof(DisplayAttribute);
      this.cachedRequiredAttributeType = typeof(RequiredAttribute);
    }

    /// <summary>
    /// Write the help for the specified <see cref="Arguments"/> object
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="Arguments"/> to write the help for
    /// </typeparam>
    /// <param name="argumentsToWriteHelpFor">
    /// The <see cref="Arguments"/> object to write the help for
    /// </param>
    public abstract void Write<T>(T argumentsToWriteHelpFor)
      where T : Arguments, new();

    /// <summary>
    /// Get the help details for the specified <see cref="Arguments"/> object
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="Arguments"/> to get the <see
    /// cref="IEnumerable{T}"/> of <see cref="ArgumentHelpDetails"/> for
    /// </typeparam>
    /// <param name="argumentsObject">
    /// The <see cref="Arguments"/> to get the <see cref="IEnumerable{T}"/> of
    /// <see cref="ArgumentHelpDetails"/> for
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable{T}"/> of <see cref="ArgumentHelpDetails"/> or
    /// the specified <see cref="Arguments"/> object
    /// </returns>
    protected IEnumerable<ArgumentHelpDetails> GetHelpDetails<T>(T argumentsObject)
      where T: Arguments, new()
    {
      if (argumentsObject == null)
        throw new ArgumentNullException(nameof(argumentsObject));

      var result = new List<ArgumentHelpDetails>();

      var allProperties = argumentsObject.GetType().GetTypeInfo().DeclaredProperties;

      foreach (var currentProperty in allProperties)
      {
        var exactUsageName = GetExactCommandlineNameOfArgument(currentProperty.Name);

        var description = this.GetDisplayDescription(currentProperty);
        var isRequired = this.IsRequiredArgument(currentProperty);

        var helpDetails = new ArgumentHelpDetails(exactUsageName, description, isRequired);

        result.Add(helpDetails);
      }

      return result;
    }

    /// <summary>
    /// Gets the exact name of an argument how it should be used on the command
    /// line, including prefixes
    /// </summary>
    /// <param name="argumentName">
    /// The name of the argument to get the exact commandline usage for
    /// </param>
    /// <returns>
    /// The exact name of an argument how it should be used on the command line,
    /// including prefixes
    /// </returns>
    protected abstract string GetExactCommandlineNameOfArgument(string argumentName);


    /// <summary>
    /// Get the description from the <see cref="DisplayAttribute"/> on the
    /// specified <see cref="PropertyInfo"/>, if any
    /// </summary>
    /// <param name="property">
    /// The <see cref="PropertyInfo"/> to get the description from the <see
    /// cref="DisplayAttribute"/> from
    /// </param>
    /// <returns>
    /// The description from the <see cref="DisplayAttribute"/> on the
    /// specified <see cref="PropertyInfo"/>, if any
    /// </returns>
    protected string GetDisplayDescription(PropertyInfo property)
    {
      var result = string.Empty;

      var displayAttribute = property.GetCustomAttribute(cachedDisplayAttributeType) as DisplayAttribute;

      if (displayAttribute != null)
      {
        result = displayAttribute.Description;
      }

      return result;
    }

    /// <summary>
    /// Determine whether the specified <see cref="PropertyInfo"/> is a required
    /// argument or not
    /// </summary>
    /// <param name="property">
    /// The <see cref="PropertyInfo"/> to check for being a required argument or not
    /// </param>
    /// <returns>
    /// True when the specified <see cref="PropertyInfo"/> is a required
    /// argument, false otherwise
    /// </returns>
    protected bool IsRequiredArgument(PropertyInfo property)
    {
      var result = false;

      var requiredAttribute = property.GetCustomAttribute(cachedRequiredAttributeType) as RequiredAttribute;

      if (requiredAttribute != null)
      {
        result = true;
      }

      return result;
    }
  }
}