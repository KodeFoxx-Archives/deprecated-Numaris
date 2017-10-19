namespace Kf.Numaris.Api.Specifications.Builders
{
    public interface ISpecificationBuilder<TSpecification>
        where TSpecification : ISpecification
    {
        ISpecificationBuilder<TSpecification> WithName(string name);
        TSpecification Build();
    }
}
