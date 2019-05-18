using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManage
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static FormLogin login = null;
        /// <summary>
        /// 创建登录窗口的单利模式
        /// </summary>
        /// <returns></returns>
        public static FormLogin GetSingleInstance()
        {
            if (login == null || login.IsDisposed)
            {
                login = new FormLogin();
            }
            return login;
        }

        public static void Showlogin()
        {
            FormLogin login = FormLogin.GetSingleInstance();
            login.Show();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "MP10.ssk";

            //OperatorDBClass operatordb = new OperatorDBClass();
            //operatordb.BindDropdownlist("users", this.comboBoxName, 1);
            this.checkBoxRember.Checked = true;
            if (this.checkBoxRember.Checked)
            {
                this.comboBoxName.Text = "admin";
                this.textBoxPwd.Text = "admin";
            }
            //this.comboBoxName.Text = "admin";
           // this.textBoxPwd.Text = "admin";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string name = this.comboBoxName.Text.Trim();
            string pwd = this.textBoxPwd.Text;

            if ((name == "") || (pwd == ""))
            {
                MessageBox.Show("请输入用户名和密码", "提示");
                return;
            }

            try
            {
                OperatorDBClass operatordb = new OperatorDBClass();

                if (operatordb.FindUserPwd(name) == pwd)
                {
                    FormMain formain = new FormMain();
                    formain.usename = name;             //传递登录名和时间给主窗口
                    formain.userlogintime = DateTime.Now.ToString();
                    this.Hide();
                    formain.Show();
                }
                else
                {
                    MessageBox.Show("密码错误,请重新输入!", "错误");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录系统时发生了 " + ex.Message + "错误!");
            }
            finally
            {
            }
        }

        private void checkBoxRember_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRember.Checked)
            {
                this.comboBoxName.Text = "admin";
                this.textBoxPwd.Text = "admin";
            }
            else
            {
                this.comboBoxName.Text = "admin";
                this.textBoxPwd.Text = "";
            }
        }

        private void logn_press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonOK_Click(sender,e);
            }
        }

    }
}
