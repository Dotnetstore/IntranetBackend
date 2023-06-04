using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organization.Queries.OwnCompanyGet;
using Shared.Base;

namespace Organization.Presentation;

public sealed class OwnCompanyController : ApiController
{
    public OwnCompanyController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CompanyDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAsync(
        string? name, 
        string? vatNumber, 
        bool? isSystem, 
        CancellationToken cancellationToken = default)
    {
        var query = new GetOwnCompanyQuery(name, vatNumber, isSystem);
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}