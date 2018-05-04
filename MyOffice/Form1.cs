using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Init() {
            List<jop> list1 = new List<jop>();
            list1.Add(new jop("编码", "购物车模式"));
            list1.Add(new jop("测试", "给购物车模块做单元测试"));
            SE ai=new SE（"112","艾边成",25,100,list1）;
             List<jop> list2 = new List<jop>();
            list1.Add(new jop("编码", "购物车模式"));
            list1.Add(new jop("测试", "给购物车模块做单元测试"));
            SE jop=new SE（"112","艾边成",25,100,list2）;
        }
    }
}
