using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlCommand("REPLACE INTO address (id, countryId) values (1,1)");
                context.Database.ExecuteSqlCommand("REPLACE INTO address (id, countryId) values (2,1)");
                context.Database.ExecuteSqlCommand("REPLACE INTO address (id, countryId) values (3,2)");
                
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'en')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'de')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (2,'en')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (2,'de')");
                context.SaveChanges();
            }

            string addresses;
            using (var context = new Context())
            {
                addresses = JsonConvert.SerializeObject(context.Addresses.Include(a => a.CountryLocale).ToList());
            }

            Console.WriteLine(addresses);
            Console.ReadLine();
        }
    }
}