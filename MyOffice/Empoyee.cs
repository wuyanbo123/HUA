using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice
{
   public class Empoyee

    {
      public int Age { get; set; }
        public Gender  Sex { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
       //给Employee添加工作列表属性
        protected List<Job> workList { get; set; }
       //构造
        public Employee(string id, string name, int age, Gender gender, List<Job> list)
        {
            this.Age = age;
            this.ID 

 = id;
            this.Name 

 = name;
            this.Sex = gender;
            this.workList = list;


       }

    }
}
