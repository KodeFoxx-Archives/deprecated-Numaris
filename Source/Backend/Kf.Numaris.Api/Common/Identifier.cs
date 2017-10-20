﻿using System;
using System.Linq;

namespace Kf.Numaris.Api.Common
{
    public sealed class Identifier
    {
        internal static Identifier For<TSupportedType>(Type type)
        {
            if (type.GetInterfaces().Contains(typeof(TSupportedType)))
                return new Identifier(type);

            throw new UnsupportedInterfaceException(supportedInterfaces: typeof(TSupportedType));
        }

        public string Id { get; }
        public string Name { get; }

        internal Identifier(Type type) : this(
            id: type.FullName,
            name: type.Name)
        { }

        internal Identifier(string id, string name)
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

            if (!(obj is Identifier other))
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
