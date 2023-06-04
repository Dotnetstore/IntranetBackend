using Domain.Organization;

namespace TestHelper.FakeData;

public static class OrganizationFakeData
{
    public static IList<OwnCompany> CreateOwnCompanyFakeData()
    {
        return new List<OwnCompany>
        {
            new()
            {
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.Now,
                DeletedBy = Guid.NewGuid(),
                DeletedDate = DateTimeOffset.Now,
                ID = new Guid("103E834C-96FA-4CF5-8118-45FD7A2C9D0F"),
                IsDeleted = false,
                IsSystem = false,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTimeOffset.Now,
                Name = "Ericsson",
                VATNumber = "SE556056625801"
            },
            new()
            {
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.Now,
                DeletedBy = Guid.NewGuid(),
                DeletedDate = DateTimeOffset.Now,
                ID = new Guid("5F123F3C-AC9E-41C9-A5C6-4AEC660A99E5"),
                IsDeleted = true,
                IsSystem = true,
                LastUpdatedBy = Guid.NewGuid(),
                LastUpdatedDate = DateTimeOffset.Now,
                Name = "Consid",
                VATNumber = "SE556599430701"
            }
        };
    }
}