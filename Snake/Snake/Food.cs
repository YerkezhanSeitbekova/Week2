using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food
    {
        public Point position;
        public char sign = '+';
        public ConsoleColor color;
        public Food()
        {
            color = ConsoleColor.Green;
            Init();
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(sign);
        }
        public void Init()
        {
            position = new Point(new Random().Next() % 20 + 1, new Random().Next() % 20+1);
        }
    }
}
