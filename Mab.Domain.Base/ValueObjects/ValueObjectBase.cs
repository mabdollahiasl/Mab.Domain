using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.ValueObjects
{
    public abstract class ValueObjectBase
    {
        public static bool operator ==(ValueObjectBase one, ValueObjectBase two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObjectBase one, ValueObjectBase two)
        {
            return NotEqualOperator(one, two);
        }
        protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            return !(EqualOperator(left, right));
        }


        protected virtual IEnumerable<object> GetEqualityComponents()
        {
            var publicProperties=this.GetType().GetProperties();
            foreach (var property in publicProperties)
            {
                var propertyValue=property.GetValue(this);
                yield return propertyValue;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObjectBase)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
