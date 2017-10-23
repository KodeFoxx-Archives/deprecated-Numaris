using System;
using System.Linq;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Presentation.ConsoleApplicationExample
{
    class FormattingExample : IExample
    {
        private readonly string[] _numbers = { "3331140", "003331140" };

        public void Run()
        {
            _numbers.ToList().ForEach(number =>
            {
                Console.WriteLine($"{number}");
            });
        }
    }
}
