using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;
using System;

namespace Kf.Numaris.Presentation.ConsoleApplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var specification = new KdgNumberSpecification();            
            Console.WriteLine(specification.Identifier);

            Console.ReadLine();
        }
    }
}
