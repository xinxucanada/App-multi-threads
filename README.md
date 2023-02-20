# App multi threads

# Nom
Jeu de course

# Installation
### partie C#: Visual Studio 2019 ou 2022 (algorithme complèt, interface graphic, démonstration animée).

1. Je place 5 points dans un plan cartésien à des positions aléatoires à au moins 100 unités de distance du centre (0, 0).

2. Les points sont instanciés en utilisant le patron de conception Fabrique (FabriqueJoueur).

3. J'ai 5  configurations pour les points
3.1 point avncer (rouge)
3.2 point errer (bleu)
3.3 point colimaçon (or)
3.4 point zigzag(vert)
3.5 point tout droit(rose)

4. Tous les points se déplaceent en même temps. Ignorer les délais d'activation.

5. Lorsqu'un point est au centre, il doit y rester pendant 1 seconde. Après 1 seconde, le point disparait.

6. Lorsqu'un point est au centre, tous les autres points doivent s'arrêter, tant et aussi longtemps que le point situé au centre n'a pas disparu.

7.On doit pouvoir voir les déplacements des points en temps réel(ou avec un rafraichissement assez élevé).

Point boni 1:  Faire en sorte d'implémenter3 autres types de déplacements vers le centre.

Point boni 2: Utiliser le parallélisme pour chaque points.

![image](https://user-images.githubusercontent.com/111302670/219733570-8e304867-6772-4df8-95b3-5f3fd644d61b.png)

# Utilisation
Ouvrez et executez "jeucourse.sln" sur visual studio

# Auteur
Xin Xu;

# Support
Pour nous rejoindre, voux pouvez nous écrire à l'adresse suivante: e2194517@cmaisonneuve.qc.ca

 
