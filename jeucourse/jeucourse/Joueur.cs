using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    public enum Etat
    {
        bouge,
        arrive,
        disparu
    }   

    public class Joueur
    {
        private int x = 10;
        private int y = 10;
        private Object _lock = new Object();
        public SolidBrush brush;
        public Etat etat;

        public Joueur() 
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            this.etat = Etat.bouge;
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
        public void DrawSelf(Graphics g, SolidBrush brush)
        {
           
                Rectangle rectangle = new Rectangle(x, y, 20, 20);
                g.FillEllipse(brush, rectangle);
           
        }
    }
}
