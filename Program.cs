for (int i = 1; i < 6; i++)
{
    Thread myThread = new(() =>
    {
        var numb = i;
        while (true)
        {
            Thread.Sleep(100);
            Console.WriteLine($"Поток Чтения {numb}" + " GetCount: [" + Server.GetCount() + "]");
        }
    });
    myThread.Start();
}

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(() =>
    {
        var numb = i;
        while (true)
        {
            
            Server.AddToCount(numb);
            Console.WriteLine($"Поток Записи {numb}");
        }
    });
    myThread.Start();
}

Console.ReadLine();

public static class Server
{
    private static int count;

    public static int GetCount()
    {
        return Interlocked.CompareExchange(ref count, 0, 0);
    }

    public static void AddToCount(int value)
    {
        Interlocked.Add(ref count, value);
    }
}