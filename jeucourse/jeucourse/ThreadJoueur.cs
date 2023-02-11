using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    public class ThreadJoueur: Joueur
    {
        public Random rd = new Random();
        public int angle;
        public double distance;
        public int x;
        public int y;
        public SolidBrush brush = new SolidBrush(Color.Green);
        public ThreadJoueur()
        {
            angle = 135;
            //angle = rd.Next(0, 360);
            distance = 280;
            brush = new SolidBrush(Color.Green);

        }

		public ThreadJoueur(int angle, double distance)
		{
			this.angle = angle;
			//angle = rd.Next(0, 360);
			this.distance = distance;
			brush = new SolidBrush(Color.Green);

		}
		public override void Update()
        {
            while (distance > 0)
            {
                double radians = angle * Math.PI / 180;
                double sine = Math.Sin(radians);
                double cosine = Math.Cos(radians);
                x = 400 + (int)(distance * cosine);
                y = 400 - (int)(distance * sine);
                Console.WriteLine($"distance angle {distance}");
                //DrawSelf();
                distance -= 0.02 * (1000 / JeuCourse.Frequence);
                angle++;
                Thread.Sleep(1000);
                //DrawSelf();
            }

        }

        public void DrawSelf()
        {
			JeuCourse.WindowG.Clear(Color.White);
			Rectangle rectangle = new Rectangle(x, y, 20, 20);
            JeuCourse.WindowG.FillEllipse(this.brush, rectangle);
        }
    }
}
