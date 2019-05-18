using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace HotelManage
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            MdiClient m = new MdiClient();
            this.Controls.Add(m);
            m.Dock = DockStyle.Fill;
            m.BackgroundImage = Properties.Resources.BackgroundImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public string usename;
        public string userlogintime;
        /// <summary>
        /// 检测某个子窗体是否已经打开
        /// </summary>
        /// <param name="ChildTypeName">子窗体名称</param>
        /// <returns></returns>
        private bool isExist(string ChildTypeName)
        {
            bool b_result = false;
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType().Name == ChildTypeName)
                {
                    frm.Activate();
                    b_result = true;
                    break;
                }
            }
            return b_result;
        }
        private bool ContainMDIChild( string ChildTypeString )
        {
            Form myMdiChild = null;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType().ToString() == ChildTypeString)
                {
                    myMdiChild = f;
                    break;
                }
            }
            if (myMdiChild != null)
            {
                myMdiChild.TopMost = true;
                myMdiChild.Show();
                myMdiChild.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OpenWindow(string ChileTypeString)
        {
            Form myChile = null;
            if (!ContainMDIChild(ChileTypeString))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type typForm = assembly.GetType(ChileTypeString);
                Object obj = typForm.InvokeMember(null,BindingFlags.DeclaredOnly |
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance| BindingFlags.CreateInstance,null,null,null);
                if (obj != null)
                {
                    myChile = obj as Form;
                    myChile.MdiParent = this;
                    myChile.Show();
                    myChile.Focus();
                }
            }

        }

        //FormPro pro = new FormPro();                              //前台销售界面
        //FormPro pro = FormPro.GetSingleInstance();
        //FormPurchase purchase = new FormPurchase();                //采购进货
       // FormStock stock = new FormStock();                         //库存管理
        //FormMembercs member = new FormMembercs();                  //会员管理界面
        //FormStatistics statistics = new FormStatistics();          //统计分析
        //FormSystem system = new FormSystem();                      //系统设置界面

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabeluser.Text = "当前用户:" + usename;
            this.toolStripStatusLabellogintime.Text = "登录时间:" + userlogintime;
        }

        //会员管理界面
        private void button_Member_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("member"))
            {
                FormMembercs member = new FormMembercs();
                member.MdiParent = this;
                member.FormBorderStyle = FormBorderStyle.None;
                member.MinimizeBox = false;
                member.Show();
                member.Dock = DockStyle.Fill;   //完全填充到应用程序中
            }
            */
            OpenWindow(typeof(FormMembercs).ToString());

        }

        //系统设置界面
        private void buttonSystem_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("system"))
            {
                system = new FormSystem();
                system.MdiParent = this;
                system.FormBorderStyle = FormBorderStyle.None;
                system.MinimizeBox = false;
                system.Show();
                system.Dock = DockStyle.Fill;   //完全填充到应用程序中
            }
            */
            OpenWindow(typeof(FormSystem).ToString());
        }

        //前台销售界面
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("pro"))
            {
                pro = new FormPro();
                pro.TopLevel = false;
                pro.MdiParent = this;
                pro.FormBorderStyle = FormBorderStyle.None;
                pro.MinimizeBox = false;
                pro.Show();
                pro.Dock = DockStyle.Fill;      //完全填充到应用程序中
            }
            */
            //UserControl1 us1 = new UserControl1();
            //us1.Show();
            OpenWindow(typeof(FormPro).ToString());
        }

        //采购进货界面
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("purchase"))
            {
                purchase = new FormPurchase();
                purchase.MdiParent = this;
                purchase.FormBorderStyle = FormBorderStyle.None;
                purchase.MinimizeBox = false;
                purchase.ShowIcon = false;
                purchase.Show();
                purchase.Dock = DockStyle.Fill;   //完全填充到应用程序中
            }
            else
            {
                purchase.Show();
            }
            */
            OpenWindow(typeof(FormPurchase).ToString());
        }

        //库存管理界面
        private void buttonStore_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("stock"))
            {
                stock = new FormStock();
                stock.MdiParent = this;
                stock.FormBorderStyle = FormBorderStyle.None;
                stock.MinimizeBox = false;
                stock.Show();
                stock.Dock = DockStyle.Fill;   //完全填充到应用程序中
            }
            */
            OpenWindow(typeof(FormStock).ToString());
        }

        //统计分析界面
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            /*
            if (!isExist("statistics"))
            {
                statistics = new FormStatistics();
                statistics.MdiParent = this;
                statistics.FormBorderStyle = FormBorderStyle.None;
                statistics.MinimizeBox = false;
                statistics.Show();
                statistics.Dock = DockStyle.Fill;   //完全填充到应用程序中
            }
            */
            OpenWindow(typeof(FormStatistics).ToString());
        }

        //退出系统,释放资源
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否确定要退出？", "提示"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Dispose(true);
            }
            else
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabeltime.Text = "当前时间:" + DateTime.Now;
        }

        private void buttonGuaji_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin.Showlogin();
        }
    }
}
