using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Kf.Numaris.Api.Specifications.Concrete;
using Xunit;

namespace Kf.Numaris.Api.Tests
{
    public class CodeSanityChecks
    {
        private static string _numarisApiNamespace = "Kf.Numaris.Api";
        private static string _numarisApiSpecificationsNamespace = $"{_numarisApiNamespace}.Specifications";
        private static string _numarisApSpecificationsConcreteNamespace = $"{_numarisApiSpecificationsNamespace}.Concrete";

        public static IEnumerable<Type> GetTypesInSpecificationsNamespace()
            => Assembly.Load(_numarisApiNamespace).GetTypes()
                .Where(t => t.Namespace.StartsWith(_numarisApiSpecificationsNamespace));

        public static IEnumerable<object[]> All_specification_classes_inside_the_specification_namespace_should_be_marked_as_sealed_data()
            => GetTypesInSpecificationsNamespace()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new object[] { t.Name, t });

        [Theory,
         MemberData(nameof(All_specification_classes_inside_the_specification_namespace_should_be_marked_as_sealed_data))]
        public void All_specification_classes_inside_the_specification_namespace_should_be_marked_as_sealed(string name, Type type)
            => Assert.True(type.IsSealed);

        public static IEnumerable<Type> GetTypesInSpecificationsConcreteNamespace()
            => Assembly.Load(_numarisApiNamespace).GetTypes()
                .Where(t => t.Namespace.StartsWith(_numarisApSpecificationsConcreteNamespace));

        public static IEnumerable<object[]>
            All_IConcreteNumberSpecifications_inside_the_concrete_namespace_create_a_NumberSpecification_with_its_class_name_data()
            => GetTypesInSpecificationsConcreteNamespace()
                .Where(t => t.IsClass && t.IsSealed)
                .Where(t => t.GetInterfaces().Contains(typeof(IConcreteNumberSpecification)))
                .Select(t => new object[] { t.Name, (IConcreteNumberSpecification)Activator.CreateInstance(t) });

        [Theory,
         MemberData(nameof(All_IConcreteNumberSpecifications_inside_the_concrete_namespace_create_a_NumberSpecification_with_its_class_name_data))]
        public void All_IConcreteNumberSpecifications_inside_the_concrete_namespace_create_a_NumberSpecification_with_its_class_name(string name, IConcreteNumberSpecification concreteNumberSpecification)
        {
            var expectedName = concreteNumberSpecification.GetType().Name;

            var sut = concreteNumberSpecification.Create();

            Assert.Equal(expectedName, sut.Name);
        }
    }
}
