using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurAngle: Joueur
    {
        public Random rd = new Random();
        public int angle;
        public double distance;
        public int x;
        public int y;
        public static SolidBrush brush = new SolidBrush(Color.Red);
        public JoueurAngle()
        {
            angle = 45;
            //angle = rd.Next(0, 360);
            distance = 280;
            
        }
        public override void Update()
        {
            if (distance > 0)
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
            }
        }
    }
}
