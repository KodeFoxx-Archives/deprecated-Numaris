namespace Kf.Numaris.Api.Specifications.Concrete.KdgStudentNumber
{
    public sealed class KdgStudentNumberSpecification : IConcreteNumberSpecification
    {
        public INumberSpecification Create()
        {
            return NumberSpecification
                .New()
                .WithName(nameof(KdgStudentNumberSpecification))
                .Build();
        }
    }
}
