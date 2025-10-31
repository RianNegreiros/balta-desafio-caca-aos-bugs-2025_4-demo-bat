using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;

public class OrderLineTests
{
    [Fact]
    public void OrderLine_Should_Initialize_With_Default_Values()
    {
        var orderLine = new OrderLine();

        Assert.NotNull(orderLine);
        Assert.Equal(Guid.Empty, orderLine.Id);
        Assert.Equal(Guid.Empty, orderLine.OrderId);
        Assert.Equal(Guid.Empty, orderLine.ProductId);
        Assert.Equal(0, orderLine.Quantity);
        Assert.Equal(0m, orderLine.Total);
        Assert.Null(orderLine.Product);
    }

    [Fact]
    public void OrderLine_Should_Set_Properties_Correctly()
    {
        var id = Guid.NewGuid();
        var orderId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Title = "Test Product", Price = 10.00m };
        var quantity = 5;
        var total = 50.00m;

        var orderLine = new OrderLine
        {
            Id = id,
            OrderId = orderId,
            ProductId = productId,
            Product = product,
            Quantity = quantity,
            Total = total
        };

        Assert.Equal(id, orderLine.Id);
        Assert.Equal(orderId, orderLine.OrderId);
        Assert.Equal(productId, orderLine.ProductId);
        Assert.Equal(product, orderLine.Product);
        Assert.Equal(quantity, orderLine.Quantity);
        Assert.Equal(total, orderLine.Total);
    }

    [Fact]
    public void OrderLine_Should_Handle_Zero_Quantity()
    {
        var orderLine = new OrderLine
        {
            Quantity = 0
        };

        Assert.Equal(0, orderLine.Quantity);
    }

    [Fact]
    public void OrderLine_Should_Handle_Negative_Quantity()
    {
        var orderLine = new OrderLine
        {
            Quantity = -5
        };

        Assert.Equal(-5, orderLine.Quantity);
    }

    [Fact]
    public void OrderLine_Should_Handle_Large_Quantities()
    {
        var orderLine = new OrderLine
        {
            Quantity = int.MaxValue
        };

        Assert.Equal(int.MaxValue, orderLine.Quantity);
    }

    [Fact]
    public void OrderLine_Should_Handle_Decimal_Total()
    {
        var orderLine = new OrderLine
        {
            Total = 123.456789m
        };

        Assert.Equal(123.456789m, orderLine.Total);
    }
}

