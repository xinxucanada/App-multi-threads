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
    internal class JoueurErrer : Joueur // la classe JoueurErrer hérite de la classe Joueur
    {
        public JoueurErrer()
        {
            brush = new SolidBrush(Color.Blue); // initialisation de la couleur de pinceau pour dessiner le joueur
        }

        public override void Update()
        {
            long count = 0; // initialisation du compteur
            while (distance > 0) // tant qu'il n'a pas atteint le centre
            {
                if (JeuCourse.flag) // si le jeu est en cours 
                {
                    if (count < 10) // si le compteur est inférieur à 10
                    {
                        distance += (0.01) * freshTime; // le joueur recule en ajoutant un petit déplacement à la distance actuelle
                    }
                    else // sinon
                    {
                        distance -= (0.03) * freshTime; // le joueur avance en soustrayant un petit déplacement à la distance actuelle
                    }
                    count++; // on incrémente le compteur
                    if (count == 20) // si le compteur atteint 20 (après 10 avances et 10 reculs)
                    {
                        count = 0; // on le réinitialise à 0
                    }
                }
                Reperer();
                Thread.Sleep(freshTime / 2); // on met en pause l'exécution de la méthode pendant un temps donné
            }
            Arriver();
        }
    }
}
