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
    // La classe JoueurZZ hérite de la classe abstraite Joueur
    internal class JoueurZZ : Joueur
    {
        public JoueurZZ()
        {
            brush = new SolidBrush(Color.Green); // Initialisation de la couleur du joueur
        }
        public override void Update()
        {
            int angleOrigin = angle; // Stockage de l'angle initial
            bool zigzag = true; // Initialisation du zigzag à true
            while (distance > 0) 
            {
                if (JeuCourse.flag) // Vérification si le jeu est en cours
                {
                    distance -= (0.02) * freshTime; // Mise à jour de la distance parcourue
                    if (zigzag)
                    {
                        angle++; // Incrémentation de l'angle si zigzag est vrai
                    }
                    else
                    {
                        angle--; // Décrémentation de l'angle si zigzag est faux
                    }
                    if (angle > angleOrigin + 15 || angle < angleOrigin - 15) // Vérification si l'angle est à plus de 15 degrés de l'angle initial
                    {
                        zigzag = !zigzag; // Inversion du zigzag
                    }
                }
                Reperer(); // Appel de la méthode Reperer pour mettre à jour les coordonnées du joueur
                Thread.Sleep(freshTime); 
            }
            Arriver();
        }
    }
}
