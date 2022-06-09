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
    public partial class 商家管理界面 : Form
    {
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public 商家管理界面()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            Show1();
        }
        private void Show1()
        {
            string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
            //数据库连接
            SqlConnection conn = new SqlConnection(SqlStr);
            //打开数据库
            conn.Open();
            String sql = "select *from text3";
            //查询数据库后，将数据源绑定到dataGridView控件，使用数据集Datset 和适配器 DataAdapter(成对出现，是桥梁);
            ds = new DataSet();//新建数据集
            adapter = new SqlDataAdapter(sql, conn);
            //将获取的数据填充到数据集ds中
            adapter.Fill(ds, "text3");
            //数据源绑定到dataGridView
            dataGridView1.DataSource = ds.Tables["text3"];
            conn.Close();
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (dgvRow.Index % 2 == 0)
                {
                    dataGridView1.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else
                {
                    dataGridView1.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightPink;
                }

            }
        }
            private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int i = dataGridView1.CurrentRow.Index;
            string stuNo = dataGridView1.Rows[i].Cells["商品编号"].Value.ToString();
            string stuNo1 = dataGridView1.Rows[i].Cells["商品名称"].Value.ToString();
            string stuNo2 = dataGridView1.Rows[i].Cells["商品价格"].Value.ToString();
            DialogResult result = MessageBox.Show("确定要删除" + stuNo+stuNo1+stuNo2+ "的信息吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
                //数据库连接
                SqlConnection conn = new SqlConnection(SqlStr);
                //打开数据库
                conn.Open();
                string sql = "delete from text3 where 商品编号='" + stuNo + "'";
                SqlCommand command = new SqlCommand(sql,conn);
              int s=  command.ExecuteNonQuery();
              if (s > 0)
              {
                  MessageBox.Show("删除成功！");
                  Show1();
              }
              else
                  MessageBox.Show("删除失败！");
            }
        }
        private void 商家管理界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            登录界面 s = new 登录界面();
            s.Show();
            this.Hide();
        }

        private void 订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //执行修改
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);//需要参数；适配器（具有数据源的）用来批量更新dataset;
                adapter.Update(ds, "text3");//要设置一个主键，不然报错。
                MessageBox.Show("修改成功!");
                Show1();
            }
        }
        private void 修改账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            商家账号修改页面 f = new 商家账号修改页面();
            f.Show();
            this.Hide();
        }
    }
    
}
 