using DiegoStore.Domain.StoreContext.Enums;

namespace DiegoStore.Domain.StoreContext.Entities
{
    public class Address
    {
        public Address(
        string street,
        string number,
        string complement,
        string city,
        string district,
        string state,
        string country,
        string zipCode,
        EAddressType type
        )
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }
        public string Street { get; private set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; private set; }

        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Street},{ Number} - {City}/{State}";
        }

    }
}