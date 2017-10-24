using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Parsing.Parsers
{
    public abstract class StringParser<TNumberSpecification> : IStringParser<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public abstract string[] Parse(string input);
    }
}
