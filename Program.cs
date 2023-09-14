
public static class server
{
    static object sync = new object();
    private static int count;

    public static int GetCount()
    {
        Monitor.Wait(sync);
        return count;
    }

    public static void AddToCount(int value)
    {
        lock (sync)
        {
            count += value;
        }
    }

}
