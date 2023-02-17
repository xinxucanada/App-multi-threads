using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jeucourse
{
    // Énumération pour les différents états du joueur
    public enum Etat
    {
        bouge,
        arrive,
        disparu
    }

    // Classe abstraite pour représenter un joueur
    public abstract class Joueur
    {
        public int x; // Coordonnée x du joueur
        public int y; // Coordonnée y du joueur
        public double distance; // Distance parcourue par le joueur
        public int angle; // Angle de la direction du joueur
        public SolidBrush brush; // Couleur du joueur
        public Etat etat; // État actuel du joueur
        public static int freshTime = 50; // Temps de rafraîchissement de l'affichage
        public static Random rd = new Random(); // Objet pour la génération de nombres aléatoires

        // Méthode pour générer aléatoirement la distance et l'angle de départ du joueur
        public void GetDistance()
        {
            distance = rd.Next(100, 400); // La distance est un nombre entier entre 100 et 400
            angle = rd.Next(360); // L'angle est un nombre entier entre 0 et 359
        }

        // Constructeur de la classe Joueur
        public Joueur()
        {
            this.etat = Etat.bouge; // Le joueur est en train de bouger
            GetDistance(); // Génère aléatoirement la distance et l'angle de départ
            Reperer(); // Calcule les coordonnées initiales du joueur
        }

        // Méthode pour recalculer les coordonnées du joueur en fonction de sa position et de son angle
        public void Reperer()
        {
            double radians = angle * Math.PI / 180; // Convertit l'angle en radians
            double sine = Math.Sin(radians); // Calcule le sinus de l'angle
            double cosine = Math.Cos(radians); // Calcule le cosinus de l'angle
            x = 401 + (int)(distance * cosine); // Calcule la coordonnée x en fonction de l'angle et de la distance
            y = 401 - (int)(distance * sine); // Calcule la coordonnée y en fonction de l'angle et de la distance
        }

        // Méthode abstraite pour mettre à jour l'état du joueur
        public abstract void Update();

        // Méthode pour mettre le joueur à l'état "arrivé"
        public void Arriver()
        {
            this.etat = Etat.arrive; // Le joueur est arrivé à la ligne d'arrivée
            JeuCourse.flag = false; // Le jeu est arrêté
            Thread.Sleep(1000); // Attend 1 seconde
            JeuCourse.flag = true; // Le jeu est redémarré
            this.etat = Etat.disparu; // Le joueur a disparu de l'écran
        }
    }
}
