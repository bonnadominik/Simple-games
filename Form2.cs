using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Games
{
    public partial class Form2 : Form
    {
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
        public int Randomizing(int x, int y)
        {
            Random randomize = new Random();
            int number = randomize.Next(x, y);
            return number;
        }
        public void NewGame()
        {
            computerScore = 0;
            playerScore = 0;
            label2.Text = "Twoje punkty: 0";
            label3.Text = "Punkty komputera: 0";
            label1.Text = "Aktualny gracz: Ty";
            button1.Visible = true;
            button3.Visible = true;
        }
        public void DiceAnimation()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    pictureBox1.Image = Image.FromFile("../../imgs/animation/animationdice"+j+".png");
                    wait(100);
                }
                pictureBox1.Image = Image.FromFile("../../imgs/animation/animationdice1.png");
            }
        }
        public int DiceRandomizing()
        {
            int number = Randomizing(1, 7);
            pictureBox1.Image = Image.FromFile("../../imgs/dices/dice" + number + ".png");
            return number;
        }
        public void Verificator()
        {
            if (playerScore>computerScore)
            {
                YouWin();
                NewGame();
            }
            else if (playerScore==computerScore)
            {
                GameOver();
                NewGame();
            }
            else
            {
                GameOver();
                NewGame();
            }
        }
        public void PlayerPlay()
        {
                DiceAnimation();
                playerScore += DiceRandomizing();
                label2.Text = "Twoje punkty: "+playerScore;
                if (playerScore > 12)
                {
                    GameOver();
                    NewGame();
                }
                else if (playerScore == 12)
                {
                    YouWin();
                    NewGame();
                }
        }
        public void ComputerPlay()
        /* Opracowany przez mnie algorytm gry komputera przewiduje losowość podejmowania ryzyka z różnym prawdopodobieństwem.
         Jeśli wylosuje sumę oczek równą 9, to prawdopodobieństwo, że wirtualny krupier zaryzykuje wynosi 50%, jeśli równą 10 lub więcej, to takie prawdopodobieństwo wynosi 12,5% */
        {
            if (playerScore == 0)
            {
                MessageBox.Show("Musisz rzucić kostką chociaż raz");
            }
            else
            {
                button1.Visible = false;
                button3.Visible = false;
                wait(2200);
                DiceAnimation();
                computerScore += DiceRandomizing();
                label3.Text = "Punkty komputera: " + computerScore;
                if (computerScore > 12)
                {
                    YouWin();
                    NewGame();
                }
                else if (computerScore == 12)
                {
                    GameOver();
                    NewGame();
                }
                else if (computerScore <= 8)
                {
                    ComputerPlay();
                }
                else if (computerScore == 9)
                {
                    int number = Randomizing(1, 3);
                    if (number == 1)
                    {
                        ComputerPlay();
                    }
                    else
                    {
                        Verificator();
                    }
                }
                else
                {
                    int number = Randomizing(1, 9);
                    if (number == 1)
                    {
                        ComputerPlay();
                    }
                    else
                        Verificator();
                }
            }
        }
        public int playerScore;
        public int computerScore;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerPlay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 myForm = new Form1();
            myForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Aktualny gracz: Komputer";
            ComputerPlay();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra jest odpowiednikiem karcianych gier typu 'blackjack' lub 'oczko'. Zasady gry są proste. Gracz rzuca kostką tyle razy, aż zdecyduje się przestać. Warunkiem wygranej jest dobranie sumy oczek równej 12, lub sumy większej od tej wylosowanej przez wirtualnego krupiera. Co ważne, jeśli wylosuje sumę oczek równą 13 lub więcej, automatycznie przegrywa. Tak samo dzieje się również wtedy, kiedy krupier i gracz mają taką samą ilość punktów - w tym przypadku gra jest zawsze na korzyść krupiera.");
        }
    }
}
