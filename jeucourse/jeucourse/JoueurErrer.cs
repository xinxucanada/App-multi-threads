using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurErrer: Joueur
    {
       
        public JoueurErrer()
        {
			brush = new SolidBrush(Color.Blue);

		}
		public override void Update()
		{
			long count = 0;
			while (distance > 0)
			{
				if (JeuCourse.flag)
				{
					if (count < 10)
					{
						distance += (0.01) * freshTime;
					} else
					{
						distance -= (0.03) * freshTime;
					}
					count++;
					if (count == 20) 
					{ 
						count = 0;
					}
				}
				Reperer();
				Thread.Sleep(freshTime / 2);
			}
			this.etat = Etat.arrive;
			JeuCourse.flag = false;
			Thread.Sleep(1000);
			JeuCourse.flag = true;
			this.etat = Etat.disparu;
		}


	}
}
