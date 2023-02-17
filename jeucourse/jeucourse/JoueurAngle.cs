﻿using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurAngle: Joueur
    {
        public JoueurAngle()
        {
			brush = new SolidBrush(Color.Gold);
		}
		public override void Update()
        {
			while (distance > 0)
			{
				if (JeuCourse.flag)
				{
					distance -= (0.02) * freshTime;
					angle++;
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
