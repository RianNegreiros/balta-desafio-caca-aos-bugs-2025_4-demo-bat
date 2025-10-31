using BugStore.Domain.Entities;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Infrastructure.Tests.Data;

public class AppDbContextTests
{
    [Fact]
    public void AppDbContext_Should_Initialize()
    {
        using var context = new AppDbContext();

        Assert.NotNull(context);
    }

    [Fact]
    public void AppDbContext_Should_Have_Customers_DbSet()
    {
        using var context = new AppDbContext();

        Assert.NotNull(context.Customers);
    }

    [Fact]
    public void AppDbContext_Should_Have_Products_DbSet()
    {
        using var context = new AppDbContext();

        Assert.NotNull(context.Products);
    }

    [Fact]
    public void AppDbContext_Should_Have_Orders_DbSet()
    {
        using var context = new AppDbContext();

        Assert.NotNull(context.Orders);
    }

    [Fact]
    public void AppDbContext_Should_Have_OrderLines_DbSet()
    {
        using var context = new AppDbContext();

        Assert.NotNull(context.OrderLines);
    }

    [Fact]
    public void AppDbContext_Customers_DbSet_Should_Accept_Customer_Entities()
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Test Customer",
            Email = "test@example.com",
            Phone = "+1234567890",
            BirthDate = new DateTime(1990, 1, 1)
        };

        using var context = new AppDbContext();
        context.Customers.Add(customer);

        var entry = context.Entry(customer);
        Assert.NotNull(entry);
        Assert.Equal(EntityState.Added, entry.State);
    }

    [Fact]
    public void AppDbContext_Products_DbSet_Should_Accept_Product_Entities()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = "Test Product",
            Description = "Test Description",
            Slug = "test-product",
            Price = 99.99m
        };

        using var context = new AppDbContext();
        context.Products.Add(product);

        var entry = context.Entry(product);
        Assert.NotNull(entry);
        Assert.Equal(EntityState.Added, entry.State);
    }

    [Fact]
    public void AppDbContext_Orders_DbSet_Should_Accept_Order_Entities()
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Lines = new List<OrderLine>()
        };

        using var context = new AppDbContext();
        context.Orders.Add(order);

        var entry = context.Entry(order);
        Assert.NotNull(entry);
        Assert.Equal(EntityState.Added, entry.State);
    }

    [Fact]
    public void AppDbContext_OrderLines_DbSet_Should_Accept_OrderLine_Entities()
    {
        var orderLine = new OrderLine
        {
            Id = Guid.NewGuid(),
            OrderId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 2,
            Total = 20.00m
        };

        using var context = new AppDbContext();
        context.OrderLines.Add(orderLine);

        var entry = context.Entry(orderLine);
        Assert.NotNull(entry);
        Assert.Equal(EntityState.Added, entry.State);
    }
}

