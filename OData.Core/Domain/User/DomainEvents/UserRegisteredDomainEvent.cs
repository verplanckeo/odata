using OData.Shared.Domain;

namespace OData.Core.Domain.User.DomainEvents;

/// <summary>
/// Event when a new user registers in our system.
/// </summary>
public class UserRegisteredDomainEvent : DomainEvent
{
    /// <summary>
    /// Unique user id
    /// </summary>
    public string UserId { get; set; }
    
    /// <summary>
    /// Unique username.
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// First name of user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of user.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// CTor (create new instance of <see cref="UserRegisteredDomainEvent"/>)
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userName"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public UserRegisteredDomainEvent(string userId, string userName, string firstName, string lastName)
    {
        UserId = userId;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
    }
}