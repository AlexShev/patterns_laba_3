using patterns_laba_3.Commands;
using patterns_laba_3.Invoker;
using patterns_laba_3.Receivers;

namespace patterns_laba_3;

public class ConsoleInteractor
{
    private readonly IList<Lamp> _lamps;
    private readonly Door _door;
    private readonly Conditioner _conditioner;

    private readonly Pult _pult;

    public ConsoleInteractor()
    {
        _lamps = new List<Lamp>()
        {
            new Lamp(),
            new Lamp(),
            new Lamp(),
            new Lamp(),
            new Lamp(),
        };

        _door = new Door();

        _conditioner = new Conditioner();

        _pult = new Pult();

        _pult.Add(PultsCommands.ConditionerOn, new ConditionerOnCommand(_conditioner));
        _pult.Add(PultsCommands.ConditionerOff, new ConditionerOffCommand(_conditioner));
        
        _pult.Add(PultsCommands.DoorOpen, new DoorOpenCommand(_door));
        _pult.Add(PultsCommands.DoorClose, new DoorCloseCommand(_door));
        
        _pult.Add(PultsCommands.LampsOn, new LampsOnCommand(_lamps));
        _pult.Add(PultsCommands.LampsOff, new LampsOffCommand(_lamps));
    }

    private void ShowState()
    {
        Console.WriteLine($"Дверь {(_door.IsOpen ? "открыта" : "закрыта")}");

        Console.WriteLine($"Сплит система {(_conditioner.IsTurnOn ? "включена" : "выключена")}");

        if (_lamps.All((lamp) => lamp.IsShining))
        {
            Console.WriteLine("Освещение дома включено");
        }
        else if (_lamps.All((lamp) => !lamp.IsShining))
        {
            Console.WriteLine("Освещение дома выключено");
        }
        else
        {
            Console.WriteLine("Освещение дома частично включена");
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine($"{0} - Выйти");
        Console.WriteLine($"{1} - Показать меню");

        Console.WriteLine($"{2} - Отменить последнюю команду");
        Console.WriteLine($"{3} - Показать состояние дома");

        Console.WriteLine($"{4} - Включить кондиционер");
        Console.WriteLine($"{5} - Выключить кондиционер");

        Console.WriteLine($"{6} - Открыть дверь");
        Console.WriteLine($"{7} - Закрыть дверь");
        
        Console.WriteLine($"{8} - Включить освещение в доме");
        Console.WriteLine($"{9} - Выключить освещение в доме");

    }

    private static string? ReadLine()
    {
        Console.Write(">> ");

        return Console.ReadLine();
    }

    private static int ReadInt()
    {
        string? s = ReadLine();

        if (int.TryParse(s, out int code))
        {
            return code;
        }
        else
            return -1;
    }

    private static bool Confirmation()
    {
        Console.WriteLine("Для подтверждения нажмите 1");

        if (Console.ReadKey(true).Key == ConsoleKey.D1)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Команда отменена");
            return false;
        }
    }


    public void Run()
    {
        try
        {
            var seporator = new string('=', 20);

            int operation;

            ShowMenu();
            
            do {
                operation = ReadInt();

                switch (operation)
                {
                    case 0:
                        if (!Confirmation())
                        {
                            operation = 0;
                        }
                        break;
                    case 1:
                        ShowMenu();
                        break;
                    case 2:
                        if (Confirmation())
                            _pult.PressUndoButton();
                        break;
                    case 3:
                        ShowState();
                        break;
                    case 4:
                        _pult.PushButton(PultsCommands.ConditionerOn);
                        break;
                    case 5:
                        _pult.PushButton(PultsCommands.ConditionerOff);
                        break;
                    case 6:
                        _pult.PushButton(PultsCommands.DoorOpen);
                        break;
                    case 7:
                        _pult.PushButton(PultsCommands.DoorClose);
                        break;
                    case 8:
                        _pult.PushButton(PultsCommands.LampsOn);
                        break;
                    case 9:
                        _pult.PushButton(PultsCommands.LampsOff);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет!!!");
                        break;
                }

                Console.WriteLine();
            } while (operation != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine("Что-то пошло не так");
            Console.WriteLine(e.ToString());
        }
    }
}
