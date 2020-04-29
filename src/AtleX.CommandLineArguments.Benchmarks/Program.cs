﻿using AtleX.CommandLineArguments.Benchmarks.Benches;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;
using System;
using System.Reflection;

namespace AtleX.CommandLineArguments.Benchmarks
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var config = GetConfig();

      BenchmarkSwitcher
        .FromAssembly(Assembly.GetExecutingAssembly())
        .Run(args, config);

      //BenchmarkRunner.Run<StringExtensionsBenchmarks>(config);
    }

    private static IConfig GetConfig()
    {
      var config = ManualConfig.Create(DefaultConfig.Instance);

      config.AddDiagnoser(MemoryDiagnoser.Default);


      config.AddJob(
        Job.Default.WithToolchain(CsProjCoreToolchain.NetCoreApp31).AsBaseline(),
        Job.Default.WithToolchain(CsProjCoreToolchain.NetCoreApp21),
        Job.Default.WithToolchain(CsProjClassicNetToolchain.Net48)
        );

      return config;
    }
  }
}
