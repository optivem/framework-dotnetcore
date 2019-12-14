﻿using System;

namespace Optivem.Framework.Core.Domain
{
    public class Identity<TValue> : IEquatable<Identity<TValue>>, IComparable<Identity<TValue>> 
        where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        public Identity(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(Identity<TValue> other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object other)
        {
            var otherIdentity = other as Identity<TValue>;
            return Equals(otherIdentity);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(Identity<TValue> other)
        {
            return CompareTo(this, other);
        }

        public static bool operator ==(Identity<TValue> a, Identity<TValue> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Identity<TValue> a, Identity<TValue> b)
        {
            return !Equals(a, b);
        }

        public static bool operator <(Identity<TValue> a, Identity<TValue> b)
        {
            return CompareTo(a, b) < 0;
        }

        public static bool operator >(Identity<TValue> a, Identity<TValue> b)
        {
            return CompareTo(a, b) > 0;
        }

        public static bool operator <=(Identity<TValue> a, Identity<TValue> b)
        {
            return CompareTo(a, b) <= 0;
        }

        public static bool operator >=(Identity<TValue> a, Identity<TValue> b)
        {
            return CompareTo(a, b) >= 0;
        }

        private static bool Equals(Identity<TValue> a, Identity<TValue> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null))
            {
                return false;
            }

            if (ReferenceEquals(b, null))
            {
                return false;
            }

            if (a.GetType() != b.GetType())
            {
                return false;
            }

            return a.Value.Equals(b.Value);
        }

        private static int CompareTo(Identity<TValue> a, Identity<TValue> b)
        {
            if (ReferenceEquals(a, b))
            {
                return 0;
            }

            if (ReferenceEquals(a, null))
            {
                return -1;
            }

            if (ReferenceEquals(b, null))
            {
                return 1;
            }

            return a.Value.CompareTo(b.Value);
        }
    }
}