using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace jeucourse
{
    public class JoueurAvance : Joueur, IJoueur
    {
        public Random rd = new Random();
        public int angle;
        public double distance;
        //private int x { get; set; }
        //private int y { get; set; }
	

	public  SolidBrush brush = new SolidBrush(Color.Gold);
        public JoueurAvance()
        {
            angle = 315;
            //angle = rd.Next(0, 360);
            distance = 200.0;

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
                Console.WriteLine($"distance avance :{distance}");
                //DrawSelf();
                distance -= 2;// * (1000 / JeuCourse.Frequence);
                Thread.Sleep(100);
                //angle++;
            }
            this.etat = Etat.arrive;
            JeuCourse.flag = false;

            Console.WriteLine($"distance avance :{distance}");
            Thread.Sleep(5000);
            JeuCourse.flag = true;
            this.etat = Etat.disparu;


		}

	}
}
