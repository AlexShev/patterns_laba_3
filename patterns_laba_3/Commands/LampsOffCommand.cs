using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

public class LampsOffCommand : ICommand
{
    private readonly IList<Lamp> _lamps;

    public LampsOffCommand(IList<Lamp> lamps)
    {
        _lamps = lamps;
    }

    public void Execute()
    {
        if (_lamps.All((lamp) => !lamp.IsShining))
        {
            Console.WriteLine("Свет и так выключен");
        }
        else
        {
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
