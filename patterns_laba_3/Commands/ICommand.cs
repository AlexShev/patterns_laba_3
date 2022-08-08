namespace patterns_laba_3.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
}
