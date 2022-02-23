using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guesses = 0;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            createRegions();
            Form1.order.Clear();
            Refresh();
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Thread.Sleep(1000);
            Random randNum = new Random();
            Form1.order.Add(randNum.Next(0, 4));

            for (int i = 0; i < Form1.order.Count(); i++)
            {
                if (Form1.order[i] == 0)
                {
                    greenButton.BackColor = Color.Lime;
                    Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                }
                else if (Form1.order[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                }
                else if (Form1.order[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                }
                else if (Form1.order[i] == 3)
                {
                    blueButton.BackColor = Color.RoyalBlue;
                    Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                }
                Thread.Sleep(500);
            }
            guesses = 0;
        }

        public void GameOver()
        {
            Form1.ChangeScreen(this, new GameOverScreen());
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            greenButton.BackColor = Color.Lime;
            Refresh();
            Thread.Sleep(200);
            greenButton.BackColor = Color.ForestGreen;
            Refresh();
            if (Form1.order[guesses] == 0)
            {
                guesses++;
                if (guesses == Form1.order.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
        private void redButton_Click_1(object sender, EventArgs e)
        {
            redButton.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(200);
            redButton.BackColor = Color.DarkRed;
            Refresh();
            if (Form1.order[guesses] == 1)
            {
                guesses++;
                if (guesses == Form1.order.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void yellowButton_Click_1(object sender, EventArgs e)
        {
            yellowButton.BackColor = Color.Yellow;
            Refresh();
            Thread.Sleep(200);
            yellowButton.BackColor = Color.Goldenrod;
            Refresh();
            if (Form1.order[guesses] == 2)
            {
                guesses++;
                if (guesses == Form1.order.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void blueButton_Click_1(object sender, EventArgs e)
        {
            blueButton.BackColor = Color.RoyalBlue;
            Refresh();
            Thread.Sleep(200);
            blueButton.BackColor = Color.DarkBlue;
            Refresh();
            if (Form1.order[guesses] == 3)
            {
                guesses++;
                if (guesses == Form1.order.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void createRegions()
        {
            GraphicsPath circlePath = new GraphicsPath();
            GraphicsPath excludePath = new GraphicsPath();
            circlePath.AddEllipse(0, 5, 240, 240);
            


            Region buttonRegion = new Region(circlePath);

            greenButton.Region = buttonRegion;

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(90, new PointF(0, 0));
            buttonRegion.Transform(transformMatrix);

            redButton.Region = buttonRegion;

            buttonRegion.Transform(transformMatrix);

            blueButton.Region = buttonRegion;

            buttonRegion.Transform(transformMatrix);

            yellowButton.Region = buttonRegion;
        }
    }
}
