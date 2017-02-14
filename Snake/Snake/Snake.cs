using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public List<Point> body;
        public char sign = '*';
        public ConsoleColor color;
        public bool alive;
        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Yellow;
            alive = true;
        }
        public void grow()
        {
            body.Add(new Point(0, 0));
            
        }
        public void Move(int dx, int dy)
        {
            
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            Point head = new Point(body[0].x + dx, body[0].y +dy );
            if (body.Contains(head)) { alive = false; }
            else
                body[0] = head;

            if (head.x == 1 || head.x == 40 || head.y == 1 || head.y == 40) alive = false;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
