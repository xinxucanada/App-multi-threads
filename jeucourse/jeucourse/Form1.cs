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
        private Thread t1;
        private Thread t2;
        private Thread t3;
        private Thread t4;
        private Thread t5;
        private Thread[] threads = new Thread[5];
        private Joueur[] joueurs= new Joueur[5];
        public static int Frequence = 60;
        public static int TAILLE = 801;
        public static int axeX = TAILLE / 2 + 6;
        public static int axeY = TAILLE / 2 + 6;
		public static Graphics WindowG;
		public static Graphics tempG;
		public static Bitmap tempBmp;
		public static Pen pen = new Pen(Color.Black, 1);
		public static Point leftPoint = new Point(0, axeX);
		public static Point rightPoint = new Point(TAILLE, axeX);
		public static Point upPoint = new Point(axeY, 0);
		public static Point downPoint = new Point(axeY, TAILLE);
		public static bool flag = true;


		public JeuCourse()
        {
            InitializeComponent();

            WindowG = this.CreateGraphics(); // créer graphic sur gamewindow

            tempBmp = new Bitmap(TAILLE, TAILLE); //créer bitmap pour game show

            tempG = Graphics.FromImage(tempBmp); //créer graphic de bitmap

            //GameFramwork.g = bmpG;  // donne graphic vide à gameframework pour y peindre

            
        }

        private void JeuCourse_Load(object sender, EventArgs e)
        {

            Joueur j1 = new JoueurAvance();
            t1 = new Thread(new ThreadStart(j1.Update));

			Joueur j2 = new JoueurErrer();
			t2 = new Thread(new ThreadStart(j2.Update));

			Joueur j3 = new JoueurAngle();
			t3 = new Thread(new ThreadStart(j3.Update));

            Joueur j4 = new JoueurZZ();
			t4 = new Thread(new ThreadStart(j4.Update));

			Joueur j5 = new JoueurDroit();
			t5 = new Thread(new ThreadStart(j5.Update));


			t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game
			joueurs[0] = j1;
			joueurs[1] = j2;
			joueurs[2] = j3;
			joueurs[3] = j4;
			joueurs[4] = j5;

			threads[0] = t1;
            threads[1] = t2;
            threads[2] = t3;
            threads[3] = t4;
            threads[4] = t5;
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            Thread.Sleep(10);
            t.Start();
		}

		public static void DrawPlan()
        {
			tempG.Clear(Color.White);  //donner background white
			tempG.DrawLine(pen, leftPoint, rightPoint);
            tempG.DrawLine(pen, upPoint, downPoint);

		}
		private void GameMainThread()
        {
            //GameFramwork.start();
            //rafraîchissements par seconde
            int sleepTime = 1000 / Frequence;

            while (true)
            {
                DrawPlan();
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
