using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;

public class CustomerTests
{
    [Fact]
    public void Customer_Should_Initialize_With_Default_Values()
    {
        var customer = new Customer();

        Assert.NotNull(customer);
        Assert.Equal(Guid.Empty, customer.Id);
        Assert.Null(customer.Name);
        Assert.Null(customer.Email);
        Assert.Null(customer.Phone);
        Assert.Equal(default(DateTime), customer.BirthDate);
    }

    [Fact]
    public void Customer_Should_Set_Properties_Correctly()
    {
        var id = Guid.NewGuid();
        var name = "John Doe";
        var email = "john.doe@example.com";
        var phone = "+1234567890";
        var birthDate = new DateTime(1990, 1, 1);

        var customer = new Customer
        {
            Id = id,
            Name = name,
            Email = email,
            Phone = phone,
            BirthDate = birthDate
        };

        Assert.Equal(id, customer.Id);
        Assert.Equal(name, customer.Name);
        Assert.Equal(email, customer.Email);
        Assert.Equal(phone, customer.Phone);
        Assert.Equal(birthDate, customer.BirthDate);
    }

    [Fact]
    public void Customer_Should_Allow_Empty_String_Values()
    {
        var customer = new Customer
        {
            Name = string.Empty,
            Email = string.Empty,
            Phone = string.Empty
        };

        Assert.Equal(string.Empty, customer.Name);
        Assert.Equal(string.Empty, customer.Email);
        Assert.Equal(string.Empty, customer.Phone);
    }
}

