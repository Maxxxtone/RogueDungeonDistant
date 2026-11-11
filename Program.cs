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
            // отрисовка карты
            int mapWidth = 10, mapHeight = 10;
            int hudPosition = mapHeight + 2;
            int inputPosition = hudPosition + 2;
            int coinX = 3, coinY = 5, trapX = 7, trapY = 2;

            Random rnd = new Random();
            coinX = rnd.Next(0, mapWidth);
            coinY = rnd.Next(0, mapHeight);
            trapX = rnd.Next(0, mapWidth);
            trapY = rnd.Next(0, mapHeight);

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (j == coinX && i == coinY)
                    {
                        Console.Write("$");
                    }
                    else if (j == trapX && i == trapY)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            // отрисовываем игрока
            while (true)
            {
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("H");
                Console.ResetColor();
                // строка состояния героя
                Console.SetCursorPosition(0, hudPosition);
                Console.WriteLine($"♡ {playerHealth}/{maxHealth} ${gold,-5}");
                // перемещение игрока
                Console.SetCursorPosition(0, inputPosition);
                Console.Write("Введите направление движения: ");
                var key = Console.ReadKey();
                int dirX = 0, dirY = 0;
                if (key.Key == ConsoleKey.D)
                {
                    if (posX == mapWidth - 1)
                        continue;
                    dirX = 1;
                }
                else if(key.Key == ConsoleKey.A)
                {
                    if (posX == 0)
                        continue;
                    dirX = -1;
                }
                else if(key.Key == ConsoleKey.W)
                {
                    if (posY == 0)
                        continue;
                    dirY = -1;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    if (posY == mapHeight - 1)
                        continue;
                    dirY = 1;
                }

                Console.SetCursorPosition(posX, posY);
                Console.Write("#");
                posX += dirX;
                posY += dirY;
                if (posX == coinX && posY == coinY)
                {
                    coinX = coinY = -1;
                    gold += 10;
                }
                else if(posX == trapX && posY == trapY)
                {
                    trapX = trapY = -1;
                    playerHealth -= 20;
                }
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("H");
                Console.ResetColor();
            }
        }
    }
}
