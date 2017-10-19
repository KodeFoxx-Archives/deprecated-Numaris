using System;

namespace Kf.Numaris.Api.Specifications.Concrete
{
    public enum KdgStudentNumberSpecificationFields
    {
        StudentNumber, StudentNumberMod97
    }

    public enum KdgStudentNumberSpecificationRules
    {
        FieldStudentNumberMod97_HasToBeEqualTo_Mod97_Of_FieldStudentNumber
    }

    public sealed class KdgStudentNumberSpecification : IConcreteNumberSpecification
    {
        public INumberSpecification Create()
        {
            return NumberSpecification
                .New()
                .WithName(nameof(KdgStudentNumberSpecification))
                .WithField(FieldSpecification.New()
                    .WithName(KdgStudentNumberSpecificationFields.StudentNumber)
                    .Build()
                )
                .WithField(FieldSpecification.New()
                    .WithName(KdgStudentNumberSpecificationFields.StudentNumberMod97)
                    .DependsOnField(KdgStudentNumberSpecificationFields.StudentNumber)
                    .WithRule(RuleSpecification.New()
                        .WithName(KdgStudentNumberSpecificationRules.FieldStudentNumberMod97_HasToBeEqualTo_Mod97_Of_FieldStudentNumber)
                        .WithAlgorithm((studentNumberAsString, mod97Value) =>
                        {
                            if (Int32.TryParse(studentNumberAsString, out var studentNumber))
                                return (studentNumber % 97).ToString() == mod97Value;

                            return false;
                        })
                        .Build()
                    )
                    .Build()
                )
                .Build();
        }
    }
}
