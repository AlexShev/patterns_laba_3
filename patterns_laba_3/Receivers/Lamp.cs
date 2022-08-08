namespace patterns_laba_3.Receivers;

public class Lamp
{
    public bool IsShining { get; private set; } = false;

    public void Shine()
    {
        IsShining = true;

        Console.WriteLine("Лампочка зажглась");
    }

    public void TurnOff()
    {
        IsShining = false;

        Console.WriteLine("Лампочка выключилась");
    }
}
