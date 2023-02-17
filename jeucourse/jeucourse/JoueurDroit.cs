using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
	internal class JoueurDroit:Joueur
	{
		public JoueurDroit()
		{
			brush = new SolidBrush(Color.Pink);

		}

		public override void Update()
		{
			Console.WriteLine($"X: {x}  Y:  {y}");
			while (x != 401)
			{
				if (JeuCourse.flag)
				{
					x = x > 401 ? --x: ++x;
				}
				Thread.Sleep(freshTime);
			}
			while (y != 401)
			{
				if (JeuCourse.flag)
				{
					y = y > 401 ? --y : ++y;
				}
				Thread.Sleep(freshTime * 2);
			}
			this.etat = Etat.arrive;
			JeuCourse.flag = false;
			Thread.Sleep(1000);
			JeuCourse.flag = true;
			this.etat = Etat.disparu;
		}
	}
}
