using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

// команда для включения света
public class LampsOnCommand : ICommand
{
    private readonly IList<Lamp> _lamps;

    public LampsOnCommand(IList<Lamp> lamps)
    {
        _lamps = lamps;
    }

    // Включить все лампочки
    public void Execute()
    {
        // если все лампочки включены
        if (_lamps.All((lamp) => lamp.IsShining))
        {
            Console.WriteLine("Свет и так включен");
        }
        else
        {
            // если лампочка не горит, то необходимо её включить
            foreach (var lamp in _lamps)
            {
                if (lamp.IsShining)
                {
                    Console.WriteLine("Лампа и так включена");
                }
                else
                {
                    lamp.Shine();
                }
            }
        }
    }

    // выключить все лампочки
    public void Undo()
    {
        new LampsOffCommand(_lamps).Execute();
    }
}
