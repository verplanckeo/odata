using OData.Core.Domain.User.DomainEvents;

namespace OData.Core.Test.Domain.User;

public class UserTest
{
    // no attribute to initialize test ... ctor is used for test initialization
    public void Initialize()
    {

    }

    [Fact]
    public void CreateNewUser_Ok()
    {
        // Arrange

        // Act
        var user = Core.Domain.User.User.CreateNewUser("overplan", "olivier", "verplancke");

        // Assert
        Assert.Equal("overplan", user.UserName);
        Assert.Equal("olivier", user.FirstName);
        Assert.Equal("verplancke", user.LastName);
        Assert.Single(user.DomainEvents);
        Assert.Equal(typeof(UserRegisteredDomainEvent), user.DomainEvents.First().GetType());
    }

    [Fact]
    public void ChangeAddress_Ok()
    {
        // Arrange
        var user = Core.Domain.User.User.CreateNewUser("overplan", "olivier", "verplancke");

        // Act
        user.ChangeAddress("street", "city", "1", "belgium");

        // Assert
        Assert.Equal("street", user.UserAddress.Street);
        Assert.Equal("city", user.UserAddress.City);
        Assert.Equal("1", user.UserAddress.ZipCode);
        Assert.Equal("belgium", user.UserAddress.Country);
        Assert.Equal(2, user.DomainEvents.Count);
        Assert.Equal(typeof(AddressChangedDomainEvent), user.DomainEvents.ToList()[1].GetType());
    }
}
