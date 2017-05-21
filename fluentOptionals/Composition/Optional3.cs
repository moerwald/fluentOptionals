﻿using System;

namespace FluentOptionals.Composition
{
    public struct Optional<T1, T2, T3> :
        IEquatable<Optional<T1, T2, T3>>
    {
        private readonly Optional<T1> _o1;
        private readonly Optional<T2> _o2;
        private readonly Optional<T3> _o3;

        internal Optional(Optional<T1> o1, Optional<T2> o2, Optional<T3> o3)
        {
            _o1 = o1;
            _o2 = o2;
            _o3 = o3;
        }

        public bool IsSome => _o1.IsSome() && _o2.IsSome() && _o3.IsSome();
        public bool IsNone => !IsSome;

        public void Match(Action<T1, T2, T3> some, Action none)
        {
            if (IsSome)
                some(_o1.ValueOrDefault(), _o2.ValueOrDefault(), _o3.ValueOrDefault());
            else
                none();
        }

        public TReturn Match<TReturn>(Func<T1, T2, T3, TReturn> some, Func<TReturn> none)
        {
            return IsSome
                ? some(_o1.ValueOrDefault(), _o2.ValueOrDefault(), _o3.ValueOrDefault())
                : none();
        }

        public void IfSome(Action<T1, T2, T3> handle)
        {
            Match(handle, () => { });
        }

        public void IfNone(Action handle)
        {
            Match((o1, o2, o3) => { }, handle);
        }

        public Optional<T1, T2, T3, T4> Join<T4>(T4 valueToJoin)
        {
            return new Optional<T1, T2, T3, T4>(_o1, _o2, _o3, Optional.From(valueToJoin));
        }

        public Optional<T1, T2, T3, T4> Join<T4>(T4 valueToJoin, Func<T4, bool> condition)
        {
            return new Optional<T1, T2, T3, T4>(_o1, _o2, _o3, Optional.From(valueToJoin, condition));
        }

        public Optional<T1, T2, T3, T4> Join<T4>(Optional<T4> optionalToJoin)
        {
            return new Optional<T1, T2, T3, T4>(_o1, _o2, _o3, optionalToJoin);
        }

        #region Equals

        public bool Equals(Optional<T1, T2, T3> other)
        {
            return _o1.Equals(other._o1) && _o2.Equals(other._o2) && _o2.Equals(other._o3);
        }

        #endregion
    }
}