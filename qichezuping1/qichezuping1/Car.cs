using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qichezuping1
{
    public class Car : Vehicle
    {
        public Car() { }

        public Car(string color, double dailyrent, string licenseno, string name, int rentdate)
            : base(color, dailyrent, licenseno, name, rentdate) { }

       

    }
}