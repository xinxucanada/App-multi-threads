using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    public class ThreadJoueur: Joueur, IJoueur
    {
        public Random rd = new Random();
        public int angle;
        public double distance;
		//private int x { get; set; }
		//private int y { get; set; }
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
            while (distance > 0 && JeuCourse.flag)
            {
                double radians = angle * Math.PI / 180;
                double sine = Math.Sin(radians);
                double cosine = Math.Cos(radians);
                x = 400 + (int)(distance * cosine);
                y = 400 - (int)(distance * sine);
                //Console.WriteLine($"distance angle {distance}");
                //DrawSelf();
                distance -= 2; //* (1000 / JeuCourse.Frequence);
                angle++;
				Thread.Sleep(100);
                //DrawSelf();
            }
			this.etat = Etat.arrive;
            JeuCourse.flag = false;
            Console.WriteLine($"distance thread :{distance}");
			Thread.Sleep(5000);
            JeuCourse.flag = true;
            this.etat = Etat.disparu;

		}

   //     public void DrawSelf()
   //     {
			//JeuCourse.WindowG.Clear(Color.White);
			//Rectangle rectangle = new Rectangle(x, y, 20, 20);
   //         JeuCourse.WindowG.FillEllipse(this.brush, rectangle);
   //     }
    }
}
