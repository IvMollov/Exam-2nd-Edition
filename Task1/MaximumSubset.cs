using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
  public  class MaximumSubset : ParseInequalities
    {
        public static List<string> FindMaxSubset(double x)
        {
            List<string> subset = new List<string>();
            using (StreamReader reader = new StreamReader(@"D:\Projects\Exam\Exam\Task1\bin\Sample5000+.txt"))
            {
                string line = "";
                

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    if (parts[1] == "=")
                    {
                        if (x == Convert.ToInt32(parts[2]))
                        {
                            subset.Add(line);
                        }
                    }
                    else if (parts[1] == ">=")
                    {
                        if (x >= Convert.ToInt32(parts[2]))
                        {
                            subset.Add(line);
                        }
                    }
                    else if (parts[1] == ">")
                    {
                        if (x > Convert.ToInt32(parts[2]))
                        {
                            subset.Add(line);
                        }
                    }
                    else if (parts[1] == "<")
                    {
                        if (x < Convert.ToInt32(parts[2]))
                        {
                            subset.Add(line);
                        }
                    }
                    else if (parts[1] == "<=")
                    {
                        if (x <= Convert.ToInt32(parts[2]))
                        {
                            subset.Add(line);
                        }
                    }
                }
            }
            return subset;
        }
    }
}
