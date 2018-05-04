using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice
{
   public class PM:Empoyee
    {
        public int YearOfExperience { get; set; }
       public string Dowork()
       {
           string message = this.Name 

 + "：管理员工完成工作内容！";
           return message;
       }
       public PM(string id, string name, int age, Gender gender, int yearOfExperience,
           List<jop> list):base(id,name,age,gender,list)
         
        {
            this.YearOfExperience = YearOfExperience;
       }


}
