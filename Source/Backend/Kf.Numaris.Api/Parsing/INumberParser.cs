using Kf.Numaris.Api.Specifications.Number;

namespace Kf.Numaris.Api.Parsing
{
    public interface INumberParser<TNumber>
        where TNumber : class, INumberSpecification<TNumber>
    {
        string[] Parse(string input);
    }
}
