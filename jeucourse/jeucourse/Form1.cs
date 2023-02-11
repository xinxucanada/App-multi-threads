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
        public static Graphics WindowG;
        private static Bitmap tempBmp;
        public static int Frequence = 60;
        public static int TAILLE = 801;
        public static int axeX = TAILLE / 2 + 1;
        public static int axeY = TAILLE / 2 + 1;
        public static ThreadJoueur threadJoueur;
		public static ThreadJoueur threadJoueur2;


		public JeuCourse()
        {
            InitializeComponent();
            WindowG = this.CreateGraphics(); // créer graphic sur gamewindow

            tempBmp = new Bitmap(TAILLE, TAILLE); //créer bitmap pour game show

            Graphics bmpG = Graphics.FromImage(tempBmp); //créer graphic de bitmap

            GameFramwork.g = bmpG;  // donne graphic vide à gameframework pour y peindre

            
        }

        private void JeuCourse_Load(object sender, EventArgs e)
        {
            
            threadJoueur = new ThreadJoueur(135,280);
            t1 = new Thread(new ThreadStart(threadJoueur.Update));
            t1.Start();
			threadJoueur2 = new ThreadJoueur(45, 250);
			t2 = new Thread(new ThreadStart(threadJoueur2.Update));
			t2.Start();
			t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game

			t.Start();
		}

		private static void GameMainThread()
        {
            GameFramwork.start();
            //rafraîchissements par seconde
            int sleepTime = 1000 / Frequence;

            while (true)
            {
                WindowG.Clear(Color.White);  //donner background grey
											 //GameFramwork.update(); //graphis de GramFramwork update
											 // WindowG.DrawImage(tempBmp, 0, 0); //après GameFramwork change graphic, tempBmp change, puis donne tempBMP à GameWindow Graphic
				Rectangle rectangle = new Rectangle(threadJoueur.x, threadJoueur.y, 20, 20);
				JeuCourse.WindowG.FillEllipse(threadJoueur.brush, rectangle);
				Rectangle rectangle1 = new Rectangle(threadJoueur2.x, threadJoueur2.y, 20, 20);
				JeuCourse.WindowG.FillEllipse(threadJoueur.brush, rectangle1);
				Thread.Sleep(sleepTime);
            }
        }
    }
}
