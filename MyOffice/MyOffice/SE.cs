using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice
{
   public class SE:Empoyee
    {
       public string DoWork() {
           StringBuilder sb = new StringBuilder();
           sb.Append(this.Name + ":/n");
           for (int i = 0; i < this.WorkList.Count; i++) {
               sb.Append((i + 1) + "." + WorkList[i].Name + ":" + WorkList[i].Description + "/n");
           }
           return sb.ToString();
       }
       public SE(string id, string name, int age, int popularity, List<jop> List) : base(id, age, name, list) {
           this.popularity = popularity;
       }

       public int popularity { get; set; }
    }
}
