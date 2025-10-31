using BugStore.Application.Handlers.Customers;

namespace BugStore.Application.Tests.Handlers.Customers;

public class HandlerTests
{
    [Fact]
    public void Handler_Should_Initialize()
    {
        var handler = new Handler();

        Assert.NotNull(handler);
    }
}

