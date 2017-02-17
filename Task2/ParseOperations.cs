using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ParseOperations
    {
        static MobilePhoneStore resultsPhones = new MobilePhoneStore();

        public static void Parse()
        {
            using (StreamReader reader = new StreamReader(@"D:\Projects\Exam\Exam\Task2\bin\Sample.txt"))
            {
                string line = "";
                string braket = "(";
                string comma = ",";
                char[] separators = new char[] { ' ', ')', '(', ',' };
                while ((line = reader.ReadLine()) != null)
                {

                    int indexBracket = line.IndexOf(braket);
                    int indexFirstComma = line.IndexOf(comma);
                    int indexLastComma = line.LastIndexOf(comma);
                    string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    if (parts[0] == "AddPhone")
                    {
                        resultsPhones.AddPhone(line.Substring(indexBracket + 1, (indexFirstComma - 1) - indexBracket), line.Substring(indexFirstComma + 2, (indexLastComma - 2) - indexFirstComma), Convert.ToDecimal(parts[parts.Length - 1]));
                    }
                    else if (parts[0] == "AddAccessory")
                    {
                        resultsPhones.AddAccessory(line.Substring(indexBracket + 1, (indexFirstComma - 1) - indexBracket), Convert.ToDecimal(parts[parts.Length - 1]));
                    }
                    else if (parts[0] == "PrintAccesories")
                    {
                        resultsPhones.PrintAccessory();
                    }
                    else if (parts[0] == "PrintPhones" && parts.Length <= 2)
                    {
                        resultsPhones.PrintPhones(parts[1]);
                    }
                    else if (parts[0] == "PrintPhones")
                    {
                        resultsPhones.PrintPhones(Convert.ToDecimal(line.Substring(indexBracket + 1, (indexFirstComma - 1) - indexBracket)), Convert.ToDecimal(parts[parts.Length - 1]));
                    }
                    else if (parts[0] == "PrintAllProducts")
                    {
                        resultsPhones.PrintAllProducts(Convert.ToDecimal(parts[parts.Length - 1]));
                    }

                }
            }
        }
    }
}
