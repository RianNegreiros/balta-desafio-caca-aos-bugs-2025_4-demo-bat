using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;

public class ProductTests
{
    [Fact]
    public void Product_Should_Initialize_With_Default_Values()
    {
        var product = new Product();

        Assert.NotNull(product);
        Assert.Equal(Guid.Empty, product.Id);
        Assert.Null(product.Title);
        Assert.Null(product.Description);
        Assert.Null(product.Slug);
        Assert.Equal(0m, product.Price);
    }

    [Fact]
    public void Product_Should_Set_Properties_Correctly()
    {
        var id = Guid.NewGuid();
        var title = "Test Product";
        var description = "A test product description";
        var slug = "test-product";
        var price = 99.99m;

        var product = new Product
        {
            Id = id,
            Title = title,
            Description = description,
            Slug = slug,
            Price = price
        };

        Assert.Equal(id, product.Id);
        Assert.Equal(title, product.Title);
        Assert.Equal(description, product.Description);
        Assert.Equal(slug, product.Slug);
        Assert.Equal(price, product.Price);
    }

    [Fact]
    public void Product_Should_Handle_Zero_Price()
    {
        var product = new Product
        {
            Price = 0m
        };

        Assert.Equal(0m, product.Price);
    }

    [Fact]
    public void Product_Should_Handle_Negative_Price()
    {
        var product = new Product
        {
            Price = -10.50m
        };

        Assert.Equal(-10.50m, product.Price);
    }

    [Fact]
    public void Product_Should_Handle_Very_High_Price()
    {
        var highPrice = 999999.99m;

        var product = new Product
        {
            Price = highPrice
        };

        Assert.Equal(highPrice, product.Price);
    }
}

