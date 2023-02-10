using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurErrer: Joueur
    {
        public Random rd = new Random();
        public int angle;
        public double distance;
        public int x;
        public int y;
        public static SolidBrush brush = new SolidBrush(Color.Gray);
        public bool flag = false;
        public JoueurErrer()
        {
            angle = 225;
            //angle = rd.Next(0, 360);
            distance = 280.0;

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
                Console.WriteLine($"distance errer {distance}");
                DrawSelf();
                if (flag)
                {
                    distance -= 0.06 * (1000 / JeuCourse.Frequence);

                } else
                {
                    distance += 0.02 * (1000 / JeuCourse.Frequence);
                }
                flag = !flag;
                //angle++;
            }

        }

     
    }
}
