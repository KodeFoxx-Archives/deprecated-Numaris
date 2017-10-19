using System;

namespace Kf.Numaris.Api.Specifications
{
    public abstract class Specification : ISpecification
    {
        public string Name { get; }

        protected Specification(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Specification's name can not be left blank");

            Name = name;
        }
    }
}
