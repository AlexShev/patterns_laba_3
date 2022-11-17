using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

// команда для открытия двери
public class DoorOpenCommand : ICommand
{
    private readonly Door _door;

    public DoorOpenCommand(Door door)
    {
        _door = door;
    }

    // Открыть дверь если она открыто
    public void Execute()
    {
        if (_door.IsOpen)
        {
            Console.WriteLine("Дверь и так открыта!");
        }
        else
        {
            _door.Open();
        }
    }

    public void Undo()
    {
        new DoorCloseCommand(_door).Execute();
    }
}
