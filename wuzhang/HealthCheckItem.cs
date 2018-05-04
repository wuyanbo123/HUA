using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wuzhang
{
  public  class HealthCheckItem
    {
        private int price;//格价

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

       
        private string description;//项目描述

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string name;//项目名

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public HealthCheckItem() { }
        public static Dictionary<string, List<HealthCheckItem>> ItemDic = new Dictionary<string, List<HealthCheckItem>>();
        public HealthCheckItem(string name, int price, string decription) {
            this.Name = name;
            this.Description = description;
            this.Price = price;

        }


}
}
