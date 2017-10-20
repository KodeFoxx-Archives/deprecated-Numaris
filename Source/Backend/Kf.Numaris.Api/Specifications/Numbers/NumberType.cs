using System;
using System.Diagnostics;
using System.Linq;
using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Specifications.Numbers
{
    public class NumberType
    {
        internal static NumberType FromNumberSpecification(Type type)
        {
            if (type.GetInterfaces().Contains(typeof(INumberSpecification)))
                return new NumberType(type);

            throw new UnsupportedInterfaceException(supportedInterfaces: typeof(INumberSpecification));
        }

        public string Id { get; }
        public string Name { get; }

        internal NumberType(Type type) : this(
            id: type.FullName,
            name: type.Name)
        { }

        internal NumberType(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (!(obj is NumberType other))
                return false;

            return other.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Name.GetHashCode();

            return hash;
        }
    }
}
