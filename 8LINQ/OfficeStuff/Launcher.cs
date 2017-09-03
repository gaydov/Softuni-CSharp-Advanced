using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeStuff
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Company> companies = new List<Company>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Trim('|').Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string companyInputName = args[0];
                int amount = int.Parse(args[1]);
                string product = args[2];

                if (!companies.Any(c => c.CompanyName.Equals(companyInputName)))
                {
                    companies.Add(new Company(companyInputName, new Dictionary<string, int>()));
                    Company current = companies.FirstOrDefault(c => c.CompanyName.Equals(companyInputName));
                    current.Orders[product] = amount;
                }
                else
                {
                    Company current = companies.FirstOrDefault(c => c.CompanyName.Equals(companyInputName));

                    if (!current.Orders.ContainsKey(product))
                    {
                        current.Orders.Add(product, amount);
                    }
                    else
                    {
                        current.Orders[product] += amount;
                    }
                }
            }

            foreach (Company company in companies.OrderBy(c => c.CompanyName))
            {
                Console.Write($"{company.CompanyName}: ");

                string[] resultProducts = company.Orders.Select(kvp => string.Format($"{kvp.Key}-{kvp.Value}")).ToArray();
                Console.WriteLine(string.Join(", ", resultProducts));
            }
        }
    }

    public class Company
    {
        public Company(string companyName, Dictionary<string, int> orders)
        {
            this.CompanyName = companyName;
            this.Orders = orders;
        }

        public string CompanyName { get; set; }

        public Dictionary<string, int> Orders { get; set; }
    }
}
