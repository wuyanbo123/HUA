using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuangonghuijia
{
   public class Employee
    {
       public void GoHome(TrafficTool tool) {
           Console.WriteLine("员工:"+this.Name);
           tool.Run();
       }

       public string ID { get; set; }
       public int Age { get; set; }
       public string Name { get; set; }
     
    }
}
