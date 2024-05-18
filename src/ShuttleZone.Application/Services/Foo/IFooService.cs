using ShuttleZone.Domain.WebRequests.Foo;

namespace ShuttleZone.Infrastructure.Services.Foo;

public interface IFooService
{
    Task CreateFooAsync(CreateFooRequest request, CancellationToken cancellationToken = default);
}
