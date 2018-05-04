using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuzhang
{
    
   public class HealthCheckSet
    {
      private int Price; //价格

        public int Price1
        {
            get { return Price; }
            set { Price = value; }
        }
        private string Name;  //名称

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }
        private string Items;  //集合

        public string Items1
        {
            get { return Items; }
            set { Items = value; }
        }


        public List<HealthCheckItem> ItemList = new List<HealthCheckItem>();
        public static Dictionary<string, List<HealthCheckItem>> SetDic = new Dictionary<string, List<HealthCheckItem>>();



        public HealthCheckSet(string name)
        {
            SetDic.Add(name,this.ItemList);
        }




        internal static void DicAdd(List<HealthCheckItem> list, string p)
        {
            throw new NotImplementedException();
        }
    }
  
}
