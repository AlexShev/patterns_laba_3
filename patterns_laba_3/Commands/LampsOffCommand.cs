using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

// команда для включения света
public class LampsOffCommand : ICommand
{
    private readonly IList<Lamp> _lamps;

    public LampsOffCommand(IList<Lamp> lamps)
    {
        _lamps = lamps;
    }

    // Выключить все лампочки
    public void Execute()
    {
        // если ниодна лампочка не включена
        if (_lamps.All((lamp) => !lamp.IsShining))
        {
            Console.WriteLine("Свет и так выключен");
        }
        else
        {
            // если лампочка не горит, то необходимо её включить
            foreach (var lamp in _lamps)
            {
                if (lamp.IsShining)
                {
                    lamp.TurnOff();
                }
                else
                {
                    Console.WriteLine("Лампа и так выключена");
                }
            }
        }
    }

    public void Undo()
    {
        new LampsOnCommand(_lamps).Execute();
    }
}
