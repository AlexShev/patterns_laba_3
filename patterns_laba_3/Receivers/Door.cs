namespace patterns_laba_3.Receivers;

public class Door
{
    public bool IsOpen { get; private set; } = false;

    public void Open()
    {
        IsOpen = true;

        Console.WriteLine("Дверь открывается");
        Thread.Sleep(500);
        Console.WriteLine("Дверь открыта");
    }

    public void Close()
    {
        IsOpen = false;

        Console.WriteLine("Дверь закрывается");
        Thread.Sleep(500);
        Console.WriteLine("Дверь закрыта");
    }
}