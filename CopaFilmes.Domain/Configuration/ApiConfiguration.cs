using System;

namespace CopaFilmes.Domain.Configuration
{
    public class ApiConfiguration
    {
        public string AddressBase { get; set; }

        public Uri GetUri() => new Uri(AddressBase);
    }
}
