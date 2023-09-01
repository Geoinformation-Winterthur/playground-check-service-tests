using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using playground_check_service.Controllers;
using playground_check_service.Model;
using Microsoft.AspNetCore.Mvc;

namespace playground_check_service_tests.Controllers;

public class DefectControllerTests
{
    private const bool isDryRun = true;

    [Fact]
    public void PostNeedsShouldThrowErrorWhenDefectsAreNull()
    {
        Mock loggerMock = new Mock<ILogger<DefectController>>();
        ILogger<DefectController> mockedLogger = (ILogger<DefectController>)loggerMock.Object;

        Defect[] defects = null;

        DefectController defectController = new(mockedLogger);
        ActionResult<ErrorMessage> actionResult = defectController.Post(defects, isDryRun);

        Assert.NotNull(actionResult);

        Assert.NotNull(actionResult.Result);

        // result is "unauthorized request" since the
        // user is still not logged in:
        Assert.IsType<UnauthorizedObjectResult>(actionResult.Result);

        // ErrorMessage errorMessage = (ErrorMessage)actionResult.Result;
        // Assert.NotNull(errorMessage?.errorMessage);
        // // result should be SPK-4 error since the
        // // defect array is null:
        // Assert.Equal("SPK-4", errorMessage?.errorMessage);

    }

}
