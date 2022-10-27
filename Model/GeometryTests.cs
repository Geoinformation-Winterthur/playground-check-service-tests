using Xunit;
using playground_check_service.Model;

namespace playground_check_service_tests.Model;

public class GeometryTests
{
    [Fact]
    public void TestCorrectAssignedType()
    {
        double[] coordinates = new double[]{0.0, 0.0};
        Geometry geom = new Geometry(Geometry.Type.Point, coordinates);
        Assert.Equal("Point", geom.type);
    }
}