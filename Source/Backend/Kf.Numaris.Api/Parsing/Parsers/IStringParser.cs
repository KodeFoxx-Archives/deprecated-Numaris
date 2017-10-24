using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Parsing.Parsers
{
    public interface IStringParser<TNumberSpecification> : IParser<string, string[]>
        where TNumberSpecification : INumberSpecification
    {        
    }
}
