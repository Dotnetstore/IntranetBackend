using MediatR;
using Shared.Organization;

namespace Organization.Queries.OwnCompanyGet;

internal sealed record GetOwnCompanyQuery(
    string? Name,
    string? VATNumber,
    bool? IsSystem) : IRequest<IEnumerable<OwnCompanyDTO>>;