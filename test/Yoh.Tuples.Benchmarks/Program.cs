using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Yoh.Tuples.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args) =>
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
                .Run(args, DefaultConfig.Instance
                    .With(Job.Default.With(CoreRuntime.Core31))
                    //.With(Job.Default.With(CoreRtRuntime.CoreRt50))
                    .With(MemoryDiagnoser.Default));
    }
}