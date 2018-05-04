using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuangonghuijia
{
  public  class Program
    {
        static void Main(string[] args)
        {
            SE ai = new SE("112", "艾边成", 25, 100);
            SE jop = new SE("113", "jop", 12, 45);
            List<Employee> empls = new List<Employee>();
            empls.Add(ai);
            empls.Add(jop);
            empls[0].GoHome(new Bicycle());
            empls[1].GoHome(new Tube());
            //empls[2].GoHome(new Car());
            Console.ReadLine();
        }
    }
}
