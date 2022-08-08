using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

public class ConditionerOnCommand : ICommand
{
    private readonly Conditioner _conditioner;

    public ConditionerOnCommand(Conditioner conditioner)
    {
        _conditioner = conditioner;
    }

    public void Execute()
    {
        if (_conditioner.IsTurnOn)
        {
            Console.WriteLine("Сплит система и так работает!");
        }
        else
        {
            _conditioner.Freeze();
        }
    }

    public void Undo()
    {
        new ConditionerOffCommand(_conditioner).Execute();
    }
}
