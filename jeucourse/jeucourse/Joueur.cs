using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    public enum Etat
    {
        bouge,
        arrive,
        disparu
    }   

    public abstract class Joueur
    {
        public int x;
        public int y;
        public double distance;
        public int angle;
        public SolidBrush brush;
        public Etat etat;
        public static int freshTime = 50;
		public static Random rd = new Random();

		public void GetDistance()
		{
			distance = rd.Next(100, 400);
			angle = rd.Next(360);
		}
		public Joueur() 
        {
            this.etat = Etat.bouge;
            GetDistance();
			Reperer();

		}

      
        
        public void Reperer()
        {
			double radians = angle * Math.PI / 180;
			double sine = Math.Sin(radians);
			double cosine = Math.Cos(radians);
			x = 401 + (int)(distance * cosine);
			y = 401 - (int)(distance * sine);

		}


        public abstract void Update(); 
        
  //      public void Arriver()
  //      {
		//	this.etat = Etat.arrive;
		//	JeuCourse.flag = false;

		//	Console.WriteLine($"distance avance :{distance}");
		//	Thread.Sleep(1000);
		//	JeuCourse.flag = true;
		//	this.etat = Etat.disparu;
		//}
       
    }
}
