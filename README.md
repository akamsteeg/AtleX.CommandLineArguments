# AtleX.CommandLineArguments

AtleX.CommandLineArguments is a helper library to facilitate parsing command line arguments into an object.

Supported .NET frameworks:
* .NET 4.5
* .NET 4.6
* NETSTANDARD 1.5

# Installation

AtleX.CommandLineArguments is available [as NuGet package](https://www.nuget.org/packages/AtleX.CommandLineArguments/):

```
install-package AtleX.CommandLineArguments -Pre
```


# Example

```csharp
public class Program
{
	private class MyArgumentsClass : Arguments
	{
		public bool Argument1
		{
			get;
			set;
		}
	}
	
	static void Main(string[] args)
	{
		MyArgumentsClass cliArguments;
		if (!CommandLineArguments.TryParse<MyArgumentsClass>(args, out cliArguments))
		{
			// Something wrong, exit or display help?
			CommandLineArguments.DisplayHelp(cliArguments);
			return;
		}

		if (cliArguments.Argument1)
		{
		
		}
	}
}
```

# License

AtleX.CommandLineArguments uses the MIT license, see the LICENSE file.
