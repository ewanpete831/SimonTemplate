using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
            Form1.gameoverSound.PlayLooping();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            lengthLabel.Text = $"{Form1.order.Count}";
          
            if(Form1.order.Count >= 3)
            {
                rankBox.BackgroundImage = Properties.Resources.squidgame2;
            }
            if(Form1.order.Count >= 6)
            {
                rankBox.BackgroundImage = Properties.Resources.squidgame3;
            }
            if(Form1.order.Count >= 9)
            {
                rankBox.BackgroundImage = Properties.Resources.squidgame4;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
