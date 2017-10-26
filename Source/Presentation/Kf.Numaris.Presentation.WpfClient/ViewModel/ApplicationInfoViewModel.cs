using System.Collections.Generic;
using System.Reflection;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Presentation.WpfClient.ViewModel
{
    public sealed class ApplicationInfoViewModel
    {
        public IEnumerable<INumberSpecification> NumberSpecifications { get; }
        public IEnumerable<Assembly> LoadedAssemblies { get; }

        public ApplicationInfoViewModel(
            IEnumerable<Assembly> loadedAssemblies,
            IEnumerable<INumberSpecification> numberSpecifications)
        {
            LoadedAssemblies = loadedAssemblies;
            NumberSpecifications = numberSpecifications;
        }
    }
}
