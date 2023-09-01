using Xunit;
using playground_check_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace playground_check_service_tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void TestCorrectActiveMessage()
    {
        Mock loggerMock = new Mock<IWebHostEnvironment>();
        IWebHostEnvironment mockedEnv = (IWebHostEnvironment)loggerMock.Object;

        HomeController homeController = new HomeController(mockedEnv);
        ActionResult<string> getResult = homeController.Get();
        Assert.StartsWith("\"Playground service works. Environment: ", getResult.Value);
    }
}