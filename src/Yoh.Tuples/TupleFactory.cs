using System;

namespace Yoh.Tuples
{
    public sealed class TupleFactory
    {
        private TupleDataFactory _internal;

        public TupleFactory() =>
            _internal = TupleDataFactory.Empty;

        public void AddValue<T>(int index, T defaultValue = default)
        {
            if ((uint)index > _internal.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            _internal = _internal.AddValue(defaultValue);
        }

        public void RemoveValue(int index)
        {
            if ((uint)index >= _internal.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            _internal = _internal.RemoveValue(index);
        }

        public Tuple CreateTuple() =>
            new Tuple(_internal.CreateData());
    }
}
