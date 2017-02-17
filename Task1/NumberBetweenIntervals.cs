using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
   public class NumberBetweenIntervals
    {
        public static List<double> FindNumberInInvervals(List<double> listOfOccuringIntegers)
        {

            List<double> numbersInIntervals = new List<double>();
            for (int i = 0; i < listOfOccuringIntegers.Count; i++)
            {
                if (i == 0 || i == listOfOccuringIntegers.Count - 1)
                {
                    numbersInIntervals.Add(listOfOccuringIntegers[i] + (listOfOccuringIntegers[i] / 2));
                }
                else
                {
                    numbersInIntervals.Add((listOfOccuringIntegers[i] + listOfOccuringIntegers[i + 1]) / 2);
                }
            }
            return numbersInIntervals;
        }
    }
}
