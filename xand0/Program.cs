class xand0
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int Player = 1; // 1 - игрок, 2 - бот

    static void Main()
    {
        int choice;
        bool validInput;
        Random rnd = new Random();

        do
        {
            Console.Clear();
            DrawBoard();

            Console.WriteLine($"Игрок {Player}, введите номер ячейки:");

            // Проверяем корректность ввода: число от 1 до 9, и ячейка не должна быть занята
            if (Player != 2)
            {
                validInput = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';
            }
            else
            {
                choice = rnd.Next(0, 10);
                validInput = choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';
            }

            if (validInput)
            {
                // Заполняем ячейку текущим символом (X или O)
                board[choice - 1] = (Player == 1) ? 'X' : 'O';

                // Проверяем на наличие выигрышной комбинации
                if (CheckWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine($"Победил игрок {Player}!");
                    break;
                }

                // Проверяем на наступление ничьей
                if (CheckDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                // Меняем текущего игрока
                Player = (Player == 1) ? 2 : 1;
            }
            else
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");

        } while (true);
    }

    // Выводим текущее состояние игрового поля
    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    // Проверяем на выигрыш
    static bool CheckWin()
    {
        return (board[0] == board[1] && board[1] == board[2]) ||
            (board[3] == board[4] && board[4] == board[5]) ||
            (board[6] == board[7] && board[7] == board[8]) ||
            (board[0] == board[3] && board[3] == board[6]) ||
            (board[1] == board[4] && board[4] == board[7]) ||
            (board[2] == board[5] && board[5] == board[8]) ||
            (board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6]);
    }

    // Проверяем на ничью
    static bool CheckDraw()
    {
        // Проверяем, остались ли свободные ячейки
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
                return false;
        }
        return true;
    }
}