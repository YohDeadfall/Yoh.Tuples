using BenchmarkDotNet.Attributes;

namespace Yoh.Tuples.Benchmarks
{
    public abstract class MemberAccess<T>
    {
        [Params(1, 8, 16, 32)]
        public int Length { get; set; }

        private Tuple _tuple;
        private readonly T _value;

        protected MemberAccess(T value) =>
            _value = value;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var factory = new TupleFactory();
            for (var i = 0; i < Length; i++)
                factory.AddValue<T>(i);

            _tuple = factory.CreateTuple();
        }

        [Benchmark]
        public T GetValue() =>
            _tuple.GetValue<T>(0);

        [Benchmark]
        public void SetValue() =>
            _tuple.SetValue(0, _value);
    }
}