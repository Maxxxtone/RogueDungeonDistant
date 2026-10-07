using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueDungeonDistant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int playerHealth = 100, maxHealth = 100, gold = 0,
                posX = 0, posY = 0, enemyDamage = 0;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#####");
            Console.WriteLine("#####");
            Console.WriteLine("#####");
            Console.ResetColor();
            // отрисовываем игрока
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
            Console.SetCursorPosition(0, 3);
            // строка состояния героя
            Console.WriteLine($"♡ {playerHealth}/{maxHealth} ${gold, -5}");
            // получение урона
            Console.Write("Введите урон противника: ");
            int.TryParse(Console.ReadLine(), out enemyDamage);
            playerHealth -= enemyDamage;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine($"♡ {playerHealth}/{maxHealth} ${gold, -5}");
            // перемещение игрока
            Console.Write("Введите направление движения: ");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D)
            {
                Console.SetCursorPosition(posX, posY);
                Console.Write("#");
                posX += 1;
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("H");
                Console.ResetColor();
                Console.SetCursorPosition(0, 5);
            }
        }
    }
}
