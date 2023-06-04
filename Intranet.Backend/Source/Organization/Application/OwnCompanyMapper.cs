using Domain.Organization;
using Shared.Organization;

namespace Organization.Application;

internal static class OwnCompanyMapper
{
    internal static OwnCompanyDTO ToDTO(this OwnCompany q) => new()
    {
        Name = q.Name,
        CreatedBy = q.CreatedBy,
        CreatedDate = q.CreatedDate,
        DeletedBy = q.DeletedBy,
        DeletedDate = q.DeletedDate,
        ID = q.ID,
        IsDeleted = q.IsDeleted,
        IsSystem = q.IsSystem,
        LastUpdatedBy = q.LastUpdatedBy,
        LastUpdatedDate = q.LastUpdatedDate,
        VATNumber = q.VATNumber
    };
}