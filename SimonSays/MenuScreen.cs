using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Close();
        }

        private void createRegions()
        {
            GraphicsPath circlePath = new GraphicsPath();
            GraphicsPath excludePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, 275, 275);
            excludePath.AddEllipse(80, 80, 135, 135);

            Region buttonRegion = new Region(circlePath);
            buttonRegion.Exclude(excludePath);

            newButton.Region = buttonRegion;

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(90, new PointF(68, 68));
            buttonRegion.Transform(transformMatrix);

            exitButton.Region = buttonRegion;
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            createRegions();
        }
    }
}
