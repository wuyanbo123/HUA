using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthChack
{
    public  class HealthCheckSet
    {
            //套餐类
        public HealthCheckSet()
        {
            items = new List<HealthCheckItem>();
        }
        public HealthCheckSet(string name, List<HealthCheckItem> items)
        {
            this.Name = name;
            this.items = items;
        }

       
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

       
        private List<HealthCheckItem> items;
        public List<HealthCheckItem> Items
        {
            get { return items; }
            set { items = value; }
        }

       
        private int price;
        public int Price
        {
            get { return price; }
        }

     // 动态计算套餐和价格
       
        public void CalcPrice()
        {
            int sum = 0;
            foreach (HealthCheckItem item in items)
            {
                sum += item.Price;
            }
            this.price = sum;
        }
    }

    }

