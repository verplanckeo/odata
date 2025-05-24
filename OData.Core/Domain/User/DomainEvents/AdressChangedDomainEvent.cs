using OData.Shared.Domain;

namespace OData.Core.Domain.User.DomainEvents;

public class AddressChangedDomainEvent : DomainEvent
{
    public string Street { get; }

    public string City { get; }

    public string Country { get; }

    public string ZipCode { get; }

    public AddressChangedDomainEvent(string street, string city, string zipCode, string country)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }
}