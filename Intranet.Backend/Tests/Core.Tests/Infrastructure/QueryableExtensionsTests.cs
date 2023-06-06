using Core.Infrastructure;
using Domain.Organization;
using FluentAssertions;

namespace Core.Tests.Infrastructure;

internal sealed class QueryableExtensionsTests
{
    [Test]
    public void QueryableExtensions_Should_Be_Static()
    {
        typeof(QueryableExtensions)
            .Should()
            .BeStatic();
    }

    [Test]
    public void WhereNullable_Should_RunCorrectly()
    {
        IList<OwnCompany> ownCompanies = new List<OwnCompany>
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

        ownCompanies.Count.Should().Be(2);

        bool? isSystem = true;
        var result = ownCompanies.AsQueryable().WhereNullable(isSystem, q => q.IsSystem == isSystem).ToList();

        result.Count.Should().Be(1);
    }
}