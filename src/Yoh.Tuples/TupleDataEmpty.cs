using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Yoh.Tuples
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    internal struct TupleDataEmpty : ITupleData
    {
        public int Length => 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue<T>(int index) =>
            throw new ArgumentOutOfRangeException(nameof(index));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue<T>(int index, T value) =>
            throw new ArgumentOutOfRangeException(nameof(index));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TupleDataFactory AddValue<T>(int index, TupleDataFactory factory) =>
            throw new NotSupportedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TupleDataFactory RemoveValue(int index, TupleDataFactory factory) =>
            throw new NotSupportedException();
    }
}
