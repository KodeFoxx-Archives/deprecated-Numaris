using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kf.Numaris.Presentation.ConsoleApplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.RunExamples();

            Console.ReadKey();
        }

        private void RunExamples()
            => GetExamples().ToList()
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

        private IEnumerable<IExample> GetExamples()
            => typeof(Program).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IExample)))
                .Where(t => t.IsClass)
                .Select(t => Activator.CreateInstance(t) as IExample);
    }
}
