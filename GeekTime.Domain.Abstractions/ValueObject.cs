using System.Collections.Generic;
using System.Linq;

namespace GeekTime.Domain.Abstractions
{
    public abstract class ValueObject
    {
        private static bool EqualHelper(object left, object right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            return EqualHelper(left, right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var other = (ValueObject)obj;

            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while(thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (!EqualHelper(thisValues.Current, otherValues.Current)) return false;
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
