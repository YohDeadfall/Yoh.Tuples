using System;
using System.Runtime.CompilerServices;

namespace Yoh.Tuples
{
    internal static class TupleData
    {
        public static readonly ITupleData Empty = new TupleDataEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTo As<TFrom, TTo>(ref TFrom value) =>
            IsAssignable<TFrom, TTo>.Value
                ? Unsafe.As<TFrom, TTo>(ref value)
                : throw new InvalidCastException();

        private static class IsAssignable<TFrom, TTo>
        {
            public static readonly bool Value = typeof(TTo).IsAssignableFrom(typeof(TFrom));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TupleDataFactory AddValueBefore<TNew, T>(this TupleDataFactory factory, int index, int before, T value)
        {
            if (index == before)
                factory = factory.AddValue(default(TNew));

            if (typeof(T) != typeof(Unused))
                factory = factory.AddValue(value);

            return factory;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TupleDataFactory AddValueExcept<T>(this TupleDataFactory factory, int index, int except, T value)
        {
            if (typeof(T) != typeof(Unused) && index != except)
                factory = factory.AddValue(value);

            return factory;
        }
    }
}
