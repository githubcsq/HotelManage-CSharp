using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HotelManage
{
    public partial class FormSystem : Form
    {
        public FormSystem()
        {
            InitializeComponent();
            this.checkBoxPwdIsCheck.Checked = true; //默认隐藏密码

            //设置单击选中整行
            this.dataGridViewVendors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;

            this.dataGridViewVendors.ReadOnly = true;

            this.buttonSave.Enabled = false;
            this.buttonUserSave.Enabled = false;

            //编号不允许修改
            this.textBoxId.Enabled = false;
            this.textBoxUserId.Enabled = false;
        }

        private void InitDataGridViewHead()
        {
            //供货商标题设置
            this.dataGridViewVendors.Columns[0].HeaderText = "编号";
            this.dataGridViewVendors.Columns[1].HeaderText = "姓名";
            this.dataGridViewVendors.Columns[2].HeaderText = "联系人";
            this.dataGridViewVendors.Columns[3].HeaderText = "地址";
            this.dataGridViewVendors.Columns[4].HeaderText = "联系电话";

            this.dataGridViewVendors.Columns[0].Width = 80;
            this.dataGridViewVendors.Columns[1].Width = 180;
            this.dataGridViewVendors.Columns[2].Width = 80;
            this.dataGridViewVendors.Columns[3].Width = 180;
            this.dataGridViewVendors.Columns[4].Width = 120;

            //用户信息标题设置
            this.dataGridViewUser.Columns[0].HeaderText = "编号";
            this.dataGridViewUser.Columns[1].HeaderText = "姓名";
            this.dataGridViewUser.Columns[2].HeaderText = "密码";
            this.dataGridViewUser.Columns[3].HeaderText = "身份证";
            this.dataGridViewUser.Columns[4].HeaderText = "地址";
            this.dataGridViewUser.Columns[5].HeaderText = "Email";
            this.dataGridViewUser.Columns[6].HeaderText = "生日";

            this.dataGridViewUser.Columns[0].Width = 80;
            this.dataGridViewUser.Columns[1].Width = 100;
            this.dataGridViewUser.Columns[2].Width = 90;
            this.dataGridViewUser.Columns[3].Width = 120;
            this.dataGridViewUser.Columns[4].Width = 180;
            this.dataGridViewUser.Columns[5].Width = 180;
            this.dataGridViewUser.Columns[6].Width = 180;
            /*
            this.dataGridViewUser.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewUser.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            */
            //SetSortMode(dataGridViewUser);
            //SetSortMode(dataGridViewVendors);

            //单位信息表头
            dataGridViewUnit.Columns[0].HeaderText = "单位编号";
            dataGridViewUnit.Columns[0].Width = 100;
            dataGridViewUnit.Columns[1].HeaderText = "单位名称";
            dataGridViewUnit.Columns[1].Width = 100;
        }
        private void SetSortMode(DataGridView dgv)
        {
            for (int i = 0; i <= dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        OperatorDBClass operat = new OperatorDBClass();
        SqlConnection sqlconn = ConnectionClass.MyConnection();
        public SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        public DataSet dataSet = new DataSet();

        public static FormSystem system = null;
        /// <summary>
        /// 系统设置类的单例模式
        /// </summary>
        /// <returns></returns>
        public static FormSystem GetSingleInstance()
        {
            if (system == null || system.IsDisposed)
            {
                system = new FormSystem();
            }
            return system;
        }
        private void FormSystem_Load(object sender, EventArgs e)
        {
            //供货商信息显示
            string VendorsSql = "select *from vendors";
            operat.DataBind(this.dataGridViewVendors, VendorsSql, "Vendors");

            //用户信息绑定
            string userSql = "select *from Users";
            operat.DataBind(this.dataGridViewUser, userSql, "Users");

            //显示单位信息
            operat.DataBind(dataGridViewUnit, "select *from Products_Unit", "Products_Unit");

            this.InitDataGridViewHead();//自定义标题
        }

        /// <summary>
        /// 添加供货商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.textBoxName2.Text = "";
            this.textBoxName.Text = "";
            this.textBoxPhone.Text = "";
            this.textBoxAddress.Text = "";

            this.textBoxName.Focus();

            this.buttonAdd.Enabled = false;
            this.buttonSave.Enabled = true;
            this.textBoxId.Enabled = true;
        }

        /// <summary>
        /// 保存供货商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string id = this.textBoxId.Text;                   //编号
            string name = this.textBoxName.Text;            //供货商名字
            string address = this.textBoxAddress.Text;
            string phone = this.textBoxPhone.Text;
            string UserName = this.textBoxName2.Text;    //联系人名字

            try
            {
                if (name != "" && address != "" && phone != "" && UserName != "")
                {
                    if (operat.FindIdExist("Vendors", "Vendors_id", id) == true)
                    {
                        MessageBox.Show("该编号已经存在，请重新输入", "提示");
                        this.textBoxId.Text = "";       //清除编号
                        this.textBoxId.Focus();         //设置焦点
                        return;
                    }
                    else
                    {
                        string insertsql = "insert into Vendors (vendors_id,vendors_name,vendors_user_name,vendors_address,vendors_phone) values(";
                        insertsql += id;
                        insertsql += ",'" + name + "','" + UserName + "','" + address + "','" + phone + "')";
                        operat.OperateData(insertsql);

                        operat.DataBind(this.dataGridViewVendors, "select *from vendors", "Vendors");
                        MessageBox.Show("添加数据成功", "提示");
                        this.buttonAdd.Enabled = true;
                        this.buttonSave.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("必须填满所有的字段", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存供货商信息时发生 " + ex.Message + "错误");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 删除供货商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int Rows = dataGridViewVendors.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridViewVendors.Rows[Rows].Cells[0].Value);
                string deletesql = "delete from Vendors where Vendors_id = '" + id + "'";

                if (DialogResult.OK == MessageBox.Show("你确定要删除该记录吗？\n请三思而后行!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    if (operat.OperateData(deletesql) > 0)
                    {
                        MessageBox.Show("删除成功", "提示");
                        operat.DataBind(this.dataGridViewVendors, "select *from vendors", "Vendors");
                    }
                    else
                    {
                        MessageBox.Show("删除失败!", "提示");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除供货商信息时发生 " + ex.Message + "错误!");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 修改供货商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text != "" && textBoxName.Text != "" && textBoxName2.Text != "")
                {
                    string UpdateSql = "update Vendors set vendors_id=" + textBoxId.Text + ",vendors_name='"+textBoxName.Text+"',";
                    UpdateSql += "vendors_user_name='" + textBoxName2.Text + "',vendors_address='" + textBoxAddress.Text + "',";
                    UpdateSql += "vendors_phone = '" + textBoxPhone.Text + "'";

                    if (DialogResult.OK == MessageBox.Show("你确定要修改该记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        if (operat.OperateData(UpdateSql) > 0)
                        {
                            MessageBox.Show("修改数据成功!", "提示");
                            operat.DataBind(this.dataGridViewUser, "select *from Users", "Users");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("修改会员信息失败","提示");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请填满所有字段","提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改供货商信息时发生 " + ex.Message + "的错误");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUserId.Text != "" && textBoxUserName.Text != "" && textBoxUserPwd.Text != "")
                {
                    string InsertSql = "insert into Users values(";
                    InsertSql += textBoxUserId.Text + ",'" + textBoxUserName.Text + "','" + textBoxUserPwd.Text + "','";
                    InsertSql += textBoxUserIdCard.Text + "','" + textBoxUserAddress.Text + "','" + textBoxUserEmail.Text + "','";
                    InsertSql += dateTimePickerUserBirthday.Text + "')";

                    if (DialogResult.OK == MessageBox.Show("你确定要添加该记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        //检查要添加的用户编号是否存在
                        if (operat.FindIdExist("Users", "Users_id", textBoxUserId.Text) == true)
                        {
                            MessageBox.Show("用户编号已经存在，请重新添加！", "提示");
                            this.textBoxUserId.Text = "";
                            this.textBoxUserId.Focus();
                        }
                        else
                        {
                            if (operat.OperateData(InsertSql) > 0)
                            {
                                MessageBox.Show("添加用户信息成功！", "提示");
                                operat.DataBind(this.dataGridViewUser, "select *from Users", "Users");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("添加用户信息失败！", "提示");
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("请输入用户编号和其他字段!", "提示");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存用户信息时发生" + ex.Message + "的错误！");
                return;
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        private void checkBoxPwdIsCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkBoxPwdIsCheck.Checked)
            {
                this.textBoxUserPwd.PasswordChar = '*';
                this.checkBoxPwdIsCheck.Text = "显示";
            }
            else
            {
                this.textBoxUserPwd.PasswordChar = '\0';
                this.checkBoxPwdIsCheck.Text = "隐藏";
            }

        }

        /// <summary>
        /// 单击显示单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //将第3列显示为密码格式(******)
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        /// <summary>
        /// 编辑单元格控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUser_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox t = e.Control as TextBox;
            if (t != null)
            {
                if (this.dataGridViewUser.CurrentCell.ColumnIndex == 2)
                {
                    t.PasswordChar = '*';
                }
                else
                {
                    t.PasswordChar = new char();
                }
            }
        }
        /// <summary>
        /// 当单击单元格内容时，获取供货商单元格的内容，将其显示在控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewVendors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBoxId.Text = dataGridViewVendors.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.textBoxName.Text = dataGridViewVendors.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBoxName2.Text = dataGridViewVendors.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBoxAddress.Text = dataGridViewVendors.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.textBoxPhone.Text = dataGridViewVendors.Rows[e.RowIndex].Cells[4].Value.ToString();

            this.buttonAdd.Enabled = true;
        }
        /// <summary>
        /// 当单击单元格内容时，获取用户单元格的内容，将其显示在控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBoxUserId.Text = dataGridViewUser.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.textBoxUserName.Text = dataGridViewUser.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBoxUserPwd.Text = dataGridViewUser.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBoxUserIdCard.Text = dataGridViewUser.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.textBoxUserAddress.Text = dataGridViewUser.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.textBoxUserEmail.Text = dataGridViewUser.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.dateTimePickerUserBirthday.Text = dataGridViewUser.Rows[e.RowIndex].Cells[6].Value.ToString();

            this.buttonUserAdd.Enabled = true;
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            //this.textBoxUserId.Text = "";
            this.textBoxUserName.Text = "";
            this.textBoxUserPwd.Text = "";
            this.textBoxUserIdCard.Text = "";
            this.textBoxUserAddress.Text = "";
            this.textBoxUserEmail.Text = "";
            this.textBoxPhone.Text = "";

            this.buttonUserAdd.Enabled = false;
            this.buttonUserSave.Enabled = true;
            this.textBoxUserId.Enabled = true;  //编号可编辑
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUserModify_Click(object sender, EventArgs e)
        {
            try
            {
                //进行为空判断，这里为了方便，不允许修改编号!
                if (textBoxUserId.Text != "" && textBoxUserName.Text != "" && textBoxUserPwd.Text != "")
                {
                    string UpdateSql = "update Users set Users_name = '";
                    UpdateSql += textBoxUserName.Text + "',Users_pwd = '" + textBoxUserPwd.Text + "',";
                    UpdateSql += "Users_idcard = '" + textBoxUserIdCard.Text + "',";
                    UpdateSql += "Users_address = '" + textBoxUserAddress.Text + "',";
                    UpdateSql += "Users_email = '" + textBoxUserEmail.Text + "',";
                    UpdateSql += "Users_birthday = '" + dateTimePickerUserBirthday.Text + "'";
                    UpdateSql += "where Users_id = " + textBoxUserId.Text;

                    if (DialogResult.OK == MessageBox.Show("你确定要修改该记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        operat.OperateData(UpdateSql);
                        MessageBox.Show("修改数据成功!", "提示");
                        operat.DataBind(this.dataGridViewUser, "select *from Users", "Users");
                    }
                }
                else
                {
                    MessageBox.Show("必须填满所有字段", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户信息时发生了 " + ex.Message + "的错误!");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 尽心删除用户账号信息操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //进行简单的为空判断，用户编号不能为空，否则数据库中删除数据将发生错误！
                //这里没有考虑考完整性约束关系，Users表和UsersRoles表有关联！！！
                if (textBoxUserId.Text != "" && textBoxUserName.Text != "" && textBoxUserPwd.Text != "")
                {

                    string DeleteSql = "delete from Users where Users_id = " + textBoxUserId.Text;
                    if (DialogResult.OK == MessageBox.Show("你确定要删除该记录吗？\n请三思而后行!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        if (operat.OperateData(DeleteSql) > 0)
                        {
                            MessageBox.Show("删除用户信息成功!", "提示");
                            operat.DataBind(this.dataGridViewUser, "select *from Users", "Users");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除用户信息失败!", "错误");

                        }
                    }
                }
                else
                {
                    MessageBox.Show("用户编号为空，请输入要删除的编号!", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户信息时发生 " + ex.Message + "的错误!");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 添加商品单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUnitOk_Click(object sender, EventArgs e)
        {
            try
            {
                string insertSql = "insert into Products_Unit values ('"+textBoxUnitId.Text+"')";
                if (operat.OperateData(insertSql) > 0)
                {
                    MessageBox.Show("添加成功","提示");
                    operat.DataBind(dataGridViewUnit, "select *from Products_Unit", "Products_Unit");
                    return;
                }
                else
                {
                    MessageBox.Show("添加失败", "提示");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("添加单位时发生"+ex.Message+"的错误");
                return;
            }
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if(textBoxPhone.Text.ToString().Length >= 1)
            {
                //正则表达式--显示电话号码只能输入数字
                string regx = "d[0-9]*$";
                Regex reg = new Regex(regx);
                if (reg.IsMatch(this.textBoxPhone.Text))
                {
                    MessageBox.Show("请输入数字", "提示");
                }
            }
        }
    }
}
