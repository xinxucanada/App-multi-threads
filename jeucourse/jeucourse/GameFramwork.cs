using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class GameFramwork
    {
        public static Graphics g;
        public static Pen pen = new Pen(Color.Black, 1);
        public static Joueur joueur;
        public static JoueurAngle joueurAngle;
        public static JoueurAvance joueurAvance;
        public static JoueurErrer joueurErrer;
        public static void start()
        {
            //joueur = new Joueur(5, 5);
            //joueurAngle = new JoueurAngle();
            //joueurAvance = new JoueurAvance();
            //joueurErrer = new JoueurErrer();
        }
        public static void update()
        {
            //g.DrawLine(pen, new Point(0, JeuCourse.axeY), new Point(JeuCourse.TAILLE, JeuCourse.axeY));
            //g.DrawLine(pen, new Point(JeuCourse.axeX, 0), new Point(JeuCourse.axeX, JeuCourse.TAILLE));
            //joueur.Update();
            //joueurAngle.Update();
            //joueurAvance.Update();
            //joueurErrer.Update();
        }
    }
    
}
