using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jeucourse
{
    public partial class JeuCourse : Form
    {
        private Thread t;
        private Thread[] threads = new Thread[5];
        private Joueur[] joueurs= new Joueur[5];
        public static int Frequence = 60; // Fréquence de rafraîchissement de l'écran
        public static int TAILLE = 801; // Taille de l'écran de jeu
        public static int axeX = TAILLE / 2 + 6; 
        public static int axeY = TAILLE / 2 + 6; 
        public static Graphics WindowG; // Graphics pour l'écran de jeu
        public static Graphics tempG; // Graphics pour le bitmap
        public static Bitmap tempBmp; // Bitmap pour l'affichage de l'écran
        public static Pen pen = new Pen(Color.Black, 1); // Stylo pour dessiner les lignes
        public static Point leftPoint = new Point(0, axeX); // Point de départ de la ligne de gauche
        public static Point rightPoint = new Point(TAILLE, axeX); // Point de fin de la ligne de droite
        public static Point upPoint = new Point(axeY, 0); // Point de départ de la ligne du haut
        public static Point downPoint = new Point(axeY, TAILLE); // Point de fin de la ligne du bas
        public static bool flag = true;

		public JeuCourse()
        {
            InitializeComponent();

            WindowG = this.CreateGraphics(); // créer graphic sur gamewindow

            tempBmp = new Bitmap(TAILLE, TAILLE); //créer bitmap pour game show

            tempG = Graphics.FromImage(tempBmp); //créer graphic de bitmap

        }

        private void JeuCourse_Load(object sender, EventArgs e)
        {
            FabriqueJoueur fabriqueJoueur = FabriqueJoueur.GetFabriqueJoueurInstance();
            // Création des threads pour chaque joueur
            try
            {
                joueurs[0] = fabriqueJoueur.GetJoueur("Avance");
                threads[0] = new Thread(new ThreadStart(joueurs[0].Update));

                joueurs[1] = fabriqueJoueur.GetJoueur("Errer");
                threads[1] = new Thread(new ThreadStart(joueurs[1].Update));

                joueurs[2] = fabriqueJoueur.GetJoueur("Angle");
                threads[2] = new Thread(new ThreadStart(joueurs[2].Update));

                joueurs[3] = fabriqueJoueur.GetJoueur("ZigZag");
                threads[3] = new Thread(new ThreadStart(joueurs[3].Update));

                joueurs[4] = fabriqueJoueur.GetJoueur("Droit");
                threads[4] = new Thread(new ThreadStart(joueurs[4].Update));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

			t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game
            
            // Démarrage de tous les threads des joueurs
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            Thread.Sleep(10);
            t.Start();
		}

        public static void DrawPlan()
        {
            tempG.Clear(Color.White); // définir le fond en blanc
            tempG.DrawLine(pen, leftPoint, rightPoint); // tracer axe horizontale
            tempG.DrawLine(pen, upPoint, downPoint); // tracer axe horizontale
        }
        private void GameMainThread()
        {
            //rafraîchissements par seconde
            int sleepTime = 1000 / Frequence;

            while (true)
            {
                DrawPlan();
                // affihcer joueur s'il n'est pas disparu
				for (int i = 0; i < joueurs.Length;i++)
                {
                    if (joueurs[i].etat != Etat.disparu)
                    {
                        Rectangle rectangle = new Rectangle(joueurs[i].x, joueurs[i].y, 10, 10);
                        tempG.FillEllipse(joueurs[i].brush, rectangle);
					}
                }
				WindowG.DrawImage(tempBmp, 0, 0);	
				Thread.Sleep(sleepTime);
            }
        }
    }
}
