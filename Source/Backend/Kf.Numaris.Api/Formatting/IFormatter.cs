using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Formatting
{
    public interface IFormatter
    {
        Identifier Identifier { get; }
        string Format(string input);
    }
}
