using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Implementations.KdgPersonNumber.Fields;

namespace Kf.Numaris.Presentation.ConsoleApplicationExample
{
    class Program
    {
        private readonly IEnumerable<IExample> _examples;

        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            var program = container.Resolve<Program>();  
            
            program.RunExamples();

            Console.ReadKey();
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();            

            // This should be inside a seperate KdgNumberSpecification Module
            builder.RegisterType<KdgNumberFormatter>().As<INumberFormatter<KdgNumberSpecification>>();
            builder.RegisterType<CheckDigitsFieldSpecification>().As<IFieldSpecification<KdgNumberSpecification>>();
            builder.RegisterType<PersonNumberFieldSpecification>().As<IFieldSpecification<KdgNumberSpecification>>();
            builder.RegisterType<PersonNumberFieldFormatter>().As<IFieldFormatter<KdgNumberSpecification>>();
            builder.RegisterType<CheckDigitsFieldFormatter>().As<IFieldFormatter<KdgNumberSpecification>>();

            // This is application specific
            builder.RegisterType<Program>();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(IExample)))
                .Where(t => t.IsClass)
                .AsImplementedInterfaces();

            return builder.Build();
        }

        public Program(IEnumerable<IExample> examples)
            => _examples = examples;        

        private void RunExamples()
            => _examples.ToList()
                .ForEach(e =>
                {                    
                    ExecuteBeforeExample(e);
                    e.Run();
                    ExecuteAfterExample();
                });

        private void ExecuteBeforeExample(IExample example)
            => Console.WriteLine($"Running '{example.GetType().Name}'.");

        private void ExecuteAfterExample(IExample example = null)
            => Enumerable.Range(0, 2).ToList().ForEach(_ => Console.WriteLine());                
    }
}
