using patterns_laba_3.Receivers;

namespace patterns_laba_3.Commands;

// команда для выключения кондиционера
public class ConditionerOffCommand : ICommand
{
    private readonly Conditioner _conditioner;

    public ConditionerOffCommand(Conditioner conditioner)
    {
        _conditioner = conditioner;
    }

    // Выключить кондиционер, если он включен
    public void Execute()
    {
        if (_conditioner.IsTurnOn)
        {
            _conditioner.TurnOff();
        }
        else
        {
            Console.WriteLine("Сплит система и так выключена");
        }
    }

    public void Undo()
    {
        new ConditionerOnCommand(_conditioner).Execute();
    }
}
