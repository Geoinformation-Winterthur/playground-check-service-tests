using Xunit;
using playground_check_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace playground_check_service_tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void TestCorrectActiveMessage()
    {
        Mock loggerMock = new Mock<ILogger<HomeController>>();
        ILogger<HomeController> mockedLogger = (ILogger<HomeController>)loggerMock.Object;

        HomeController homeController = new HomeController(mockedLogger);
        ActionResult<string> getResult = homeController.Get();
        Assert.Equal("\"Playground service works.\"", getResult.Value);
    }
}