using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;

public class OrderTests
{
    [Fact]
    public void Order_Should_Initialize_With_Default_Values()
    {
        var order = new Order();

        Assert.NotNull(order);
        Assert.Equal(Guid.Empty, order.Id);
        Assert.Equal(Guid.Empty, order.CustomerId);
        Assert.Null(order.Customer);
        Assert.Equal(default(DateTime), order.CreatedAt);
        Assert.Equal(default(DateTime), order.UpdatedAt);
        Assert.Null(order.Lines);
    }

    [Fact]
    public void Order_Should_Set_Properties_Correctly()
    {
        var id = Guid.NewGuid();
        var customerId = Guid.NewGuid();
        var customer = new Customer { Id = customerId, Name = "John Doe" };
        var createdAt = DateTime.UtcNow.AddDays(-1);
        var updatedAt = DateTime.UtcNow;

        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            Customer = customer,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            Lines = new List<OrderLine>()
        };

        Assert.Equal(id, order.Id);
        Assert.Equal(customerId, order.CustomerId);
        Assert.Equal(customer, order.Customer);
        Assert.Equal(createdAt, order.CreatedAt);
        Assert.Equal(updatedAt, order.UpdatedAt);
        Assert.NotNull(order.Lines);
        Assert.Empty(order.Lines);
    }

    [Fact]
    public void Order_Should_Handle_Null_Lines()
    {
        var order = new Order
        {
            Lines = null
        };

        Assert.Null(order.Lines);
    }

    [Fact]
    public void Order_Should_Handle_Multiple_OrderLines()
    {
        var orderId = Guid.NewGuid();
        var lines = new List<OrderLine>
        {
            new OrderLine { Id = Guid.NewGuid(), OrderId = orderId, Quantity = 1, Total = 10.00m },
            new OrderLine { Id = Guid.NewGuid(), OrderId = orderId, Quantity = 2, Total = 20.00m }
        };

        var order = new Order
        {
            Id = orderId,
            Lines = lines
        };

        Assert.NotNull(order.Lines);
        Assert.Equal(2, order.Lines.Count);
        Assert.All(order.Lines, line => Assert.Equal(orderId, line.OrderId));
    }
}

