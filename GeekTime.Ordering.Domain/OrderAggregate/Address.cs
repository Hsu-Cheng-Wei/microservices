using GeekTime.Domain.Abstractions;
using System.Collections.Generic;

namespace GeekTime.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string ZipCode { get; private set; }

        public Address() { }

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
