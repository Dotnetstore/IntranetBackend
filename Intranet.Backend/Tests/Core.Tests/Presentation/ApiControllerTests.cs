using Core.Presentation;
using FluentAssertions;

namespace Core.Tests.Presentation;

public class ApiControllerTests
{
    [Test]
    public void ApiController_Should_Be_Abstract()
    {
        typeof(ApiController)
            .Should()
            .BeAbstract();
    }
}