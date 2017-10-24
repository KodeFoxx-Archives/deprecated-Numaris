namespace Kf.Numaris.Api.Parsing
{
    public interface IParser<TInput, TOutput>
    {
        TOutput Parse(TInput input);
    }
}
