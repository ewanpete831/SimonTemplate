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

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guesses = 0;
        SoundPlayer soundGreen = new SoundPlayer(Properties.Resources.green);
        SoundPlayer soundBlue = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer soundYellow = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer soundRed = new SoundPlayer(Properties.Resources.red);
        SoundPlayer soundGameOver = new SoundPlayer(Properties.Resources.mistake);


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
                    soundGreen.Play();
                    Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                }
                else if (Form1.order[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    soundRed.Play();
                    Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                }
                else if (Form1.order[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    soundYellow.Play();
                    Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                }
                else if (Form1.order[i] == 3)
                {
                    blueButton.BackColor = Color.RoyalBlue;
                    soundBlue.Play();
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
            soundGreen.Play();
            Refresh();
            Thread.Sleep(200);
            greenButton.BackColor = Color.ForestGreen;
            Refresh();

            testButtonColour(0);
        }
        private void redButton_Click_1(object sender, EventArgs e)
        {
            redButton.BackColor = Color.Red;
            soundRed.Play();
            Refresh();
            Thread.Sleep(200);
            redButton.BackColor = Color.DarkRed;
            Refresh();

            testButtonColour(1);
        }

        private void yellowButton_Click_1(object sender, EventArgs e)
        {
            yellowButton.BackColor = Color.Yellow;
            soundYellow.Play();
            Refresh();
            Thread.Sleep(200);
            yellowButton.BackColor = Color.Goldenrod;
            Refresh();

            testButtonColour(2);
        }

        private void blueButton_Click_1(object sender, EventArgs e)
        {
            blueButton.BackColor = Color.RoyalBlue;
            soundBlue.Play();
            Refresh();
            Thread.Sleep(200);
            blueButton.BackColor = Color.DarkBlue;
            Refresh();

            testButtonColour(3);
        }

        private void createRegions()
        {
            GraphicsPath circlePath = new GraphicsPath();
            GraphicsPath excludePath = new GraphicsPath();
            circlePath.AddEllipse(5, 5, 250, 250);
            excludePath.AddEllipse(85, 85, 100, 100);

            Region buttonRegion = new Region(circlePath);
            buttonRegion.Exclude(excludePath);

            greenButton.Region = buttonRegion;

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(90, new PointF(63, 63));
            buttonRegion.Transform(transformMatrix);

            redButton.Region = buttonRegion;

            buttonRegion.Transform(transformMatrix);

            blueButton.Region = buttonRegion;

            buttonRegion.Transform(transformMatrix);

            yellowButton.Region = buttonRegion;
        }

        private void testButtonColour(int colour)
        {
            if (Form1.order[guesses] == colour)
            {
                guesses++;
                if (guesses == Form1.order.Count())
                {
                    ComputerTurn();
                }
            }
            else
            {
                soundGameOver.Play();
                GameOver();
            }
        }
    }
}
