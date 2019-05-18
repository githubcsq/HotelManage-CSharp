using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormMembercs : Form
    {
        public FormMembercs()
        {
            InitializeComponent();
            this.dataGridViewMember.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//正行选中
            this.dataGridViewMember.ReadOnly = true;

            this.buttonMemberSave.Enabled = false;
            this.textBoxId.Enabled = false;         //编号不可编辑
        }
        OperatorDBClass operat = new OperatorDBClass();
        private void InitDataGridViewHead()
        {
            this.dataGridViewMember.Columns[0].HeaderText = "编号";
            this.dataGridViewMember.Columns[1].HeaderText = "姓名";
            this.dataGridViewMember.Columns[2].HeaderText = "积分";
            this.dataGridViewMember.Columns[3].HeaderText = "等级";
            this.dataGridViewMember.Columns[4].HeaderText = "地址";
            this.dataGridViewMember.Columns[5].HeaderText = "联系电话";
            this.dataGridViewMember.Columns[6].HeaderText = "Email";
            this.dataGridViewMember.Columns[7].HeaderText = "生日";
            this.dataGridViewMember.Columns[8].HeaderText = "注册日期";

            this.dataGridViewMember.Columns[0].Width = 60;
            this.dataGridViewMember.Columns[1].Width = 100;
            this.dataGridViewMember.Columns[2].Width = 60;
            this.dataGridViewMember.Columns[3].Width = 80;
            this.dataGridViewMember.Columns[4].Width = 180;
            this.dataGridViewMember.Columns[5].Width = 120;
            this.dataGridViewMember.Columns[6].Width = 120;
            this.dataGridViewMember.Columns[7].Width = 140;
            this.dataGridViewMember.Columns[8].Width = 160;
        }

        private void FormMembercs_Load(object sender, EventArgs e)
        {
            //显示会员信息
            string memSql = "select *from Customers ";
            operat.DataBind(this.dataGridViewMember, memSql, "Customers");
            this.InitDataGridViewHead();

            SetdataGridViewNoSort(this.dataGridViewMember);
        }
        /// <summary>
        /// 设置dataGridView禁止列排序
        /// </summary>
        private void SetdataGridViewNoSort(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;//自动按内容设置间距
            }
        }
        //保存会员信息
        private void buttonMemberSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text != "" && textBoxName.Text != "")
                {
                    if (DialogResult.OK == MessageBox.Show("你确定要添加记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        if (operat.FindIdExist("Customers", "cust_id", textBoxId.Text) == true)
                        {
                            MessageBox.Show("会员编号已经存在，请重新输入！", "提示");
                            textBoxId.Text = "";
                            textBoxId.Focus();
                        }
                        else
                        {
                            string sql = "insert into Customers values(";
                            sql += textBoxId.Text;
                            sql += ",'" + textBoxName.Text + "'";
                            sql += ",'" + textBoxIntegral.Text + "'";
                            sql += ",'" + textBoxRank.Text + "'";
                            sql += ",'" + textBoxAddress.Text + "'";
                            sql += ",'" + textBoxPhone.Text + "'";
                            sql += ",'" + textBoxEmail.Text + "'";
                            sql += ",'" + dateTimePickerBirthday.Value.ToShortDateString().ToString() + "'";
                            sql += ",'" + dateTimePickerReg.Value.ToShortDateString().ToString() + "')";
                            if (operat.OperateData(sql) > 0)
                            {
                                MessageBox.Show("添加会员成功", "提示");
                                operat.DataBind(this.dataGridViewMember, "select *from Customers", "Customers");
                                this.buttonMemberAdd.Enabled = true;
                                this.buttonMemberSave.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("添加会员信息失败", "提示");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请填满所有字段!", "错误");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加会员信息时发生 " + ex.Message + " 的错误!");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }

        /// <summary>
        /// 点击添加会员信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMemberAdd_Click(object sender, EventArgs e)
        {
            this.textBoxId.Text = "";
            this.textBoxName.Text = "";
            this.textBoxIntegral.Text = "";
            this.textBoxRank.Text = "";
            this.textBoxAddress.Text = "";
            this.textBoxPhone.Text = "";
            this.textBoxEmail.Text = "";
            this.dateTimePickerBirthday.Text = "";
            this.dateTimePickerReg.Text = "";

            this.buttonMemberAdd.Enabled = false;
            this.buttonMemberSave.Enabled = true;

            this.textBoxId.Enabled = true;     //编号可编辑
        }

        /// <summary>
        /// 获取单元格中的值，并显示灯在对应控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBoxId.Text = dataGridViewMember.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.textBoxName.Text = dataGridViewMember.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBoxIntegral.Text = dataGridViewMember.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBoxRank.Text = dataGridViewMember.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.textBoxAddress.Text = dataGridViewMember.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.textBoxPhone.Text = dataGridViewMember.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.textBoxEmail.Text = dataGridViewMember.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.dateTimePickerBirthday.Text = dataGridViewMember.Rows[e.RowIndex].Cells[7].Value.ToString();
            this.dateTimePickerReg.Text = dataGridViewMember.Rows[e.RowIndex].Cells[8].Value.ToString();


            string picPath = Application.StartupPath + "\\MemberPicture";

            if (dataGridViewMember.CurrentRow.Index == 0)
            {
                pictureBox.Load(picPath + "\\1.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 1)
            {
                pictureBox.Load(picPath + "\\2.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 2)
            {
                pictureBox.Load(picPath + "\\3.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 3)
            {
                pictureBox.Load(picPath + "\\4.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 4)
            {
                pictureBox.Load(picPath + "\\9.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 5)
            {
                pictureBox.Load(picPath + "\\6.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 6)
            {
                pictureBox.Load(picPath + "\\7.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 7)
            {
                pictureBox.Load(picPath + "\\8.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 8)
            {
                pictureBox.Load(picPath + "\\11.png");
            }
            else if (dataGridViewMember.CurrentRow.Index == 9)
            {
                pictureBox.Load(picPath + "\\10.png");
            }

            this.buttonMemberAdd.Enabled = true;
        }

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMemberModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text != "" &&textBoxName.Text != "" && textBoxPhone.Text != "")
                {
                    if (DialogResult.OK == MessageBox.Show("你确定要修改会员记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        string UpdateSql = "update Customers set cust_id=" + textBoxId.Text + ",cust_name='";
                        UpdateSql += textBoxName.Text + "',cust_integral='" + textBoxIntegral.Text + "',cust_rank ='" + textBoxRank.Text + "',";
                        UpdateSql += "cust_address = '" + textBoxAddress.Text + "'," + "cust_phone='" + textBoxPhone.Text + "',";
                        UpdateSql += "cust_email = '" + textBoxEmail.Text + "'," + "cust_birthday = '" + dateTimePickerBirthday.Text + "',";
                        UpdateSql += "cust_register_date ='" + dateTimePickerReg.Text + "'";
                        if (operat.OperateData(UpdateSql) > 0)
                        {
                            MessageBox.Show("修改会员信息成功!","提示");
                            operat.DataBind(this.dataGridViewMember, "select *from Customers", "Customers");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("修改会员信息失败！","提示");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请填满所有的字段！", "提示");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改会员信息时发生"+ex.Message+"的错误！");
                return;
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }

        }

        /// <summary>
        /// 删除会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //进行简单的为空判断，用户编号不能为空，否则数据库中删除数据将发生错误！
                if (textBoxId.Text != "" && textBoxName.Text != "" && textBoxIntegral.Text != "")
                {

                    string DeleteSql = "delete from Customers where cust_id = " + textBoxId.Text;
                    if (DialogResult.OK == MessageBox.Show("你确定要删除该记录吗？\n数据删除后无法恢复\n请三思而后行!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        if (operat.OperateData(DeleteSql) > 0)
                        {
                            MessageBox.Show("删除会员信息成功!", "提示");
                            operat.DataBind(this.dataGridViewMember, "select *from Customers", "Customers");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除会员信息失败!", "错误");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("会员编号为空，请输入要删除的编号!", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除会员信息时发生 " + ex.Message + "的错误!");
            }
            finally
            {
                //关闭数据库的连接
                operat.CloseDatabaseCnn();
            }
        }
    }
}
