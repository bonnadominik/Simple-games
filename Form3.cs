using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public partial class Form3 : Form
    {
        public int averseOrReverse;
        public bool isItAverse;
        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        public void NewGame()
        {
            button1.Visible = true;
        }
        public void YouWin()
        {
            wait(700);
            Form4 myForm = new Form4();
            myForm.ShowDialog();
        }
        public void GameOver()
        {
            wait(700);
            Form5 myForm = new Form5();
            myForm.ShowDialog();
        }
        public void CoinAnimation()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    pictureBox1.Image = Image.FromFile("../../imgs/animation/animationcoin" + j + ".png");
                    wait(50);
                }
                pictureBox1.Image = Image.FromFile("../../imgs/animation/animationcoin1.png");
            }
        }
        public void CoinRandomizing()
        {
            Random randomize = new Random();
            averseOrReverse = randomize.Next(1, 3);
            pictureBox1.Image = Image.FromFile("../../imgs/coins/coin" + averseOrReverse + ".png");
        }
        public void Validator()
        {
            if (averseOrReverse==1 && isItAverse==true)
            {
                YouWin();
                NewGame();
            }
            else if(averseOrReverse==2 && isItAverse==false)
            {
                YouWin();
                NewGame();
            }
            else
            {
                GameOver();
                NewGame();
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            CoinAnimation();
            CoinRandomizing();
            Validator();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 myForm = new Form1();
            myForm.ShowDialog();
            this.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                isItAverse = true;
            }  
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                isItAverse = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra polega na obstawieniu sytuacji czy wypadnie awers(strona monety bez znacznika), czy rewers(strona z koroną). Jeśli uda nam się zgadnąć, to wygrywamy, jeśli nie to przegrywamy.");
        }
    }
}
