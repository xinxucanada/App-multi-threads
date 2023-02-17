using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurDroit : Joueur
    {
        public JoueurDroit()
        {
            brush = new SolidBrush(Color.Pink);
        }
        public override void Update()
        {
            // Déplace le joueur horizontalement jusqu'à atteindre le centre
            while (x != 401)
            {
                if (JeuCourse.flag)
                {
                    // Si le jeu est en cours, déplace le joueur d'une unité horizontalement vers la droite ou la gauche
                    // en fonction de la position actuelle de x
                    x = x > 401 ? --x : ++x;
                }
                Thread.Sleep(freshTime);
            }

            // Déplace le joueur verticalement jusqu'à atteindre le centre
            while (y != 401)
            {
                if (JeuCourse.flag)
                {
                    y = y > 401 ? --y : ++y;
                }
                Thread.Sleep(freshTime);
            }
            Arriver();
        }
    }
}
