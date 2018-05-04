using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthChack
{

    public partial class frmMain : Form
    {

        //用于保存单个项目
        HealthCheckItem height, weight, sight, hearing, liverFun, ekg;
        HealthCheckSet setA;

        HealthCheckItem wuyan, xihua, xiaojie, xiaocui, gupei;
        public frmMain()
        {
            InitializeComponent();
        }
        //初始化
        List<HealthCheckItem> AllItem = new List<HealthCheckItem>();
        List<HealthCheckItem> items = new List<HealthCheckItem>();

        public Dictionary<string, HealthCheckSet> healthset = new Dictionary<string, HealthCheckSet>();


        private void frmMain_Load(object sender, EventArgs e)
        {

            //给lable 赋值
            lblSetName.Text = "";
            lblSetPrice.Text = "";
            //this.btnAdd.Enabled = false;
            //this.btnDel.Enabled = false;
            ////窗体加载时调用各个方法
            InitItems();
            InitSets();
            InitHealthSetList();


        }
        public void InitItems()
        {
            height = new HealthCheckItem("身高", 5, "用于检查身高");
            weight = new HealthCheckItem("体重", 8, "用于检查体重");
            sight = new HealthCheckItem("视力", 10, "用于检查视力");
            hearing = new HealthCheckItem("听力", 10, "用于检查听力");
            liverFun = new HealthCheckItem("肝功能", 50, "用于检查肝功能");
            ekg = new HealthCheckItem("心电图", 100, "用于检查心电图");

            AllItem.Add(height);
            AllItem.Add(weight);
            AllItem.Add(sight);
            AllItem.Add(hearing);
            AllItem.Add(liverFun);
            AllItem.Add(ekg);
        }
        public void InitSets()
        {
            items = new List<HealthCheckItem>();
            items.Add(height);
            items.Add(weight);
            items.Add(sight);
            setA = new HealthCheckSet("入学体检", items);
            //计算价格
            setA.CalcPrice();
            //更新
            UpdateSet(setA);
            this.healthset.Add("入学体检", setA);

        }

        public void InitHealthSetList()
        {
            //绑定下拉框
            this.cboSets.Items.Clear();
            this.cboSets.Items.Add("请选择");
            foreach (string key in this.healthset.Keys)
            {
                this.cboSets.Items.Add(key);
            }
            this.cboSets.SelectedIndex = 0;

        }

        //更新套餐检查项目
        private void UpdateSet(HealthCheckSet set)
        {
            this.dgvHealthList.DataSource = new BindingList<HealthCheckItem>(this.items);
        }


        private void cboSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setName = this.cboSets.Text;//套餐列表名称
            if (setName == "请选择")
            {
                //绑定数据
                this.dgvHealthList.DataSource = new BindingList<HealthCheckItem>();
                lblSetName.Text = "";
                lblSetPrice.Text = "";
                return;
            }
            //设置套餐名称
            lblSetName.Text = this.healthset[setName].Name;
            //设置套餐总价
            lblSetPrice.Text = this.healthset[setName].Price.ToString();
            //更新套餐检查项目
            UpdateSet(healthset[setName]);
            //此时设置删除按钮为可用状态
            this.btnDel.Enabled = true;
        }



        private void btnDel_Click(object sender, EventArgs e)
        {
            string setName = this.cboItems.Text;
            if (this.dgvHealthList.SelectedRows.Count == 0)
            {
                MessageBox.Show("您没有选中删除项", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int index = this.dgvHealthList.SelectedRows[0].Index;
            this.healthset[setName].Items.RemoveAt(index);
            this.healthset[setName].CalcPrice();
            UpdateSet(healthset[setName]);
            this.lblSetName.Text = setA.Name;
            this.lblSetPrice.Text = setA.Price.ToString();
            MessageBox.Show("删除成功!", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
        }


        private void cboItems_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //绑定下拉框
            if (this.cboItems.Text != "请选择")
            {
                this.btnAdd.Enabled = true;
            }
            else
            {
                this.btnAdd.Enabled = false;
            }
        }

        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定下拉框
            if (this.cboItems.Text != "请选择")
            {
                this.btnAdd.Enabled = true;
            }
            else
            {
                this.btnAdd.Enabled = false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cboItems.SelectedIndex == 0)
            {
                MessageBox.Show("请选择一个项目");
                return;
            }


            string cboSetText = this.cboSets.Text;
            if (cboSetText == "请选择")
            {
                MessageBox.Show("请选择套餐");
                return;
            }
            int index = this.cboItems.SelectedIndex ;
            if (!this.healthset[cboSetText].Items.Contains(AllItem[index]))
            {
                //添加检查项目
                this.healthset[cboSetText].Items.Add(AllItem[index]);
                //重新计算总价格
                this.healthset[cboSetText].CalcPrice();
                //更新套餐检查项目
                UpdateSet(this.healthset[cboSetText]);
                //刷新套餐名
                this.lblSetName.Text = this.healthset[cboSetText].Name;//给labe赋值
                //刷新价格
                this.lblSetPrice.Text = this.healthset[cboSetText].Price.ToString();//赋值
                MessageBox.Show("添加成功!", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("该项目已存在!", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            string setName = this.cboItems.Text;
            if (this.dgvHealthList.SelectedRows.Count == 0)
            {
                MessageBox.Show("您没有选中删除项", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int index = this.dgvHealthList.SelectedRows[0].Index;
            this.healthset[setName].Items.RemoveAt(index);
            this.healthset[setName].CalcPrice();
            UpdateSet(healthset[setName]);
            this.lblSetName.Text = setA.Name;
            this.lblSetPrice.Text = setA.Price.ToString();
            MessageBox.Show("删除成功!", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //DialogResult result = MessageBox.Show("您确定要删除吗?", "警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (result == DialogResult.OK)
            //{
            //    if (dgvHealthList.SelectedRows[0] != null && dgvHealthList.SelectedRows[0].Cells[0] != null && dgvHealthList.SelectedRows[0].Cells[0].Value != null)
            //    {
            //        //删除 套餐中所选的与内置检查项目相匹配的项
            //        HealthCheckSet.SetDic[cboSets.Text].Remove(HealthCheckItem.ItemDic[dgvHealthList.SelectedRows[0].Cells[0].Value.ToString()]);
            //        RenovateDGV();
            //    }

            }

        }

        }
  
    

