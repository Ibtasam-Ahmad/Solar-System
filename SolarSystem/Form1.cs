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

namespace SolarSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Xi = 1;
            double Yi = 0;
            double Vxi = 0;
            double Vyi = 6.28;
            double dt = 0.0002;

            EarthMotion em = new EarthMotion(Xi, Yi, Vxi, Vyi, dt);

            pictureBox1.Left = this.Size.Width / 2 - 150;
            pictureBox1.Top = this.Size.Height / 2 - 100;

            while (true)
            {
                em.Distance();
                pictureBox2.Left = (int)((pictureBox1.Left) + em.XCompute() * 250);
                pictureBox2.Top = (int)((pictureBox1.Top) + em.YCompute() * 250);
                Application.DoEvents();
                Thread.Sleep(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ve, vj, Te, Tj, ttime1, ttime2, time = 0;
            int flag;
            double xj, yj, xe, ye;
            xj = 5.2;
            yj = 0;
            xe = 0;
            ye = 1;
            ve = 6.28;
            vj = 2.74;
            flag = int.Parse(textBox1.Text);

            JupiterEarthMotion jem = new JupiterEarthMotion(xj, yj, xe, ye, ve, vj, flag);

            Te = 2 * Math.PI * jem.res / ve;
            ttime1 = 200 * Te;
            Tj = 2 * Math.PI * jem.rjs / vj;
            ttime2 = 200 * Tj;
            pictureBox1.Left = this.ClientSize.Width / 2;
            pictureBox1.Top = this.ClientSize.Height / 2;

            while(time < ttime1)
            {
                jem.speed();
                jem.positions();

                pictureBox2.Left = pictureBox1.Left + (int)jem.xe * 100;
                pictureBox2.Top = pictureBox1.Left + (int)jem.ye * 100;

                pictureBox3.Left = pictureBox1.Left + (int)jem.xj * 100;
                pictureBox3.Top = pictureBox1.Left + (int)jem.yj * 100;

                Application.DoEvents();
                Thread.Sleep(1);

                time += jem.delt;

            }
        }
    }
}
