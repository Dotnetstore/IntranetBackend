using Domain.Organization;

namespace Organization.Tests.TestSettings;

internal static class OrganizationFakeData
{
    public static List<OwnCompany> CreateOwnCompanyFakeData()
    {
        return new List<OwnCompany>
        {
            new()
            {
                CreatedBy = new Guid("3178DC2B-1471-4BD8-A7CD-040D7F1801F3"),
                CreatedDate = DateTimeOffset.Parse("2023-05-01"),
                DeletedBy = null,
                DeletedDate = null,
                ID = new Guid("103E834C-96FA-4CF5-8118-45FD7A2C9D0F"),
                IsDeleted = false,
                IsSystem = false,
                LastUpdatedBy = new Guid("3178DC2B-1471-4BD8-A7CD-040D7F1801F3"),
                LastUpdatedDate = DateTimeOffset.Parse("2023-05-09"),
                Name = "Ericsson",
                VATNumber = "SE556056625801"
            },
            new()
            {
                CreatedBy = new Guid("3178DC2B-1471-4BD8-A7CD-040D7F1801F3"),
                CreatedDate = DateTimeOffset.Parse("2023-05-01"),
                DeletedBy = new Guid("3178DC2B-1471-4BD8-A7CD-040D7F1801F3"),
                DeletedDate = DateTimeOffset.Parse("2023-06-01"),
                ID = new Guid("5F123F3C-AC9E-41C9-A5C6-4AEC660A99E5"),
                IsDeleted = true,
                IsSystem = true,
                LastUpdatedBy = new Guid("3178DC2B-1471-4BD8-A7CD-040D7F1801F3"),
                LastUpdatedDate = DateTimeOffset.Parse("2023-05-10"),
                Name = "Consid",
                VATNumber = "SE556599430701"
            }
        };
    }
}