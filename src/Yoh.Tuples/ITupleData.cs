namespace Yoh.Tuples
{
    internal interface ITupleData
    {
        int Length { get; }

        T GetValue<T>(int index);

        void SetValue<T>(int index, T value);

        TupleDataFactory AddValue<T>(int index, TupleDataFactory factory);

        TupleDataFactory RemoveValue(int index, TupleDataFactory factory);
    }
}
