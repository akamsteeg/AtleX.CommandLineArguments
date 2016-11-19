using System;
using System.Reflection;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for setting property values in the <see cref="Arguments"/>
  /// </summary>
  /// <typeparam name="T">
  /// The <see cref="Arguments"/> type
  /// </typeparam>
  public class ArgumentPropertiesHelper<T>
      where T : Arguments, new()
  {
    /// <summary>
    /// Gets the cached <see cref="Type"/>
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/aa711900(v=vs.71).aspx
    /// </remarks>
    // PERF: By caching these, we avoid allocating them over and over again
    private readonly Type byteType,
      shortType,
      intType,
      longType,

      floatType,
      doubleType,

      decimalType,

      boolType,
      dateType,

      charType,
      stringType;

    /// <summary>
    /// Gets the collection of <see cref="PropertyInfo"/> for <see cref="{T}"/>
    /// </summary>
    private readonly PropertyInfo[] argumentProperties;

    /// <summary>
    /// Initializes a new instance of <see cref="ArgumentPropertiesHelper{T}"/>
    /// </summary>
    public ArgumentPropertiesHelper()
    {
      this.argumentProperties = typeof(T).GetProperties();

      // Cache the primitive types
      byteType = typeof(byte);
      shortType = typeof(short);
      intType = typeof(int);
      longType = typeof(long);

      floatType = typeof(float);
      doubleType = typeof(double);

      decimalType = typeof(decimal);

      boolType = typeof(bool);

      dateType = typeof(DateTime);

      charType = typeof(char);
      stringType = typeof(string);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arguments"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void FillProperty(T arguments, string key, string value)
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (string.IsNullOrWhiteSpace(key))
        throw new ArgumentNullException(nameof(key));
      
      foreach (var currentPropertyInfo in this.argumentProperties)
      {
        if (currentPropertyInfo.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
        {
          if (!TryFillPrimitiveProperty(arguments, currentPropertyInfo, value))
          {
            if (!currentPropertyInfo.PropertyType.IsEnum
              || !TryFillEnum(arguments, currentPropertyInfo, value))
            {
              // TODO Set other types
            }
          }
        }
      }
    }

    /// <summary>
    /// Try to set the primitive property for the specified <see
    /// cref="Arguments"/> with the specified name and value
    /// </summary>
    /// <param name="arguments">
    /// The <see cref="Arguments"/> instance to set the property in
    /// </param>
    /// <param name="property">
    /// The <see cref="PropertyInfo"/> of the property to set
    /// </param>
    /// <param name="value">
    /// The value to set
    /// </param>
    /// <returns>
    /// True when the property value could be set, false otherwise
    /// </returns>
    private bool TryFillPrimitiveProperty(T arguments, PropertyInfo property, string value)
    {
      bool result = false;

      var propertyType = property.PropertyType;

      // PERF Most used types first
      
      // String
      if (propertyType == this.stringType)
      {
        property.SetValue(arguments, value);
        result = true;
      }
      // Bool
      else if (propertyType == this.boolType)
      {
        bool propertyValue;
        if (result = bool.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Int
      else if (propertyType == this.intType)
      {
        int propertyValue;
        if (result = int.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // OTher primitive argument types
      // Byte
      else if (propertyType == this.byteType)
      {
        byte propertyValue;
        if (result = byte.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Short
      else if (propertyType == this.shortType)
      {
        short propertyValue;
        if (result = short.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Long
      else if (propertyType == this.longType)
      {
        long propertyValue;
        if (result = long.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Float
      else if (propertyType == this.floatType)
      {
        float propertyValue;
        if (result = float.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Double
      else if (propertyType == this.doubleType)
      {
        double propertyValue;
        if (result = double.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Decimal
      else if (propertyType == this.decimalType)
      {
        decimal propertyValue;
        if (result = decimal.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Date
      else if (propertyType == this.dateType)
      {
        DateTime propertyValue;
        if (result = DateTime.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Char
      else if (propertyType == this.charType)
      {
        char propertyValue;
        if (result = char.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }

      return result;
    }

    /// <summary>
    /// Set
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private bool TryFillEnum(T arguments, PropertyInfo property, string value)
    {
      var result = false;

      var enumType = property.PropertyType;

      if (result = enumType.IsEnumDefined(value) == true)
      {
        var propertyValue = Enum.Parse(property.PropertyType, value, true);

        property.SetValue(arguments, propertyValue);
      }

      return result;
    }
  }
}
