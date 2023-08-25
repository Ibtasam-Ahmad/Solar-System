using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    internal class EarthMotion
    {

        public double X, Y, Vx, Vy, dt, Pi, r, t;
        public EarthMotion(double X, double Y, double Vx, double Vy, double dt)
        {
            this.X = X; this.Y = Y; this.Vx = Vx;
            this.Vy = Vy; this.dt = dt;
            this.Pi = Math.PI;
            t = 0;
        }
        public double XCompute()
        {
            Vx = Vx - (4 * Pi * Pi * X) / (r * r * r) * dt;
            X = X + Vx * dt;
            return X;
        }
        public double YCompute()
        {
            Vy = Vy - (4 * Pi * Pi * Y) / (r * r * r) * dt;
            Y = Y + Vy * dt;
            return Y;
        }
        public double Distance()
        {
            r = Math.Sqrt(X * X + Y * Y);
            return r;
        }
    }
}
