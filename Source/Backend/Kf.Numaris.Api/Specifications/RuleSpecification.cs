using System;
using System.Reflection;
using Kf.Numaris.Api.Specifications.Builders;

namespace Kf.Numaris.Api.Specifications
{
    public sealed class RuleSpecification : Specification
    {
        public static RuleSpecificationBuilder New()
            => new RuleSpecificationBuilder();

        public Func<string, string, bool> Algorithm { get; }

        internal RuleSpecification(
            string name,
            Func<string, string, bool> algorithm)
            : base(name)
            => Algorithm = algorithm;
    }
}
