using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ParseInequalities
    {
       public static readonly char[] separators = new char[] { ' ' };
        public static List<double> Parse()
        {
            SortedSet<double> occuringIntegers = new SortedSet<double>();
            using (StreamReader reader = new StreamReader(@"D:\Projects\Exam-2nd-Edition\Task1\bin\Sample5000+.txt"))
            {
                string line = "";
                
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    occuringIntegers.Add(Convert.ToDouble(parts[parts.Length - 1]));
                }             
            }
            return occuringIntegers.ToList();
        }

    }
}
