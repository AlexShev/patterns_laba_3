using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

public class DoorCloseCommand : ICommand
{
    private readonly Door _door;

    public DoorCloseCommand(Door door)
    {
        _door = door;
    }

    public void Execute()
    {
        if (_door.IsOpen)
        {
            _door.Close();
        }
        else
        {
            Console.WriteLine("Дверь и так закрыта");
        }
    }

    public void Undo()
    {
        new DoorOpenCommand(_door).Execute();
    }
}
