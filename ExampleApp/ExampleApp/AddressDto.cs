using System.Collections.Generic;

namespace ExampleApp
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public List<CountryLocaleDto> CountryLocale { get; set; }
    }
}