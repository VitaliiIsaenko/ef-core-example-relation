using System.Collections.Generic;

namespace ExampleApp
{
    public class State
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public int CountryId { get; set; }
        public List<Country> CountryLocales { get; set; }
    }
}