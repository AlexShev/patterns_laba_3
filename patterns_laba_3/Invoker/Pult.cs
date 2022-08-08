
using patterns_laba_3.Commands;

namespace patterns_laba_3.Invoker;

public class Pult
{
    private readonly IDictionary<PultsCommands, ICommand> _commands;

    private readonly Stack<ICommand> _commandsHistory;

    public Pult()
    {
        _commands = new Dictionary<PultsCommands, ICommand>();
        _commandsHistory = new Stack<ICommand>();
    }

    public void Add(PultsCommands pultsCommand, ICommand command)
    {
        _commands.Add(pultsCommand, command);
    }

    public void PushButton(PultsCommands pultsCommand)
    {
        _commands[pultsCommand].Execute();

        // добавляем выполненную команду в историю команд
        _commandsHistory.Push(_commands[pultsCommand]);
    }

    public void PressUndoButton()
    {
        if (_commandsHistory.Count > 0)
        {
            ICommand undoCommand = _commandsHistory.Pop();
            undoCommand.Undo();
        }
    }
}
