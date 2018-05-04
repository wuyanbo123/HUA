using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuangonghuijia
{
    public class SE:Employee
    {
        public SE(string id, string name, int age, int popularity) {
            this.ID = id;
            this.Name = name;
            this.Age = age;
            this.Popularity = popularity;
        }
        public SE() { }
           private int Popularity  ;

public int Popularity1
{
  get { return Popularity; }
  set { Popularity = value; }
}
        }

    }
