using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace jeucourse
{
    public class JoueurAvance : Joueur
    {
        public JoueurAvance()
        {
			brush = new SolidBrush(Color.Red);

        }

		public override void Update()
        {
			//GetDistance();
			while (distance > 0)
            {
                if (JeuCourse.flag)
                {
					distance -= (0.02) * freshTime;
				}
				Reperer();
				Thread.Sleep(freshTime);
			}
            this.etat = Etat.arrive;
            JeuCourse.flag = false;
            Thread.Sleep(1000);
            JeuCourse.flag = true;
            this.etat = Etat.disparu;
		}

	}
}
