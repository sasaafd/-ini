using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dian_chai_system
{
    public partial class 用户购买界面 : Form
    {
        public 用户购买界面()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        private void Form4_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "登录时间:" + DateTime.Now.ToLongTimeString();
           
            string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
            //数据库连接
             conn = new SqlConnection(SqlStr);
            //打开数据库
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select *from text3";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem lt = new ListViewItem();//新建一个填充集
                lt.Text = dr["商品编号"].ToString();
                lt.SubItems.Add(dr["商品名称"].ToString());
                lt.SubItems.Add(dr["商品价格"].ToString());
                listView1.Items.Add(lt);//填充
            }
            conn.Close();
        }
        double sum =0;
        string temp =null;
        string bian = null;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count>0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int index = dataGridView1.Rows.Add(row);
                dataGridView1.Rows[index].Cells[0].Value = this.listView1.FocusedItem.SubItems[0].Text;
                dataGridView1.Rows[index].Cells[1].Value = this.listView1.FocusedItem.SubItems[1].Text;
                dataGridView1.Rows[index].Cells[2].Value = this.listView1.FocusedItem.SubItems[2].Text;
                bian += this.listView1.FocusedItem.SubItems[1].Text+",";//商品名称的累加
                temp= temp+this.listView1.FocusedItem.SubItems[2].Text+",";//对应的商品价格
                   sum+=Double.Parse(this.listView1.FocusedItem.SubItems[2].Text);//总和
                   textBox1.Text = System.Convert.ToString(sum);
                 
            }
        }

        private void button1_Click(object sender, EventArgs e)//购买
        {
            if (textBox2.Text == ""|| textBox3.Text =="")//地址 手机号
            {
                MessageBox.Show("请将信息补充完整！");
            }
            else
            {
                string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
                //数据库连接
                SqlConnection conn = new SqlConnection(SqlStr);
                //打开数据库
                conn.Open();
               
                DialogResult rt = MessageBox.Show("商品名称：" + bian + "\n" + "对应的商品价格：" + temp, "是否确认购买？", MessageBoxButtons.YesNo);
                if (rt == DialogResult.Yes)
                {
                     String s = DateTime.Now.ToString();//购买时间和日期
                    SqlCommand com = new SqlCommand("insert into text4(商品名称,商品价格,合计,手机号,地址,购买时间) values('" + bian + "','" + temp + "','" + Convert.ToString(textBox1.Text) + "','" + Convert.ToString(textBox3.Text) + "','" + Convert.ToString(textBox2.Text) + "','"+Convert.ToString(s)+"')", conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("购买成功!");
                }
                else
                    MessageBox.Show("购买失败!");
            }
        }
       private void 用户购买界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            登录界面 s1 = new 登录界面();
            s1.Show();
            this.Hide();
        }
    }
}
