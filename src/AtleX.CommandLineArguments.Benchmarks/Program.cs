using System;
using AtleX.CommandLineArguments.Benchmarks.Benches;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace AtleX.CommandLineArguments.Benchmarks
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = GetConfig();
      var benchmarks = GetBenchmarks();

      for (var i = 0; i < benchmarks.Length; i++)
      {
        var typeToRun = benchmarks[i];
        BenchmarkRunner.Run(typeToRun, config);
      }

      //BenchmarkRunner.Run<StringExtensionsBenchmarks>(config);
    }

    private static Type[] GetBenchmarks()
    {
      var result = new Type[]
      {
        typeof(CommandLineArgumentsBenchmarks),
      };

      return result;
    }

    private static IConfig GetConfig()
    {
      var config = ManualConfig.Create(DefaultConfig.Instance);

      config.Add(MemoryDiagnoser.Default);

      config.Add(Job.Core);
      config.Add(Job.Clr);

      return config;
    }
  }
}
