using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormPurchase : Form
    {
        public FormPurchase()
        {
            InitializeComponent();
        }
        OperatorDBClass operat = new OperatorDBClass();

        private void InitDataGridViewHead()
        {
            this.dataGridViewPurchase.Columns[0].HeaderText = "商品编号";
            this.dataGridViewPurchase.Columns[0].Width = 100;

            this.dataGridViewPurchase.Columns[1].HeaderText = "供货商编号";
            this.dataGridViewPurchase.Columns[1].Width = 180;

            this.dataGridViewPurchase.Columns[2].HeaderText = "商品名称";
            this.dataGridViewPurchase.Columns[2].Width = 140;

            this.dataGridViewPurchase.Columns[3].HeaderText = "商品规格";
            this.dataGridViewPurchase.Columns[3].Width = 100;

            this.dataGridViewPurchase.Columns[4].HeaderText = "进价";
            this.dataGridViewPurchase.Columns[4].Width = 80;

            this.dataGridViewPurchase.Columns[5].HeaderText = "售价";
            this.dataGridViewPurchase.Columns[5].Width = 100;

            this.dataGridViewPurchase.Columns[6].HeaderText = "数量";
            this.dataGridViewPurchase.Columns[6].Width = 80;

            this.dataGridViewPurchase.Columns[7].HeaderText = "生产日期";
            this.dataGridViewPurchase.Columns[7].Width = 160;

            this.dataGridViewPurchase.Columns[8].HeaderText = "保质期";
            this.dataGridViewPurchase.Columns[8].Width = 160;

        }

        /// <summary>
        /// 录入商品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxId.Text != "" && textBoxName.Text != "" && textBoxBid.Text != "" && textBoxSellPrice.Text != "")
                {
                    if (operat.FindIdExist("Products", "products_id", textBoxId.Text) == true)
                    {
                        MessageBox.Show("该商品编号已经存在，请重新添加！", "提示");
                        return;
                    }
                    else
                    {
                        string productor_id = this.textBoxId.Text;
                        string vendorsname = ""; //供货商名称
                        string productor_name = this.textBoxName.Text;
                        string productor_spec = this.comboBoxSpec.Text;
                        string productor_bid = this.textBoxBid.Text;
                        string productor_sell_price = this.textBoxSellPrice.Text;
                        string productor_date = this.dateTimePicker1.Text;
                        string productor_quality_date = this.comboBoxQuality.Text;

                        vendorsname = operat.FindVendorsId("Vendors", comboBoxVen.Text);

                        string InsertSql = "insert into Products values(" + productor_id + ",'"+ vendorsname+"','" + productor_name + "','";
                        InsertSql += productor_spec + "','" + productor_bid + "','" + productor_sell_price + "','"+textBoxProNum.Text+"','" + productor_date + "','";
                        InsertSql += productor_quality_date + "')";

                        if (operat.OperateData(InsertSql) > 0)
                        {
                            operat.StoreManage(productor_id, productor_sell_price,textBoxProNum.Text);
                            MessageBox.Show("录入商品信息成功!", "提示");
                            operat.DataBind(this.dataGridViewPurchase, "select *from Products", "Products");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请填满所有字段", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭数据库
                operat.CloseDatabaseCnn();
            }
        }

        private void FormPurchase_Load(object sender, EventArgs e)
        {
            operat.BindDropdownlist("Vendors", this.comboBoxVen, 1);
            operat.DataBind(this.dataGridViewPurchase, "select *from Products", "Products");
            InitDataGridViewHead();

            //绑定商品单位到下拉框
            operat.BindDropdownlist("Products_Unit", this.comboBoxSpec, 1);
        }
    }
}
