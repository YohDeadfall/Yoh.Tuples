namespace Yoh.Tuples
{
    internal abstract class TupleDataFactory
    {
        public static readonly TupleDataFactory Empty = new EmptyTupleFactory();

        public abstract int Length { get; }

        public abstract TupleDataFactory AddValue<T>(T value);
        public abstract TupleDataFactory AddValue<T>(int index);
        public abstract TupleDataFactory RemoveValue(int index);

        public abstract ITupleData CreateData();

        private sealed class EmptyTupleFactory : TupleDataFactory
        {
            public override int Length => 0;

            public override TupleDataFactory AddValue<T>(T value) =>
                new TupleDataFactory<T, Unused, Unused, Unused, Unused, Unused, Unused, TupleDataEmpty>(
                    value, default, default, default, default, default, default, default);

            public override TupleDataFactory AddValue<T>(int index) =>
                new TupleDataEmpty().AddValue<T>(index, this);

            public override TupleDataFactory RemoveValue(int index) =>
                new TupleDataEmpty().RemoveValue(index, this);

            public override ITupleData CreateData() => TupleData.Empty;
        }
    }
}
