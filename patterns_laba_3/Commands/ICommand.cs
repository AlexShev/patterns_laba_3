namespace patterns_laba_3.Commands;

// интерфейс команды 
public interface ICommand
{
    // выполнить команду
    void Execute();
    // отменить команду
    void Undo();
}
