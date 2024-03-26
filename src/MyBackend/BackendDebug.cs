using System.Diagnostics;

namespace MyBackend;

public static class BackendDebug
{
    public static void Print(string message)
    {
        Debug.WriteLine(message);
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }
}
