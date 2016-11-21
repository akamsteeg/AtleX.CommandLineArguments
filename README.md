# AtleX.CommandLineArguments

AtleX.CommandLineArguments is a helper library to facilitate command line arguments into an object.

Supported .NET frameworks:
* .NET 4.5 or higher

# Example

```csharp
public class Program
{
	private class MyArgumentsClass
	{
		public bool HasArgument1
		{
			get;
			set;
		}
	}
	
	static void Main(string[] args)
	{
		var arguments = CommandLineArguments.Parse<MyArgumentsClass>(args);
		
		if (arguments.HasArgument1)
		{
			// ...
		}
	}
}
```

# License

AtleX.CommandLineArguments uses the MIT license, see the LICENSE file.
