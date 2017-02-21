using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch clock = Stopwatch.StartNew();
            List<double> listOfOccuringIntegers = ParseInequalities.Parse();
            List<double> numbersInInterval = NumberBetweenIntervals.FindNumberInInvervals(listOfOccuringIntegers);

            listOfOccuringIntegers.AddRange(numbersInInterval);
            listOfOccuringIntegers = listOfOccuringIntegers.OrderBy(x => x).ToList();

            List<string> subset;
            List<string> maxSubset = new List<string>();

            foreach (var line in listOfOccuringIntegers)
            {
                subset = MaximumSubset.FindMaxSubset(line);
                if (maxSubset.Count < subset.Count)
                {
                    maxSubset = subset;
                }
            }

            Console.WriteLine("\nCount of inequalities is: {0}", maxSubset.Count);

            foreach (var item in maxSubset)
            {
                Console.WriteLine(item);
            }

            clock.Stop();
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
