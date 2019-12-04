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

                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'en')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'de')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'fr')");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_country (id, locale) values (1,'nl')");
                
                context.Database.ExecuteSqlCommand("REPLACE INTO address_state (id, locale, countryId) values (1,'en',1)");
                context.Database.ExecuteSqlCommand("REPLACE INTO address_state (id, locale, countryId) values (1,'de',1)");
                
                context.SaveChanges();
            }
            
            string addresses;
            using (var context = new Context())
            {
                var states = context.States.AsNoTracking().Include(a => a.CountryLocales).ToList();
                addresses = JsonConvert.SerializeObject(states);
            }
            
            Console.WriteLine(addresses);
            Console.ReadLine();
        }
    }
}