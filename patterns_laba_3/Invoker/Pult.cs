
using patterns_laba_3.Commands;

namespace patterns_laba_3.Invoker;

public class Pult
{
    // Словарь Команда пульта - объект, ответственный за выполнения команды данного типа
    private readonly IDictionary<PultsCommands, ICommand> _commands;

    // Очередь выполненых команд
    private readonly Stack<ICommand> _commandsHistory;

    public Pult()
    {
        _commands = new Dictionary<PultsCommands, ICommand>();
        _commandsHistory = new Stack<ICommand>();
    }

    // Добавить соответствующей кнопке, команду
    public void Add(PultsCommands pultsCommand, ICommand command)
    {
        _commands.Add(pultsCommand, command);
    }

    // выполнить команду
    public void PushButton(PultsCommands pultsCommand)
    {
        _commands[pultsCommand].Execute();

        // добавляем выполненную команду в историю команд
        _commandsHistory.Push(_commands[pultsCommand]);
    }

    public void PressUndoButton()
    {
        // Если можно, отменить выполнение команды
        if (_commandsHistory.Count > 0)
        {
            ICommand undoCommand = _commandsHistory.Pop();
            undoCommand.Undo();
        }
    }
}
