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

    [Test]
    public void Test_Zoom()
    {
        Plot originalPlot = new();
        Plot testPlot = originalPlot.Clone();

        UiEventManager eventMan = new(testPlot);
        eventMan.AddRightDown(111, 222);
        eventMan.AddMouseMove(123, 234);
        eventMan.AddRightUp(222, 333);

        Console.WriteLine(testPlot);
        testPlot.Width.Should().BeLessThan(originalPlot.Width);
        testPlot.Height.Should().BeLessThan(originalPlot.Height);
        testPlot.CenterX.Should().Be(originalPlot.CenterX);
        testPlot.CenterY.Should().Be(originalPlot.CenterY);
    }
}