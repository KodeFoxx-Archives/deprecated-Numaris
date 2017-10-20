using System;
using Kf.Numaris.Api.Specifications.Number;

namespace Kf.Numaris.Api.Parsing
{
    public abstract class NumberParser<TNumber> : INumberParser<TNumber>
        where TNumber : class, INumberSpecification<TNumber>
    {
        protected readonly string _baseExceptionString = $"Unable to parse given input to {typeof(TNumber).Name}.";

        public virtual string[] Parse(string input) =>
            throw new NotImplementedException($"{typeof(TNumber).Name} needs to have a parser implemented.");
    }
}
