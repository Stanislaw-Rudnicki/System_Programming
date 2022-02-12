using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp05_1_01
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private GameEngine gameEngine;
        private int resolution;
        private bool isStarted = false;
        private string title = "Игра «Жизнь»";

        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (isStarted)
                return;

            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            btnStart.Enabled = false;
            resolution = (int)nudResolution.Value;

            gameEngine = new GameEngine
            (
                rows: pictureBox1.Height / resolution,
                cols: pictureBox1.Width / resolution,
                density: (int)nudDensity.Minimum + (int)nudDensity.Maximum - (int)nudDensity.Value
            );

            Text = title + " — Поколение " + gameEngine.CurrentGeneration;
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            isStarted = true;
            new Thread(DrawNextGeneration).Start();
        }

        public void DrawNextGeneration()
        {
            while (isStarted)
            {
                graphics.Clear(Color.Black);

                var field = gameEngine.GetCurrentGeneration();

                for (int x = 0; x < field.GetLength(0); x++)
                {
                    for (int y = 0; y < field.GetLength(1); y++)
                    {
                        if (field[x, y])
                        {
                            graphics.FillRectangle(
                                Brushes.Crimson, x * resolution, y * resolution, resolution - 1, resolution - 1);
                        }
                    }
                }

                BeginInvoke((MethodInvoker)(() =>
                {
                    pictureBox1.Refresh();
                    Text = title + " — Поколение " + gameEngine.CurrentGeneration;
                }));
                gameEngine.NextGeneration();
                Thread.Sleep(40);
            }
        }

        private void StopGame()
        {
            if (!isStarted)
                return;
            isStarted = false;
            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isStarted)
                return;
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.AddCell(x, y);
            }
            if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.RemoveCell(x, y);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStarted = false;
        }
    }
}
