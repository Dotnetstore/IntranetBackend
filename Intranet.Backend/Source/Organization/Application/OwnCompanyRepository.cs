using Core.Infrastructure;
using Domain.Organization;
using Microsoft.EntityFrameworkCore;
using Organization.Abstractions;
using Organization.Infrastructure;
using Organization.Queries.OwnCompanyGet;
using Shared.Organization;

namespace Organization.Application;

internal sealed class OwnCompanyRepository : IOwnCompanyRepository
{
    private readonly OrganizationContext _context;

    public OwnCompanyRepository(OrganizationContext context)
    {
        _context = context;
    }
    
    void IOwnCompanyRepository.Add(OwnCompany ownCompany)
    {
        _context.OwnCompanies.Add(ownCompany);
    }

    async Task<IEnumerable<OwnCompanyDTO>> IOwnCompanyRepository.GetAsync(GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken)
    {
        return await _context.OwnCompanies
            .AsNoTracking()
            .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
            .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
            .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
            .Select(q => q.ToDTO())
            .ToListAsync(cancellationToken);
    }
}