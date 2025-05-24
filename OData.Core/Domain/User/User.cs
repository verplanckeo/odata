using OData.Core.Domain.User.DomainEvents;
using OData.Shared.Domain;

namespace OData.Core.Domain.User;

public class User : EventSourcedAggregateRoot<UserId>
{
    public override UserId Id { get; protected set; }
    public string UserName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Address UserAddress { get; private set; }

    //TODO: Rework default constructor - for now it's only used for unit test
    /// <summary>
    /// DO NOT USE THIS CTOR!
    /// </summary>
    public User() { }

    /// <summary>
    /// When an aggregate has been fetched from db, we call this CTor which will apply all events and increase the Version by 1
    /// </summary>
    /// <param name="events"></param>
    public User(IEnumerable<IDomainEvent> events) : base(events) { }

    /// <summary>
    /// Create a new user for the system.
    /// </summary>
    /// <param name="userName">Username (e.g.: OVerplancke)</param>
    /// <param name="firstName">First name (e.g.: Olivier)</param>
    /// <param name="lastName">Last name (e.g.: Verplancke)</param>
    /// <returns></returns>
    public static User CreateNewUser(string userName, string firstName, string lastName)
    {
        var user = new User();

        //This method will first call the "On(event)" method of this particular aggregate followed by adding the event to the list of domain events
        user.Apply(new UserRegisteredDomainEvent(new UserId().ToString(), userName, firstName, lastName));

        return user;
    }
    
    /// <summary>
    /// Change address of user.
    /// </summary>
    /// <param name="street">Street name (e.g.: Rue de OData)</param>
    /// <param name="city">City user lives in (e.g.: Brussels)</param>
    /// <param name="zipcode">Zipcode of the city (e.g.: 1000)</param>
    /// <param name="country">Country or residence (e.g.: Belgium)</param>
    public void ChangeAddress(string street, string city, string zipcode, string country)
    {
        Apply(new AddressChangedDomainEvent(street, city, zipcode, country));
    }
    
    //To know how these "On(event)" methods are called, check ...\EventStore.Core\DddSeedwork\EventSourcedAggregateRoot.cs
    //Using dynamic we call the "On(event)" method
    public void On(UserRegisteredDomainEvent evt)
    {
        Id = new UserId(evt.UserId);
        UserName = evt.UserName;
        FirstName = evt.FirstName;
        LastName = evt.LastName;
    }
    
    public void On(AddressChangedDomainEvent evt)
    {
        UserAddress = new Address
        {
            Street = evt.Street,
            City = evt.City,
            ZipCode = evt.ZipCode,
            Country = evt.Country
        };
    }
}