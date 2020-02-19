using BenchmarkDotNet.Attributes;

namespace Yoh.Tuples.Benchmarks
{
    public abstract class MemberAccessBaseline<T>
    {
        private readonly IStorage _storage = new Storage();
        private readonly T _value;

        protected MemberAccessBaseline(T value) =>
            _value = value;

        [Benchmark]
        public T GetValueBaseline() =>
            _storage.Value;

        [Benchmark]
        public void SetValueBaseline() =>
            _storage.Value = _value;

        private interface IStorage
        {
            T Value { get; set; }
        }

        private class Storage : IStorage
        {
            public T Value { get; set; }
        }
    }
}