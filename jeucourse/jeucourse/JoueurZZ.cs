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
	internal class JoueurZZ: Joueur
	{
		public JoueurZZ()
		{
			brush = new SolidBrush(Color.Green);
		}
		public override void Update()
		{
			int angleOrigin = angle;
			bool zigzag = true;
			while (distance > 0)
			{
				if (JeuCourse.flag)
				{
					distance -= (0.02) * freshTime;
					if(zigzag )
					{
						angle++;
					}
					else
					{
						angle--;
					}
					if (angle > angleOrigin + 15 || angle < angleOrigin - 15)
					{
						zigzag = !zigzag;
					}
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
