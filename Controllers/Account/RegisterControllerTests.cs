using Xunit;
using playground_check_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace playground_check_service_tests.Controllers;

public class RegisterControllerTests
{
    [Fact]
    public void TestErrorMessageWhenNotSendingUuid()
    {
        Mock loggerMock = new Mock<ILogger<RegisterController>>();
        ILogger<RegisterController> mockedLogger = (ILogger<RegisterController>)loggerMock.Object;
        RegisterController registerController = new RegisterController(mockedLogger);
        ContentResult getResult = (ContentResult)registerController.Post(null, "aaaaaaaa", "aaaaaaaa", true);
        Assert.Contains("UUID ist fehlerhaft", getResult.Content);
    }
}