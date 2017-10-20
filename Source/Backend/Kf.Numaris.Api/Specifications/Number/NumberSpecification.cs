using System;
using Kf.Numaris.Api.Parsing;

namespace Kf.Numaris.Api.Specifications.Number
{
    public abstract class NumberSpecification<TNumberSpecification> : INumberSpecification<TNumberSpecification>
        where TNumberSpecification : class, INumberSpecification<TNumberSpecification>
    {
        protected readonly INumberParser<TNumberSpecification> _numberParser;

        protected NumberSpecification(INumberParser<TNumberSpecification> numberParser)
            => _numberParser = numberParser ?? throw new ArgumentNullException(nameof(numberParser));
    }
}
