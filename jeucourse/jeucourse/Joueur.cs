using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class Joueur
    {
        public int x;
        public int y;
        private Object _lock = new Object();
        public SolidBrush brush;

        public Joueur() 
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
        }
        public Joueur(int x, int y)
        {
            this.x = x;
            this.y = y;
            SolidBrush brush = new SolidBrush(Color.Blue);
        }

        public virtual void Update() 
        {
            if (x != 401 && y!= 401)
            {
                x++;
                y++;
                //Console.WriteLine($"x:{x} y:{y}");
                //DrawSelf();
            }
        }
        public void DrawSelf()
        {
            lock(_lock)
            {
                Rectangle rectangle = new Rectangle(x, y, 20, 20);
                JeuCourse.WindowG.FillEllipse(this.brush, rectangle);
            }
        }
    }
}
