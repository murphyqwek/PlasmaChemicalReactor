using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Data_Classes
{
    class Data : IPoint
    {
        public double X => x;
        public double Y => y;

        private double x;
        private double y;

        public Data(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
