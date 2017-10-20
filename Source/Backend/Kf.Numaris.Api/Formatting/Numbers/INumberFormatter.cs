using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Numbers
{
    public interface INumberFormatter : IFormatter
    {
        string Format(string[] input);
    }
}
