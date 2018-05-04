using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qichezuping1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
       
        public override double CalcPrice()
        {
            double totalPrice = 0;
            double basicPrice = this.RentDate * this.DailyRent;
            if (this.RentDate <= 30)
            {
                totalPrice = basicPrice;
            }
            else
            {
                totalPrice = basicPrice + (this.RentDate - 30) * this.DailyRent * 0.1;
            }
            return totalPrice;
        }
        //租车
        Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();
        //还车
        Dictionary<string, Vehicle> returnVehicle = new Dictionary<string, Vehicle>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Vehicle cui = new Car("紫色", 5, "豫A888888", "比亚迪F47", 3);
            vehicles.Add(cui.LicenseNO, cui);
            Vehicle cui1 = new Car("金色", 5, "豫B6666666", "比亚迪F47", 3);
            vehicles.Add(cui1.LicenseNO, cui1);
            Vehicle cu = new Car("紫色", 5, "豫A99999", "比亚迪F97", 3);
            returnVehicle.Add(cu.LicenseNO, cu);
            Vehicle hua = new Car("黑色", 5, "豫A666888", "布加迪威龙", 3);
            returnVehicle.Add(hua.LicenseNO, hua);

            //textBox7.Enabled = false; //这是 添加车辆 是 载重的txt控件 

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _Count = listView1.Columns.Count;
            int _Width = listView1.Width;
            foreach (ColumnHeader ch in listView1.Columns)
            {
                ch.Width = _Width / _Count;
            }

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _Count = listView2.Columns.Count;
            int _Width = listView2.Width;
            foreach (ColumnHeader ch in listView2.Columns)
            {
                ch.Width = _Width / _Count;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Vehicle item in returnVehicle.Values)
            {
                ListViewItem lv = new ListViewItem(item.LicenseNO);
                lv.SubItems.Add(item.Name);
                lv.SubItems.Add(item.Color);
                lv.SubItems.Add(item.RentDate.ToString());
                lv.SubItems.Add(item.YearsOFService.ToString());
                if (item is Car)
                {
                    lv.SubItems.Add("无");
                }
                else if(item is Truck)
                {
                    Truck truck = new Truck();
                    lv.SubItems.Add(truck.load.ToString());
                }
                listView2.Items.Add(lv);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitListView();
        }

        //private void Initlt()
        //{
        //    InitListView(listView1, vehicles);
        //}
        ////初始化 已经出租的车辆 的信息 到listView  
        //private void Initlt2()
        //{
        //    InitListView(listView2, returnVehicle);
        //}  

        private void InitListView()
        {
            listView1.Items.Clear();
            foreach (Vehicle item in vehicles.Values)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.LicenseNO;
                lv.SubItems.Add(item.Name);
                lv.SubItems.Add(item.Color);
                lv.SubItems.Add(item.YearsOFService.ToString());
                lv.SubItems.Add(item.DailyRent.ToString());
                //判断 是 轿车 还是卡车 是卡车 显示载重 ，轿车就显示 无  
                if (item is Truck)
                    lv.SubItems.Add((item as Truck).Load.ToString());
                else

                    lv.SubItems.Add("无");
                listView1.Items.Add(lv);

            }
        }

        //汽车 入库
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("请输入车牌号");
                    return;
            }
             if (textBox2.Text.Trim()=="")
            {
                MessageBox.Show("请输入车型");
                    return;
            }
             if (textBox3.Text.Trim()=="")
            {
                MessageBox.Show("请输入使用时间");
                    return;
            }
             if (textBox4.Text.Trim()=="")
            {
                MessageBox.Show("请输入每日租金");
                    return;
            
             
            }
             Vehicle vs = null;
             if (radioButton1.Checked)
             {
                 vs = new Car();
             }
             else {
                 Truck t = new Truck();
                 t.load = Convert.ToInt32(textBox5.Text.Trim());
                 vs = t;
             }
             vs.LicenseNO = textBox1.Text.Trim();
             vs.Name = textBox2.Text.Trim();
             vs.Color = comboBox1.Text.Trim();
             vs.YearsOFService = Convert.ToInt32(textBox3.Text.Trim());
             vehicles.Add(vs.LicenseNO, vs);
             MessageBox.Show("添加成功");
             foreach (Control item in textBox1.Controls)
             {
                 if (item is TextBox)
                 {
                     (item as TextBox).Clear();
                 }
                 else if(item is ComboBox){
                     (item as ComboBox).SelectedIndex = -1;
                 }
             }
        }

        /// <summary>
        /// 租车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("请输入租用者姓名");
                textBox1.Focus();
                return;
            }
            //是否 选中 listView1 的一行数据  
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择你要租用的车");
                return;
            }
            string lino = listView1.SelectedItems[0].Text;
            //可以被还的车 集合 添加一辆车  
            returnVehicle.Add(lino, vehicles[lino]);
            vehicles[lino].RentUser = textBox7.Text.Trim();
            //可被 租的车 集合删除一辆车  
            vehicles.Remove(lino);

            MessageBox.Show("租车成功");
            textBox1.Clear();   //清空 租车人信息  
            // Initlt();  
            //Initlt2();  
            InitListView();
        }

        //还车
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("请输入你租用的天数");
                textBox2.Focus();
                return;
            }
            //是否 选中 listView1 的一行数据  
            if (listView2.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择你要还用的车");
                return;
            } string lin = listView2.SelectedItems[0].Text;
            returnVehicle[lin].RentDate = int.Parse(this.textBox6.Text);
            double tota = returnVehicle[lin].CalcPrice();
            string msg = string.Format("你的总价事{0}", tota.ToString());
            MessageBox.Show(msg, "z注意", MessageBoxButtons.OK,
                MessageBoxIcon.None);
          
        vehicles.Add(lin, returnVehicle[lin]);  
        //可以被还的车 集合 删除一辆车  
        returnVehicle.Remove(lin);  

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox5.Enabled = false;

            }
            else {
                textBox5.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }





}
}