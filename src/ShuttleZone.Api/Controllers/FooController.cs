using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Domain.WebRequests.Foo;
using ShuttleZone.Infrastructure.Services.Foo;

namespace ShuttleZone.Api.Controllers;

public sealed class FooController : ControllerBase
{
    private readonly IFooService _fooService;

    public FooController(IFooService fooService)
    {
        _fooService = fooService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoo([FromBody] CreateFooRequest request, CancellationToken cancellationToken = default)
    {
        await _fooService.CreateFooAsync(request, cancellationToken);
        return CreatedAtAction(nameof(CreateFoo), request);
    }
}
