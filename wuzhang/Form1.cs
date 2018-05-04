using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuzhang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int PriceSum(string key)
        {
            int sum = 0;
            foreach (HealthCheckItem item in HealthCheckSet.SetDic[key])
            {
                sum += item.Price;
            }
            return sum;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new BindingList<HealthCheckItem>();

        }
            
        

        private void UpdateSet(HealthCheckSet set)
        {
            //this.dataGridView1.DataSource = new BindingList<HealthCheckItem>(set.Items1);
        }
        public HealthCheckItem height, weight, sight, hearing, liverFun, ekg, bWaves, bloodPressure, bloodTest;
        //1.2 套餐集合
        public Dictionary<string, HealthCheckSet> hsets = new Dictionary<string, HealthCheckSet>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, HealthCheckItem> healthItems = new Dictionary<string, HealthCheckItem>();
            height = new HealthCheckItem("身高", 30, "用于检测身高");
            healthItems.Add(height.Name,height);
        }
      
            List<HealthCheckItem> AllItems = new List<HealthCheckItem>();
            List<HealthCheckItem> Items1 = new List<HealthCheckItem>();
            public void CalcPrice() {
                int totalPrice = 0;
                foreach (HealthCheckItem item in this.Items1)
                {
                    totalPrice += item.Price;
                }
               // this.Price = totalPrice;
            }

            private void button1_Click(object sender, EventArgs e)
            {
              
            }
           


            private void button2_Click(object sender, EventArgs e)
            {
                //int index = this.comboBox2.SelectedIndex - 1;
                //if (!this.HealthSet[comboBox1.Text].Items.Contains(AllIems[index])) {
                //    this.HealthSet[comboBox1.Text].Items.Add(AllIems[index]);
                //UpdateSet(this.HealthSet[comboBox1.Text]);

                if (HealthCheckSet.SetDic[comboBox2.Text].Contains(HealthCheckItem.ItemDic[comboBox2.Text]))
                {
                    MessageBox.Show(comboBox2.Text + "套餐中已存在该检查项目!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HealthCheckSet.DicAdd(HealthCheckSet.SetDic[comboBox1.Text], comboBox2.Text);
                    RenovateDGV();
                }

                
                }


            private void label7_Click(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("您确定要删除吗?", "警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    if (dataGridView1.SelectedRows[0] != null && dataGridView1.SelectedRows[0].Cells[0] != null && dataGridView1.SelectedRows[0].Cells[0].Value != null)
                    {
                        //删除 套餐中所选的与内置检查项目相匹配的项
                        HealthCheckSet.SetDic[comboBox2.Text].Remove(HealthCheckItem.ItemDic[dataGridView1.SelectedRows[0].Cells[0].Value.ToString()]);
                        RenovateDGV();
                    }

                }
            }

            private void RenovateDGV()
            {
                MessageBox.Show(comboBox2.Text);
                dataGridView1.DataSource = new BindingList<HealthCheckItem>(HealthCheckSet.SetDic[comboBox2.Text]);
                label4.Text = comboBox2.Text;
            }

            

            private void button3_Click(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex > 0)
                {
                    label2.Text = comboBox1.Text;
                    comboBox2.Enabled = true;
                    RenovateDGV();
                }
                else
                {
                    comboBox2.Enabled = true;
                }

            }

            private void dataGridView1_SizeChanged(object sender, EventArgs e)
            {

            }
            ////public void CalcPrice() {
            //    int totalPrce = 0;
            //    foreach (HealthCheckItem item in items) {
            //        totalPrce += item.Prce;

            //    }
            //    this.prce += totalPrce;
            //}
            //HealthCheckItem height, weight, sight, hearing, liverFun, ekg, bWavves, bloodPressure, bloodTest;
            //HealthCheckSet setA;
            //List<HealthCheckItem> AllIems = new List<HealthCheckItem>();
            //List<HealthCheckItem> items = new List<HealthCheckItem>();
            //public Dictionary<string, HealthCheckSet> HealthSet = new Dictionary<string, HealthCheckSet>();
            //private void label6_Click(object sender, EventArgs e)
            //{
               
            //}
    }
}
