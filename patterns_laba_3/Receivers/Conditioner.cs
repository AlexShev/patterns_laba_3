namespace patterns_laba_3.Receivers;

public class Conditioner
{
    public bool IsTurnOn { get; private set; } = false;

    public void Freeze()
    {
        IsTurnOn = true;

        Console.WriteLine("Сплит Система включается");
        Thread.Sleep(500);
        Console.WriteLine("Сплит Система включена");
        Console.WriteLine("Повеяло прохладой");
    }

    public void TurnOff()
    {
        IsTurnOn = false;

        Console.WriteLine("Сплит Система выключается");
        Thread.Sleep(500);
        Console.WriteLine("Сплит Система выключена");
    }
}
