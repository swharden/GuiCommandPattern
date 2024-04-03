using MyBackend;

namespace MyBackendTests;

public class Tests
{
    [Test]
    public void Test_Pan()
    {
        Plot plot = new();
        UiEventManager eventMan = new(plot);
        Assert.That(plot.Right, Is.EqualTo(10));

        eventMan.Add("left button down", 111, 222);
        eventMan.Add("mouse move", 123, 234);
        eventMan.Add("left button up", 222, 333);
        Assert.That(plot.Right, Is.GreaterThan(10));
    }
}