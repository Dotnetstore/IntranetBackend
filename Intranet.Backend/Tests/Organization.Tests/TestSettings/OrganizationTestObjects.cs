using Moq;
using Moq.EntityFrameworkCore;
using Organization.Infrastructure;
using TestHelper.Helpers;

namespace Organization.Tests.TestSettings;

internal static class OrganizationTestObjects
{
    public static Mock<OrganizationContext> GetOrganizationContextMock()
    {
        var organizationContextMock = new Mock<OrganizationContext>();

        organizationContextMock.Setup(q => q.OwnCompanies)
            .ReturnsDbSet(MockDbSet.Build(OrganizationFakeData.CreateOwnCompanyFakeData()).Object);

        return organizationContextMock;
    }
    
    public static Mock<OrganizationContext> GetOrganizationContextMockForAsync()
    {
        var organizationContextMock = new Mock<OrganizationContext>();

        organizationContextMock.Setup(q => q.OwnCompanies)
            .ReturnsDbSet(MockDbSet.BuildAsync(OrganizationFakeData.CreateOwnCompanyFakeData()).Object);

        return organizationContextMock;
    }
}