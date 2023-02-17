using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeucourse
{
    internal sealed class FabriqueJoueur // class Singleton pour fabriquer des Joueurs
    {
        private static FabriqueJoueur instance = new FabriqueJoueur(); // Instance de la classe FabriqueJoueur
        private FabriqueJoueur() { } // Constructeur privé, empêchant la création d'instances de la classe en dehors de la classe elle-même
        public static FabriqueJoueur GetFabriqueJoueurInstance() // Méthode pour obtenir l'instance unique de la classe FabriqueJoueur
        {
            return instance;
        }
        public Joueur GetJoueur(string typeJoueur) // Méthode pour créer un joueur en fonction du type de joueur spécifié en paramètre
        {
            if (typeJoueur == "Avance") 
            {
                return new JoueurAvance(); 
            }
            else if (typeJoueur == "Errer") 
            {
                return new JoueurErrer(); 
            }
            else if (typeJoueur == "Angle") 
            {
                return new JoueurAngle(); 
            }
            else if (typeJoueur == "ZigZag") 
            {
                return new JoueurZZ(); 
            }
            else if (typeJoueur == "Droit")
            {
                return new JoueurDroit(); 
            }
            else // Si le type de joueur n'est aucun des types spécifiés ci-dessus
            {
                throw new NotImplementedException("Impossible de créer un " + typeJoueur); // Lancer une exception pour signaler que ce type de joueur n'a pas été implémenté
            }
        }
    }
}
