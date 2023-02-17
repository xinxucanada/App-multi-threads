using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    internal class JoueurAngle : Joueur
    {
        public JoueurAngle()
        {
            brush = new SolidBrush(Color.Gold); // Initialiser la brosse en couleur or
        }

        public override void Update()
        {
            while (distance > 0) // Tant que le joueur n'a pas atteint le centre
            {
                if (JeuCourse.flag) // Si le jeu est en cours
                {
                    distance -= (0.02) * freshTime; // Avancer le joueur de 0.2u de la distance restante
                    angle++; // Tourner le joueur dans le sens anti-horaire
                }
                Reperer(); 
                Thread.Sleep(freshTime); 
            }
            Arriver(); 
        }
    }
}
