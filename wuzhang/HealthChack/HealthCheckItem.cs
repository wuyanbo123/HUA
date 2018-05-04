using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthChack
{
    //项目类
    public class HealthCheckItem
    {
        public HealthCheckItem(string name, int price, string description)
        {
            this.Name = name;//套餐名
            this.Price = price;//价格
            this.Description = description;//描述
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
