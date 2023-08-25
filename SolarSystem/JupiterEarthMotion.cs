using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    internal class JupiterEarthMotion
    {
        public const double pi = Math.PI;
        public double xj, yj, xe, ye;
        public double Ms, Me, Mj, MeMs, MjMs;
        public int flag;
        public double res, ve, vxe, vye, rjs, rej, vj;
        public double delt, beta, vxj, vyj;

        public JupiterEarthMotion(double xj, double yj, double xe, double ye, 
            double ve, double vj, int flag)
        {
            this.xj = xj;
            this.yj = yj;
            this.xe = xe;
            this.ye = ye;
            this.flag = flag;
            this.ve = ve;
            this.vj = vj;

            delt = 0.1;
            res = Math.Sqrt(Math.Pow(xe, 2) + Math.Pow(ye, 2));
            rjs = Math.Sqrt(Math.Pow(xj, 2) + Math.Pow(yj, 2));
            rej = Math.Sqrt(Math.Pow((xe - xj), 2) + Math.Pow((ye - yj), 2));

            vxe = ve;
            vye = 0;
            vxj = 0;
            vyj = vj;

            Ms = 2 * Math.Pow(10, 30);
            Me = 6 * Math.Pow(10, 24);
            Mj = 1.9 * Math.Pow(10, 27);

            MeMs = Me / Ms;
            MjMs = Mj / Ms;
            beta = 2.1;
        }

        public void speed()
        {
            //For earth
            vxe = vxe - 4 * Math.Pow(pi, 2) * delt * (xe / Math.Pow(res, beta + 1) +
                flag * MjMs * (xe - xj) / Math.Pow(rej, 3));
            vye = vye - 4 * Math.Pow(pi, 2) * delt * (ye / Math.Pow(res, beta + 1) +
                flag * MjMs * (ye - yj) / Math.Pow(rej, 3));

            // for jupiter
            vxj = vxj - 4 * Math.Pow(pi, 2) * delt * (xj / Math.Pow(rjs, beta + 1) + 
                flag * MeMs * (xj - xe) / Math.Pow(rej, 3));
            vyj = vyj - 4 * Math.Pow(pi, 2) * delt * (yj / Math.Pow(rjs, beta + 1) + 
                flag * MeMs * (yj - ye) / Math.Pow(rej, 3));
        }

        public void positions()
        {
            xe = xe + vxe * delt;
            ye = ye + vye * delt;
            xj = xj + vxj * delt;
            yj = yj + vyj * delt;
            res = Math.Sqrt(Math.Pow(xe, 2) + Math.Pow(ye, 2));
            rjs = Math.Sqrt(Math.Pow(xj, 2) + Math.Pow(yj, 2));
            rej = Math.Sqrt(Math.Pow((xe - xj), 2) + Math.Pow((ye - yj), 2));
        }
    }

}
