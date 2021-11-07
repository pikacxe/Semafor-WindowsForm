using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semafor
{
    public partial class Form1 : Form
    {
        public int click = 0;
        public static int state = 0;
        public int[] intervali = { 5000, 1000, 3000, 1500 };
        public Form1()
        {
            InitializeComponent();
        }
        public void Semafor(int a)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            g.FillRectangle(Brushes.LightGray, new Rectangle(new Point(100, 100), new Size(100, 250)));
            g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(new Point(100, 100), new Size(100, 250)));
            g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(new Point(125, 125), new Size(50, 50)));
            g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(new Point(125, 190), new Size(50, 50)));
            g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(new Point(125, 255), new Size(50, 50)));
            switch (a)
            {
                case 1:
                    g.FillEllipse(Brushes.Red, new Rectangle(new Point(125, 125), new Size(50, 50)));
                     break;
                case 2:
                    g.FillEllipse(Brushes.Red, new Rectangle(new Point(125, 125), new Size(50, 50)));
                    g.FillEllipse(Brushes.Yellow, new Rectangle(new Point(125, 190), new Size(50, 50)));
                     break;
                case 3:
                    g.FillEllipse(Brushes.Green, new Rectangle(new Point(125, 255), new Size(50, 50)));
                     break;
                case 4:
                    g.FillEllipse(Brushes.Yellow, new Rectangle(new Point(125, 190), new Size(50, 50)));
                    break;
                case 0:
                    g.FillEllipse(Brushes.Green, new Rectangle(new Point(125, 255), new Size(50, 50)));
                    g.FillEllipse(Brushes.Red, new Rectangle(new Point(125, 125), new Size(50, 50)));
                    g.FillEllipse(Brushes.Yellow, new Rectangle(new Point(125, 190), new Size(50, 50)));break;
                default:break;
            }



;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Semafor(state);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                state = 1;
                timer1.Enabled = true;
                timer1.Start();
                click++;
                button1.Text = "Prekini animaciju";
            }
            else
            {
                click = 0;
                timer1.Enabled =false;
                button1.Text = "Pokreni animaciju";
                timer1.Stop();
                state = 0;
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            state++;
            Semafor(state);
            timer1.Interval = intervali[state-1];
            if (state == 4)
            {
                state = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Semafor(0);
        }
    }
}
