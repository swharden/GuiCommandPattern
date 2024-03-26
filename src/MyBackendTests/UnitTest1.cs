namespace MyBackendTests;

public class Tests
{
    [Test]
    public void Test_Debug_Math()
    {
        int result = MyBackend.BackendDebug.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }
}