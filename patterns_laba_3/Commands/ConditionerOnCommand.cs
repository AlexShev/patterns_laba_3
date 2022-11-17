using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

// команда для включения кондиционера
public class ConditionerOnCommand : ICommand
{
    private readonly Conditioner _conditioner;

    public ConditionerOnCommand(Conditioner conditioner)
    {
        _conditioner = conditioner;
    }

    // Включить кондиционер, если он не включен
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
