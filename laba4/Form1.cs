using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 1);
        Pen pen2 = new Pen(Color.Green, 3);
        Storage<Shape> StorageOfObjects = new Storage<Shape>();
        SolidBrush brush = new SolidBrush(Color.White);
        bool ClickOnFigure = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            for (StorageOfObjects.ToHead(); !StorageOfObjects.eol(); StorageOfObjects.Next())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                {
                    if (e.KeyCode == Keys.Oemplus)
                    {
                        StorageOfObjects.obj().IncRadius();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().DecRadius();
                    }
                    if (e.KeyCode == Keys.OemMinus)
                    {
                        StorageOfObjects.obj().DecRadius();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().IncRadius();
                    }
                    if (e.KeyCode == Keys.W)
                    {
                        StorageOfObjects.obj().DecY();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().IncY();
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        StorageOfObjects.obj().IncY();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().DecY();
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        StorageOfObjects.obj().DecX();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().IncX();
                    }
                    if (e.KeyCode == Keys.D)
                    {
                        StorageOfObjects.obj().IncX();
                        if (StorageOfObjects.obj().CheckBorder(pictureBox1))
                            StorageOfObjects.obj().DecX();
                    }
                }
            }
            Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for (StorageOfObjects.ToHead(); !StorageOfObjects.eol(); StorageOfObjects.Next())
            {
                if (StorageOfObjects.obj().ClickChecking(e.X, e.Y) && !StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetSelectedStat(true);
                    ClickOnFigure = true;
                }
                else if (StorageOfObjects.obj().ClickChecking(e.X, e.Y) && StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetSelectedStat(false);
                    ClickOnFigure = true;
                }
            }
            if (ClickOnFigure)
            {
                ClickOnFigure = false;
                Refresh();
                //StorageOfObjects.NotifyObservers();
                return;
            }
            if (buttonCircle.Enabled == false)
            {
                CCircle circle = new CCircle(e.X, e.Y);
                StorageOfObjects.AddTail(circle);
                Refresh();
            }
            if (buttonSquare.Enabled == false)
            {
                Square square = new Square(e.X, e.Y);
                StorageOfObjects.AddTail(square);
                Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (StorageOfObjects.ToHead(); !StorageOfObjects.eol(); StorageOfObjects.Next())
                StorageOfObjects.obj().Draw(g, pen, brush);
        }


        private void buttonCircle_Click(object sender, EventArgs e)
        {
            buttonCircle.Enabled = false;
            buttonSquare.Enabled = true;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            buttonCircle.Enabled = true;
            buttonSquare.Enabled = false;
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            StorageOfObjects.deleteAll();
            Refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            StorageOfObjects.ToHead();
            while (!StorageOfObjects.eol())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                    StorageOfObjects.DeleteCurrent();
                else StorageOfObjects.Next();
            }
            Refresh();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            StorageOfObjects.ToHead();
            while (!StorageOfObjects.eol())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetColorStat(true);
                    StorageOfObjects.obj().SetColor(Color.Red);
                    StorageOfObjects.Next();
                }
                else StorageOfObjects.Next();
            }
            Refresh();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            StorageOfObjects.ToHead();
            while (!StorageOfObjects.eol())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetColorStat(true);
                    StorageOfObjects.obj().SetColor(Color.Blue);
                    StorageOfObjects.Next();
                }
                else StorageOfObjects.Next();
            }
            Refresh();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            StorageOfObjects.ToHead();
            while (!StorageOfObjects.eol())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetColorStat(true);
                    StorageOfObjects.obj().SetColor(Color.Green);
                    StorageOfObjects.Next();
                }
                else StorageOfObjects.Next();
            }
            Refresh();
        }

        private void buttonMoreColors_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();

            StorageOfObjects.ToHead();
            while (!StorageOfObjects.eol())
            {
                if (StorageOfObjects.obj().GetSelectedStat())
                {
                    StorageOfObjects.obj().SetColorStat(true);
                    StorageOfObjects.obj().SetColor(color.Color);
                    StorageOfObjects.Next();
                }
                else StorageOfObjects.Next();
            }
            Refresh();
        }
    }
}
