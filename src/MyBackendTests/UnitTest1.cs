using FluentAssertions;
using MyBackend;

namespace MyBackendTests;

public class Tests
{
    [Test]
    public void Test_Pan()
    {
        Plot originalPlot = new();
        Plot testPlot = originalPlot.Clone();

        UiEventManager eventMan = new(testPlot);
        eventMan.AddLeftDown(111, 222);
        eventMan.AddMouseMove(123, 234);
        eventMan.AddLeftUp(222, 333);

        testPlot.CenterX.Should().BeGreaterThan(originalPlot.CenterX);
        testPlot.CenterY.Should().BeGreaterThan(originalPlot.CenterY);
        testPlot.Width.Should().Be(originalPlot.Width);
        testPlot.Height.Should().Be(originalPlot.Height);
    }
}