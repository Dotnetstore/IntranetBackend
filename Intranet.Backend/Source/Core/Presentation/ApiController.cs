using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Presentation;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator Mediator;

    protected ApiController(
        IMediator mediator)
    {
        Mediator = mediator;
    }
}