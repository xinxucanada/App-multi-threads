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
        private Thread[] threads = new Thread[2];
        private IJoueur[] joueurs= new IJoueur[2];
        public static Graphics WindowG;
        private static Bitmap tempBmp;
        public static int Frequence = 60;
        public static int TAILLE = 801;
        public static int axeX = TAILLE / 2 + 1;
        public static int axeY = TAILLE / 2 + 1;
        public static ThreadJoueur threadJoueur;
		public static ThreadJoueur threadJoueur2;
		public static JoueurAvance threadJoueur3;


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

            threadJoueur = new ThreadJoueur(135, 280);
            t1 = new Thread(new ThreadStart(threadJoueur.Update));
            
            //threadJoueur2 = new ThreadJoueur(45, 250);
            //t2 = new Thread(new ThreadStart(threadJoueur2.Update));
            //t2.Start();
            threadJoueur3 = new JoueurAvance();
			t3 = new Thread(new ThreadStart(threadJoueur3.Update));
			
			t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game
			joueurs[0] = threadJoueur;
			joueurs[1] = threadJoueur3;

			threads[0] = t1;
            threads[1] = t3 ;
            for(int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
          
            Thread.Sleep(1000);
            t.Start();
			//t3.Start();
			//t1.Start();



		}

		[Obsolete]
		private void GameMainThread()
        {
            //GameFramwork.start();
            //rafraîchissements par seconde
            int sleepTime = 1000 / Frequence;

            while (true)
            {
                WindowG.Clear(Color.White);  //donner background grey
                
                for(int i = 0; i < threads.Length;i++)
                {
                    if (joueurs[i].etat != Etat.disparu)
                    {
                        //                  Console.WriteLine(joueurs[i].x + " : " + joueurs[i].y);
                        //Rectangle rectangle = new Rectangle(joueurs[i].x, joueurs[i].y, 20, 20);
                        //WindowG.FillEllipse(new SolidBrush(Color.Blue), rectangle);
                        joueurs[i].DrawSelf(WindowG, new SolidBrush(Color.Green));
						if (joueurs[i].etat == Etat.arrive)
						{
							for(int j = 0; j < threads.Length; j++)
                            {
                                if (j != i)
                                {
                                    if (threads[j].ThreadState == ThreadState.Running)
                                    {
										threads[j].Suspend();
									}
                                }
                            }
						}
					}
                    else
                    {
						for (int j = 0; j < threads.Length; j++)
						{
							if (j != i)
							{
								if (threads[j].ThreadState == ThreadState.Suspended)
								{
									threads[j].Resume();
								}
							}
						}
					}
                }
                
    //            if(threadJoueur.etat != Etat.disparu)
    //            {
				//	Rectangle rectangle = new Rectangle(threadJoueur.x, threadJoueur.y, 20, 20);
				//	JeuCourse.WindowG.FillEllipse(threadJoueur.brush, rectangle);
    //                if (threadJoueur.etat == Etat.arrive)
    //                {
    //                    if (t3.ThreadState== ThreadState.Running)
    //                    {
				//			t3.Suspend();
 			//			}
				//	}
				//} 

				//if (threadJoueur3.etat != Etat.disparu)
    //            {
				//	Rectangle rectangle3 = new Rectangle(threadJoueur3.x, threadJoueur3.y, 20, 20);
				//	JeuCourse.WindowG.FillEllipse(threadJoueur3.brush, rectangle3);
    //                if (threadJoueur3.etat == Etat.arrive)
    //                {
    //                    t1.Suspend();
    //                }
				//} else
    //            {
    //                if (t1.ThreadState== ThreadState.Suspended)
    //                {
				//		t1.Resume();
				//	}
    //            }

					//Rectangle rectangle1 = new Rectangle(threadJoueur2.x, threadJoueur2.y, 20, 20);
					//JeuCourse.WindowG.FillEllipse(threadJoueur.brush, rectangle1);
					
				Thread.Sleep(sleepTime);
            }
        }
    }
}
