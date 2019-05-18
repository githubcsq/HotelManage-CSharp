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
    public partial class FormPro : Form
    {
        public FormPro()
        {
            InitializeComponent();
        }
        OperatorDBClass operat = new OperatorDBClass();
        public static FormPro pro = null;
        /// <summary>
        /// 前台销售单利模式
        /// </summary>
        /// <returns></returns>
        public static FormPro GetSingleInstance()
        {
            if (pro == null || pro.IsDisposed)
            {
                pro = new FormPro();
            }
            return pro;
        }

        public Form m_CurrentMdiChild;             //声明窗体
        /// <summary>
        /// 显示一个子窗体
        /// </summary>
        /// <param name="mdiForm"></param>
        public void ShowMdiChild(Form mdiForm)
        {
            if (this.m_CurrentMdiChild != null)
            {
                this.m_CurrentMdiChild.Close(); //关闭当前窗体
            }
            this.m_CurrentMdiChild = mdiForm;   //本窗体设置为当前窗体
            mdiForm.MdiParent = this;
            mdiForm.FormBorderStyle = FormBorderStyle.None;
            mdiForm.Show();
            mdiForm.Dock = DockStyle.Fill;
        }

        private void InitDataGridViewHead()
        {
            this.dataGridView1.Columns[0].HeaderText = "商品条码";
            this.dataGridView1.Columns[0].Width = 100;

            this.dataGridView1.Columns[1].HeaderText = "商品名称";
            this.dataGridView1.Columns[1].Width = 120;

            this.dataGridView1.Columns[2].HeaderText = "规格";
            this.dataGridView1.Columns[2].Width = 120;

            this.dataGridView1.Columns[3].HeaderText = "单价";
            this.dataGridView1.Columns[3].Width = 90;

            this.dataGridView1.Columns[4].Width = 120;
            this.dataGridView1.Columns[4].HeaderText = "数量";

            this.dataGridView1.Columns[5].HeaderText = "日期";
            this.dataGridView1.Columns[5].Width = 160;
        }
        private void FormPro_Load(object sender, EventArgs e)
        {
            //string searchsql = "select products_id,products_name,products_spec,sealling_price,products_num,seall_date";
            //searchsql += "from Products_Temp ";
            //searchsql += "where products_id = " + textBoxId.Text;
            string searchsql = "select *from Products_Temp";

            operat.BindDataGridView(this.dataGridView1, searchsql);
            this.InitDataGridViewHead();


            this.labelTotalPrice.Text = "";
            this.labelNum.Text = "";

            this.listBox1.Visible = false;

            CountProductNum();
        }

        //添加商品信息
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text != "")
                {
                    //string sql = "select *from Products where products_id = "+textBoxId.Text;
                    // string insertSql = "insert into ";
                    int num = operat.AddProductsSum(textBoxId.Text) + 1;
                    //先判断表中的条码是否存在，存在则商品数目+1，否则继续添加
                    if (operat.FindIdExist("Products_Temp", "products_id", textBoxId.Text) == true)
                    {
                        //进行商品数目+1操作
                        string UpdateSql = "update Products_Temp set products_num = " + num;
                        UpdateSql += " where products_id = " + textBoxId.Text;
                        if (operat.OperateData(UpdateSql) > 0)
                        {
                            //更新显示
                            //MessageBox.Show("更新成功","提示");

                            operat.BindDataGridView(this.dataGridView1, "select *from Products_Temp");

                            operat.InsertSeall(textBoxId.Text);
                            CountProductNum();

                        }
                        else
                        {
                            MessageBox.Show("没有该商品", "提示");
                        }
                    }
                    else
                    {
                        //进行插入商品操作
                        operat.OpProductTemp(textBoxId.Text);

                        //更新显示
                        operat.BindDataGridView(this.dataGridView1, "select *from Products_Temp");
                        CountProductNum();
                    }
                }
                else
                {
                    MessageBox.Show("请输入条形码", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加商品信息时发生" + ex.Message + "的错误!!!");
                return;
            }
            finally
            {
                //关闭数据库
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count > 1)
                {
                    if (textBoxActually.Text != "")
                    {
                        if (DialogResult.OK == MessageBox.Show("你确定要结算吗？!\n" + DateTime.Now + "\n", "提示",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                        {
                            string deleteSql = "delete from Products_Temp";
                            if (operat.OperateData(deleteSql) > 0)
                            {
                                MessageBox.Show("结账成功", "提示");
                                operat.BindDataGridView(this.dataGridView1, "select *from Products_Temp");
                                textBoxChange.Text = "";
                                textBoxActually.Text = "";
                                CountProductNum();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("结账失败", "提示");
                                return;
                            }
                            //FormPay pay = new FormPay();
                            //pay.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入付款金额", "提示");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("没有购买商品，请添加商品后再结算！", "提示");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("结算时发生" + ex.Message + "的错误");
                return;
            }
            finally
            {
                //关闭数据库
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 商品条码自动补全功能，可以在输入条码过程中自动提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = ConnectionClass.MyConnection();
            try
            {
                sqlconn.Open();
                listBox1.Items.Clear();
                if (textBoxId.Text.ToString().Length >= 4)
                {
                    AutoCompleteStringCollection mystring = new AutoCompleteStringCollection();
                    string strId = textBoxId.Text;
                    DataTable myTable = new DataTable();
                    myTable.Columns.Add("Products_id");
                    string strSql = "select Products_id from Products";// where Products_id like '%";
                    //strSql += strId + "%'";
                    SqlCommand cmd = new SqlCommand(strSql, sqlconn);
                    SqlDataReader dar = cmd.ExecuteReader();
                    while (dar.Read())
                    {
                        myTable.Rows.Add(dar["Products_id"].ToString());
                    }
                    DataRow[] dr = myTable.Select("Products_id like '%" + textBoxId.Text + "%'");
                    DataTable newdt = new DataTable();
                    newdt = myTable.Clone();
                    foreach (DataRow row in dr)
                    {
                        newdt.Rows.Add(row.ItemArray);
                    }
                    if (myTable.Rows.Count > 0 && (textBoxId.Text != ""))
                    {
                        listBox1.Visible = true;
                        for (int i = 0; i < newdt.Rows.Count; i++)
                        {
                            listBox1.Items.Add(newdt.Rows[i]["Products_id"].ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        /// <summary>
        /// 自动计算零钱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxActually_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxActually.Text.ToString().Length >= 1)
                {
                    double needMoney = Convert.ToDouble(labelTotalPrice.Text);
                    double actMonsy = Convert.ToDouble(textBoxActually.Text);

                    textBoxChange.Text = (actMonsy - needMoney).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算时发生" + ex.Message + "错误");
                return;
            }
        }

        /// <summary>
        /// 计算商品总数目和价格,并显示在对应位置
        /// </summary>
        private void CountProductNum()
        {
            Int32 initGoodsNum = 0;
            float fltMoney = 0.0f;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                initGoodsNum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                fltMoney += (Convert.ToSingle(dataGridView1.Rows[i].Cells[3].Value)) *
                    (Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value));
            }
            initGoodsNum = Math.Abs(initGoodsNum);
            labelNum.Text = initGoodsNum.ToString();
            labelTotalPrice.Text = fltMoney.ToString();
        }

        private void FormPro_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            switch (key)
            {
                case Keys.F5:
                    DeleteCurrentProducts();//删除商品
                    break;
                case Keys.F6:
                    //
                    //MessageBox.Show("您按下了F6");
                    ModifyProductsNum();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 删除当前商品
        /// </summary>
        private void DeleteCurrentProducts()
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("你确定要删除该商品吗？\n!", "提示", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation))
                {
                    string Products_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string deleteSql = "delete from Products_Temp where products_id = " + Products_id;
                    if (operat.OperateData(deleteSql) > 0)
                    {
                        MessageBox.Show("删除成功", "提示");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败", "提示");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                operat.BindDataGridView(this.dataGridView1, "select *from Products_Temp");
            }

        }
        /// <summary>
        /// 修改产品的数量
        /// </summary>
        private void ModifyProductsNum()
        {
            try
            {
                string Products_num = "";
                FormModifyProductsNum modify = new FormModifyProductsNum(Products_num);

                if (modify.ShowDialog() == DialogResult.OK)
                {
                    Products_num = modify.TextBoxValue;
                    modify.Close();
                    string Products_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string updateSql = "update Products_Temp set products_num = " + Products_num;
                    updateSql += " where products_id = " + Products_id;

                    if (operat.OperateData(updateSql) > 0)
                    {
                        MessageBox.Show("修改成功", "提示");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "提示");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }
            finally
            {
                operat.BindDataGridView(this.dataGridView1, "select *from Products_Temp");
            }
        }

        private void textBoxId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.  隐藏时就按回车无效
                textBoxId.Text = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                textBoxId.Focus();//重新获得焦点
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        private void textBoxId_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxId.Text = this.listBox1.SelectedItem.ToString();
            textBoxId.Focus();
            listBox1.Visible = false;
        }
    }
}
