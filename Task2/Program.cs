using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            ParseOperations.Parse();

            clock.Stop();
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
