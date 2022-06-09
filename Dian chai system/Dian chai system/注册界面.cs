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
using System.IO;
using System.Net;
namespace Dian_chai_system
{
    public partial class 注册界面 : Form
    {
      
        public 注册界面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//注册按钮
        {
            string SqlStr = "Server=LAPTOP-NGTPLSQG;User Id=sa;Pwd=123456;DataBase=用户信息数据库";
            SqlConnection conn = new SqlConnection(SqlStr);//数据库连接
            conn.Open();//打开数据库
          
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") {
                MessageBox.Show("请不要遗漏信息！");
            }
            if ((textBox3.Text == textBox4.Text)&&textBox3.Text!="")//验证密码
            {
                string strsql = "insert into text(手机号,用户名,密码) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                SqlCommand comm = new SqlCommand(strsql, conn);
                try
                {
                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("注册成功！");
                        登录界面 form1 = new 登录界面();
                        form1.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("注册失败！");
                        登录界面 form1 = new 登录界面();
                        form1.Show();
                        this.Hide();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();//关闭数据库连接
                   // conn.Dispose();//释放数据库连接
                }
            }
            if(textBox3.Text!=textBox4.Text) {
                MessageBox.Show("密码不一致，请重新输入");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CallPhone(textBox1.Text.ToString()))
            {
                MessageBox.Show("发送失败！");
            }
            else
            {
                MessageBox.Show("发送成功！");
            }
        }

        private bool CallPhone(string Recipient_Mobile_Num)
        {
            string PostUrl = "http://106.ihuyi.com/webservice/sms.php?method=Submit";
            //登录“互亿无线网站”查看用户名 登录用户中心->验证码通知短信>产品总览->API接口信息->APIID
            string account = "C63753195";
            //登录“互亿无线网站”查看密码 登录用户中心->验证码通知短信>产品总览->API接口信息->APIKEY
            string password = "38d578a70b772cc944d5561eccc917b1";
            //接收短信的用户的手机号码
            string mobile = Recipient_Mobile_Num;
            //随机生成四位数 可以模仿向用户发送验证码
            Random rad = new Random();
            int mobile_code = rad.Next(1000, 10000);   //生成随机数
            string content = "您的验证码是：" + mobile_code + "。请不要把验证码泄露给其他人。";

            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";  //用户名+密码+注册的手机号+验证码

            UTF8Encoding encoding = new UTF8Encoding();  //万国码
            //将 account, password, mobile, content 这四个内容添加到postStrTpl字符串当中
            //并利用encoding.GetBytes()将括号里面的字符串转化为二进制类型
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content)); //将字符串postStrTpl中的格式项替换为四个个指定的 Object 实例的值的文本等效项。再转为二进制数据

            //新建一个请求对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);//对统一资源标识符 (URI) 发出请求。 这是一个 abstract 类。
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            //间postData合并到 PostUrl中去
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();


            //以http://106.ihuyi.com/webservice/sms.php?method=Submit&account=你的APIID&password=你的APIKEY&mobile=接收短信的用户的手机号码&content=您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人。"    发起https请求   并获取请求结果
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
                //访问失败
            }
           
        }
    }
}
