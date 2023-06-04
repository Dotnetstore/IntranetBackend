using System.Runtime.CompilerServices;
using Domain.Organization;
using Organization.Queries.OwnCompanyGet;
using Shared.Organization;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Organization.Abstractions;

internal interface IOwnCompanyRepository
{
    void Add(OwnCompany ownCompany);
    
    Task<IEnumerable<OwnCompanyDTO>> GetAsync(GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken);
}