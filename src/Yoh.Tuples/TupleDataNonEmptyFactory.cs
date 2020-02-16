namespace Yoh.Tuples
{
    internal sealed class TupleDataFactory<T1, T2, T3, T4, T5, T6, T7, TRest> : TupleDataFactory
        where TRest : struct, ITupleData
    {
        public override int Length => default(TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>).Length;

        private TupleData<T1, T2, T3, T4, T5, T6, T7, TRest> _data;

        public TupleDataFactory(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, in TRest rest) =>
            _data = new TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>
            {
                Member1 = value1,
                Member2 = value2,
                Member3 = value3,
                Member4 = value4,
                Member5 = value5,
                Member6 = value6,
                Member7 = value7,
                Rest = rest
            };

        public override TupleDataFactory AddValue<T>(T value) =>
            TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>.LengthLocal switch
            {
                0 => new TupleDataFactory<T, Unused, Unused, Unused, Unused, Unused, Unused, TRest>(
                    value, default, default, default, default, default, default, _data.Rest),
                1 => new TupleDataFactory<T1, T, Unused, Unused, Unused, Unused, Unused, TRest>(
                    _data.Member1, value, default, default, default, default, default, _data.Rest),
                2 => new TupleDataFactory<T1, T2, T, Unused, Unused, Unused, Unused, TRest>(
                    _data.Member1, _data.Member2, value, default, default, default, default, _data.Rest),
                3 => new TupleDataFactory<T1, T2, T3, T, Unused, Unused, Unused, TRest>(
                    _data.Member1, _data.Member2, _data.Member3, value, default, default, default, _data.Rest),
                4 => new TupleDataFactory<T1, T2, T3, T4, T, Unused, Unused, TRest>(
                    _data.Member1, _data.Member2, _data.Member3, _data.Member4, value, default, default, _data.Rest),
                5 => new TupleDataFactory<T1, T2, T3, T4, T5, T, Unused, TRest>(
                    _data.Member1, _data.Member2, _data.Member3, _data.Member4, _data.Member5, value, default, _data.Rest),
                6 => new TupleDataFactory<T1, T2, T3, T4, T5, T6, T, TRest>(
                    _data.Member1, _data.Member2, _data.Member3, _data.Member4, _data.Member5, _data.Member6, value, _data.Rest),
                _ => new TupleDataFactory<T, Unused, Unused, Unused, Unused, Unused, Unused, TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>>(
                    value, default, default, default, default, default, default, _data)
            };

        public override TupleDataFactory AddValue<T>(int index) =>
            new TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>().AddValue<T>(index, this);

        public override TupleDataFactory RemoveValue(int index) =>
            new TupleData<T1, T2, T3, T4, T5, T6, T7, TRest>().RemoveValue(index, this);

        public override ITupleData CreateData() => _data;
    }
}
