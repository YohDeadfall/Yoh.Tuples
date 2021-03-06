﻿using System;
using System.Runtime.CompilerServices;

namespace Yoh.Tuples
{
    public sealed class Tuple
    {
        private ITupleData _data;

        public Tuple() =>
            _data = TupleData.Empty;

        internal Tuple(ITupleData data) =>
            _data = data;

        public int Length => _data.Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue<T>(int index) =>
            _data.GetValue<T>(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue<T>(int index, T value) =>
            _data.SetValue(index, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddValue<T>() => AddValue<T>(_data.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddValue<T>(T value) => AddValue<T>(_data.Length, value);

        public void AddValue<T>(int index)
        {
            var length = _data.Length;
            if (length == 0)
            {
                if (index != 0)
                    throw new ArgumentOutOfRangeException(nameof(index));

                // Fast construction without a factory
                _data = new TupleData<T, Unused, Unused, Unused, Unused, Unused, Unused, TupleDataEmpty>();
            }
            else
            {
                if (length < (uint)index)
                    throw new ArgumentOutOfRangeException(nameof(index));

                _data = _data
                    .AddValue<T>(index, TupleDataFactory.Empty)
                    .CreateData();
            }
        }

        public void AddValue<T>(int index, T value)
        {
            AddValue<T>(index);
            SetValue(index, value);
        }

        public void RemoveValue(int index)
        {
            var length = _data.Length;
            if (length <= (uint)index)
                throw new ArgumentOutOfRangeException(nameof(index));

            _data = length == 1
                ? TupleData.Empty
                : _data
                    .RemoveValue(index, TupleDataFactory.Empty)
                    .CreateData();
        }
    }
}
