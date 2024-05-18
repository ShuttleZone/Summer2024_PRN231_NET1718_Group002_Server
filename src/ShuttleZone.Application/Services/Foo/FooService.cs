using ShuttleZone.Domain.WebRequests.Foo;

namespace ShuttleZone.Infrastructure.Services.Foo;

public sealed class FooService : IFooService
{
    public Task CreateFooAsync(CreateFooRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
