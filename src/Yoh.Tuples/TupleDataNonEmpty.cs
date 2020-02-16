using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Yoh.Tuples
{
    [StructLayout(LayoutKind.Auto)]
    internal struct TupleData<T1, T2, T3, T4, T5, T6, T7, TRest> : ITupleData
        where TRest : struct, ITupleData
    {
        public static readonly int Start = default(TRest).Length;

        public static readonly int LengthLocal = 0 +
            (typeof(T1) == typeof(Unused) ? 0 : 1) +
            (typeof(T2) == typeof(Unused) ? 0 : 1) +
            (typeof(T3) == typeof(Unused) ? 0 : 1) +
            (typeof(T4) == typeof(Unused) ? 0 : 1) +
            (typeof(T5) == typeof(Unused) ? 0 : 1) +
            (typeof(T6) == typeof(Unused) ? 0 : 1) +
            (typeof(T7) == typeof(Unused) ? 0 : 1);

        public TRest Rest;
        public T1 Member1;
        public T2 Member2;
        public T3 Member3;
        public T4 Member4;
        public T5 Member5;
        public T6 Member6;
        public T7 Member7;

        public int Length => Start + LengthLocal;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue<T>(int index)
        {
            return (index - Start) switch
            {
                0 => TupleData.As<T1, T>(ref Member1),
                1 => TupleData.As<T2, T>(ref Member2),
                2 => TupleData.As<T3, T>(ref Member3),
                3 => TupleData.As<T4, T>(ref Member4),
                4 => TupleData.As<T5, T>(ref Member5),
                5 => TupleData.As<T6, T>(ref Member6),
                6 => TupleData.As<T7, T>(ref Member7),
                7 => TupleData.As<T7, T>(ref Member7),
                _ => Rest.GetValue<T>(index),
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue<T>(int index, T value)
        {
            switch (index - Start)
            {
                case 0: Member1 = TupleData.As<T, T1>(ref value); return;
                case 1: Member2 = TupleData.As<T, T2>(ref value); return;
                case 2: Member3 = TupleData.As<T, T3>(ref value); return;
                case 3: Member4 = TupleData.As<T, T4>(ref value); return;
                case 4: Member5 = TupleData.As<T, T5>(ref value); return;
                case 5: Member6 = TupleData.As<T, T6>(ref value); return;
                case 6: Member7 = TupleData.As<T, T7>(ref value); return;
                case 7: Member7 = TupleData.As<T, T7>(ref value); return;
                default: Rest.SetValue(index, value); return;
            }
        }

        public TupleDataFactory AddValue<T>(int index, TupleDataFactory factory)
        {
            if(typeof(TRest) != typeof(TupleDataEmpty))
                factory = Rest.AddValue<T>(index, factory);

            var localIndex = index - Start;
            if ((uint)localIndex >= LengthLocal)
            {
                factory = factory
                    .AddValue(Member1)
                    .AddValue(Member2)
                    .AddValue(Member3)
                    .AddValue(Member4)
                    .AddValue(Member5)
                    .AddValue(Member6)
                    .AddValue(Member7);

                if (localIndex == LengthLocal)
                    factory = factory.AddValue(default(T));

                return factory;
            }

            return factory
                .AddValueBefore<T, T1>(0, localIndex, Member1)
                .AddValueBefore<T, T2>(1, localIndex, Member2)
                .AddValueBefore<T, T3>(2, localIndex, Member3)
                .AddValueBefore<T, T4>(3, localIndex, Member4)
                .AddValueBefore<T, T5>(4, localIndex, Member5)
                .AddValueBefore<T, T6>(5, localIndex, Member6)
                .AddValueBefore<T, T7>(6, localIndex, Member7);
        }

        public TupleDataFactory RemoveValue(int index, TupleDataFactory factory)
        {
            if (typeof(TRest) != typeof(TupleDataEmpty))
                factory = Rest.RemoveValue(index, factory);

            var localIndex = index - Start;
            if ((uint)localIndex >= LengthLocal)
                return factory
                    .AddValue(Member1)
                    .AddValue(Member2)
                    .AddValue(Member3)
                    .AddValue(Member4)
                    .AddValue(Member5)
                    .AddValue(Member6)
                    .AddValue(Member7);

            return factory
                .AddValueExcept(0, localIndex, Member1)
                .AddValueExcept(1, localIndex, Member2)
                .AddValueExcept(2, localIndex, Member3)
                .AddValueExcept(3, localIndex, Member4)
                .AddValueExcept(4, localIndex, Member5)
                .AddValueExcept(5, localIndex, Member6)
                .AddValueExcept(6, localIndex, Member7);
        }
    }
}
