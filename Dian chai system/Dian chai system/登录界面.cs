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
    public partial class 登录界面 : Form
    {

        public 登录界面()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            注册界面 form2 = new 注册界面();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("手机号不能为空");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("密码不能为空");
                textBox3.Focus();
                return;
            }
            string SqlStr = null;
            SqlConnection conn = null;
            string strsql = null;
            SqlCommand comm = null;
            SqlDataReader sql = null;
            if (radioButton1.Checked)
            {
                SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
                conn = new SqlConnection(SqlStr);//数据库连接
                conn.Open();//打开数据库
                strsql = "select * from text1 where 商家手机号='" + textBox2.Text + "'and 商家密码='" + textBox3.Text + "'";
                comm = new SqlCommand(strsql, conn);
                sql = comm.ExecuteReader();//执行selete语句，并返回一个datareader 对象
                if (sql.HasRows)//满足用户名和密码一致 hasrows判断数据库中是否有数据
                {
                    商家管理界面 form3 = new 商家管理界面();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("登陆失败");
                    this.Show();
                }
                sql.Close();
                conn.Close();
            }
            if (radioButton2.Checked)
            {
                SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
                conn = new SqlConnection(SqlStr);//数据库连接
                conn.Open();
                strsql = "select * from text where 手机号='" + textBox2.Text + "'and 密码='" + textBox3.Text + "'";
                comm = new SqlCommand(strsql, conn);
                sql = comm.ExecuteReader();
                if (sql.HasRows)//满足用户名和密码一致
                {
                    用户购买界面 form4 = new 用户购买界面();
                    form4.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("登陆失败");
                    this.Show();
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            用户账号修改界面 f = new 用户账号修改界面();
            f.Show();
            this.Hide();
        }
    }

          
}


