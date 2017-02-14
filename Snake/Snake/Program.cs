using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    

   
    class Program
    {

        static void Main(string[] args)
        {
            Snake snake = new Snake();
            Food food = new Food();
            food.Draw();
            snake.Draw();
            drowBorder();
            while (snake.alive)
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (pressed.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (pressed.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (pressed.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                if (pressed.Key == ConsoleKey.Escape)
                    break;


                Console.Clear();
                drowBorder();
                snake.Draw();
                if (snake.body.Contains(food.position))
                {
                    snake.grow();
                    food.Init();
                }
                food.Draw();
            }
            if (!snake.alive)
            {

                Console.SetCursorPosition(10,10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(10, 11);
                Console.WriteLine("Press Esc to close");
                while (!Console.ReadKey().Key.Equals(ConsoleKey.Escape))
                {
                }
            }
        }
        static void drowBorder()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < 40; i++)
            {
                Console.SetCursorPosition(0,i);
                Console.Write(' ');
                Console.SetCursorPosition(i, 0);
                Console.Write(' ');
                Console.SetCursorPosition(i, 40);
                Console.Write(' ');
                Console.SetCursorPosition(40, i);
                Console.Write(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
