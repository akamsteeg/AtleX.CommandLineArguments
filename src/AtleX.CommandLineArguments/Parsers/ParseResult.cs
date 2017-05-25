using System;
using System.Collections.Generic;
using System.Diagnostics;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  [DebuggerDisplay("Is valid: {IsValid}")]
  public class ParseResult<T>
    where T : Arguments, new()
  {
    /// <summary>
    /// 
    /// </summary>
    public T Arguments
    {
      get;
    }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults
    {
      get;
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsValid
    {
      get
      {
        var result = true;
        foreach (var currentValidationResult in ValidationResults)
        {
          if (!currentValidationResult.IsValid)
          {
            result = false;
            break;
          }
        }

        return result;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="argumentsObject"></param>
    /// <param name="validationResults"></param>
    public ParseResult(T argumentsObject, IEnumerable<ValidationResult> validationResults)
    {
      this.Arguments = argumentsObject ?? throw new ArgumentNullException(nameof(argumentsObject));
            this.ValidationResults = validationResults ?? throw new ArgumentNullException(nameof(validationResults));
    }
  }
}
