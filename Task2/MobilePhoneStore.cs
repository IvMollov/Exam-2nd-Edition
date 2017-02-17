using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
   public class MobilePhoneStore
    {
        const string validation = @"^[a-zA-Z\s0-9-]+$";
        const string message = "Commands must consist of alphabetical characters, numbers and spaces.\nPrice should be positive. " +
                                     "\nCheck your command again.";
        public Dictionary<string, decimal> Phones { get; set; }
        public Dictionary<string, decimal> Accessories { get; set; }

        public MobilePhoneStore( )
        {
            this.Phones = new Dictionary<string, decimal>();
            this.Accessories = new Dictionary<string, decimal>();
        }

        public void AddPhone(string vendor, string model, decimal price)
        {

            if (Regex.IsMatch(vendor, validation) && Regex.IsMatch(model, validation) && price >= 0)
            {
                string pair = vendor + " " + model;
                if (Phones.ContainsKey(pair))
                {
                    Console.WriteLine("Duplicate phone");
                }
                else
                {
                    Phones.Add(pair, price);
                    Console.WriteLine("Phone added");
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public void AddAccessory(string title, decimal price)
        {
            if (Regex.IsMatch(title, validation) && price >= 0)
            {
                if (Accessories.ContainsKey(title))
                {
                    Console.WriteLine("Duplicate accessory");
                }
                else
                {
                    Accessories.Add(title, price);
                    Console.WriteLine("Accessory added");
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        public void PrintAccessory()
        {
            if (Accessories.Count == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                foreach (var item in Accessories.OrderBy(x => x.Key))
                {
                    Console.Write("{0}, ", item.Key);
                }
                Console.WriteLine();
            }

        }

        public void PrintPhones(string vendor)
        {
            if (Regex.IsMatch(vendor, validation))
            {
                var listOfVendors = Phones.Where(x => x.Key.StartsWith(vendor)).Select(r => r.Key).ToList();
                if (listOfVendors.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (var item in Phones.Where(x => x.Key.StartsWith(vendor)).OrderBy(x => x.Key).Select(r => r.Key).ToList())
                    {
                        Console.Write("{0}, ", item);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        public void PrintPhones(decimal minPrice, decimal maxPrice)
        {
            if (minPrice >= 0 && maxPrice >= 0)
            {
                var phonesInPriceRange = Phones.Where(x => x.Value >= minPrice && x.Value <= maxPrice).ToList();
                if (phonesInPriceRange.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (var item in phonesInPriceRange.OrderBy(x => x.Key).ToList())
                    {
                        Console.Write("{0}, ", item.Key);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        public void PrintAllProducts(decimal maxPrice)
        {
            if (maxPrice >= 0)
            {
                var phonesAndAccessoriesBelowGivenMaxPrice = Phones.Concat(Accessories).Where(x => x.Value <= maxPrice).ToList();
                if (phonesAndAccessoriesBelowGivenMaxPrice.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    int check = 0;
                    foreach (var item in phonesAndAccessoriesBelowGivenMaxPrice.OrderBy(x => x.Key).ToList())
                    {
                        check++;
                        
                        if (check == 2)
                        {
                            Console.Write("{0},\n", item.Key);
                            check = 0;
                        }
                        else
                        {
                            Console.Write("{0}, ", item.Key);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine(message);
            }

        }
    }
}
