using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qichezuping1
{
   public class Truck:Vehicle
    {
       public int load;

        public int Load
        {
            get { return load; }
            set { load = value; }
            
        }
        public Truck(string color, double dailyrent, string licenseno, string name, int rentdate, string rentuser, int yearsofservice, int
            load)
            : base(color, dailyrent, licenseno, name, rentdate)
        {

            this.Load = load;
        }
       //  public override double CalcPrice()  
       // {  
       //     double totalPrice = 0;  
       //     double basicPrice = this.RentDate * this.DailyRent;  
       //     if (this.RentDate <= 30)  
       //     {  
       //        totalPrice = basicPrice;  
       //     }  
       //     else  
       //     {  
                
       //         totalPrice = basicPrice + (this.RentDate - 30) * this.Load * this.DailyRent * 0.1;  
       //     }  
       //    return totalPrice;  
       //}  

        public Truck() { }
  
    }  

        }
    



