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
    public partial class 商家账号修改页面 : Form
    {
        public 商家账号修改页面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
            //数据库连接
            SqlConnection conn = new SqlConnection(SqlStr);
            //打开数据库
            conn.Open();
            string strsql = "update text1 set 商家手机号='" + textBox3.Text + "',商家密码='" + textBox4.Text + "' where 商家手机号='" + textBox1.Text + "' and 商家密码='" + textBox2.Text + "'";
            SqlCommand comm = new SqlCommand(strsql, conn);
           int i= comm.ExecuteNonQuery();
           //SqlDataReader sql = comm.ExecuteReader();
            if (i>0)//满足用户名和密码一致
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
               // DialogResult dr = MessageBox.Show("修改失败");
                MessageBox.Show("修改失败");
                this.Show();
            }
            conn.Close();

        }

        private void 商家账号修改页面_FormClosed(object sender, FormClosedEventArgs e)
        {
            商家管理界面 f = new 商家管理界面();
            f.Show();
            this.Hide();
        }
    }
}
