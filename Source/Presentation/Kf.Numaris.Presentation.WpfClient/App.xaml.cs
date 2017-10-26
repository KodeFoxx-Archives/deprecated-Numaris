using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Autofac;
using Kf.Numaris.Presentation.WpfClient.ViewModel;

namespace Kf.Numaris.Presentation.WpfClient
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = BuildContainer();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            var loadedReferencedAssemblies = LoadAssemblies().ToList();

            builder.RegisterAssemblyModules(
                loadedReferencedAssemblies.ToArray()
            );

            builder.RegisterInstance<IEnumerable<Assembly>>(loadedReferencedAssemblies);
            builder.RegisterType<ApplicationInfoViewModel>();
            builder.RegisterType<MainWindow>();

            return builder.Build();
        }

        private IEnumerable<Assembly> LoadAssemblies()
            => LoadReferencesAssemblies()
                .Concat(LoadAssembliesInStartupLocation("Kf.Numaris.Implementations"))
                .Distinct();

        private IEnumerable<Assembly> LoadReferencesAssemblies()
            => Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Select(LoadAssemblyOrNull)
                .Where(assembly => assembly != null);

        private IEnumerable<Assembly> LoadAssembliesInStartupLocation(params string[] matchingNamespaces)
            => Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .Where(file => file.ToLower().EndsWith("dll"))
                .Where(file => matchingNamespaces.Any(ns => file.ToLower().Contains(ns.ToLower())))
                .Where(File.Exists)
                .Select(LoadAssemblyOrNull)
                .Where(assembly => assembly != null);

        private Assembly LoadAssemblyOrNull(string path)
        {
            try
            {
                return Assembly.LoadFile(path);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private Assembly LoadAssemblyOrNull(AssemblyName assemblyName)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
