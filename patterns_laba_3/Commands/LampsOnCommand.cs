using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

public class LampsOnCommand : ICommand
{
    private readonly IList<Lamp> _lamps;

    public LampsOnCommand(IList<Lamp> lamps)
    {
        _lamps = lamps;
    }

    public void Execute()
    {
        if (_lamps.All((lamp) => lamp.IsShining))
        {
            Console.WriteLine("Свет и так включен");
        }
        else
        {
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

    public void Undo()
    {
        new LampsOffCommand(_lamps).Execute();
    }
}
