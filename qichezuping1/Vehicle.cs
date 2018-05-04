using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qichezuping1
{
    public class Vehicle
    {
        //颜色
        public string Color { get; set; }
        //日租金
        public double DailyRent { get; set; }
        //车牌号
        public string LicenseNO { get; set; }
        //车名
        public string Name { get; set; }
        //租车时间
        public int RentDate { get; set; }
        //租车人
        public string RentUser { get; set; }
        //租车时间
        public int YearsOFService { get; set; }

        //计算价格的方法
       // public abstract double CalcPrice();
        public Vehicle() { }


        public Vehicle(string color, double dailyrent, string licenseno, string name, int rentdate) {
            this.Color = color;
            this.DailyRent = dailyrent;
            this.LicenseNO = licenseno;
            this.Name = name;
            this.RentDate = rentdate;
            //this.RentUser = rentuser;
            //this.YearsOFService = yearsofservice;

}
    }
}