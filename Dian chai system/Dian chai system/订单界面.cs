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
    public partial class Form5 : Form
    {
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
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
            String sql = "select *from text4";
            //查询数据库后，将数据源绑定到dataGridView控件，使用数据集Datset 和适配器 DataAdapter
            ds = new DataSet();
            adapter = new SqlDataAdapter(sql, conn);
            //将获取的数据填充到数据集ds中
            adapter.Fill(ds, "text4");
            //数据源绑定到dataGridView
            dataGridView1.DataSource = ds.Tables["text4"];
            conn.Close();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 派送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string stuNo1 = dataGridView1.Rows[i].Cells["商品名称"].Value.ToString();
            string stuNo2 = dataGridView1.Rows[i].Cells["商品价格"].Value.ToString();
            string stuNo3 = dataGridView1.Rows[i].Cells["合计"].Value.ToString();
            string stuNo4 = dataGridView1.Rows[i].Cells["手机号"].Value.ToString();
            string stuNo5 = dataGridView1.Rows[i].Cells["地址"].Value.ToString();
            string stuNo6 = dataGridView1.Rows[i].Cells["购买时间"].Value.ToString();
            DialogResult result = MessageBox.Show("商品名称为:" + stuNo1+"\n" + "对应的商品价格："+stuNo2+"\n"+"总金额："+ stuNo3+"\n"+"手机号为："+ stuNo4+"\n"+"买家地址:"+ stuNo5+ "\n"+"购买时间:"+stuNo6+"\n"+"是否派送？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
                //数据库连接
                SqlConnection conn = new SqlConnection(SqlStr);
                //打开数据库
                conn.Open();
                string sql = "delete from text4 where 手机号='" + stuNo4 + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                int s = command.ExecuteNonQuery();
                if (s > 0)
                {
                    MessageBox.Show("派送成功！");
                    Show1();
                }
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            商家管理界面 s = new 商家管理界面();
            s.Show();
            this.Hide();
        }
    }
}
