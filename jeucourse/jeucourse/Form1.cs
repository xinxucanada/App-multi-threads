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
        public static Graphics WindowG;
        private static Bitmap tempBmp;
        public static int Frequence = 60;
        public static int TAILLE = 801;
        public static int axeX = TAILLE / 2 + 1;
        public static int axeY = TAILLE / 2 + 1;

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
            //t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game

            //t.Start();
            ThreadJoueur threadJoueur = new ThreadJoueur();
            t1 = new Thread(new ThreadStart(threadJoueur.Update));
            t1.Start();
        }

        private static void GameMainThread()
        {
            GameFramwork.start();
            //rafraîchissements par seconde
            int sleepTime = 1000 / Frequence;

            while (true)
            {
                GameFramwork.g.Clear(Color.White);  //donner background grey
                GameFramwork.update(); //graphis de GramFramwork update
                WindowG.DrawImage(tempBmp, 0, 0); //après GameFramwork change graphic, tempBmp change, puis donne tempBMP à GameWindow Graphic
                Thread.Sleep(sleepTime);
            }
        }
    }
}
