namespace Kf.Numaris.Api.Specifications.Numbers
{
    public abstract class NumberSpecification : INumberSpecification
    {
        public NumberType NumberType => NumberType.FromNumberSpecification(GetType());
    }
}
