using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();

            this.textBoxId.Enabled = false;
            this.textBoxNum.Enabled = false;
            this.textBoxType.Enabled = false;
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerTo.Enabled = false;
        }

        OperatorDBClass operat = new OperatorDBClass();
        private void FormStatistics_Load(object sender, EventArgs e)
        {
            //销售明细表绑定
            operat.DataBind(dataGridView1, "select *from SellProductsInfo", "SellProductsInfo");

            //销售细节信息绑定
            string sellingSql = "select products_name,sum(sealling_price) sealling_price from SellProductsInfo group by products_name";
            string bidSql = "select products_name,sum(products_bid) products_bid  from SellProductsInfo group by products_name";
            operat.DataBind(dataGridViewName, sellingSql, "SellProductsInfo");
            operat.DataBind(dataGridViewmonth, bidSql, "SellProductsInfo");

            //显示自定义表头
            InitDataGridViewHead();
        }
        private void InitDataGridViewHead()
        {
            this.dataGridView1.Columns[0].HeaderText = "交易流水号";
            this.dataGridView1.Columns[0].Width = 120;
            this.dataGridView1.Columns[1].HeaderText = "商品条码";
            this.dataGridView1.Columns[1].Width = 120;
            this.dataGridView1.Columns[2].HeaderText = "商品名称";
            this.dataGridView1.Columns[2].Width = 100;
            this.dataGridView1.Columns[3].HeaderText = "商品规格";
            this.dataGridView1.Columns[3].Width = 80;
            this.dataGridView1.Columns[4].HeaderText = "商品进价";
            this.dataGridView1.Columns[4].Width = 80;
            this.dataGridView1.Columns[5].HeaderText = "商品售价";
            this.dataGridView1.Columns[5].Width = 100;
            this.dataGridView1.Columns[6].HeaderText = "商品成交价";
            this.dataGridView1.Columns[6].Width = 100;
            this.dataGridView1.Columns[7].HeaderText = "单品数量";
            this.dataGridView1.Columns[7].Width = 100;
            this.dataGridView1.Columns[8].HeaderText = "销售日期";
            this.dataGridView1.Columns[8].Width = 200;

            this.dataGridViewName.Columns[0].HeaderText = "商品名称";
            this.dataGridViewName.Columns[0].Width = 120;
            this.dataGridViewName.Columns[1].HeaderText = "销售总金额";
            this.dataGridViewName.Columns[1].Width = 150;

            this.dataGridViewmonth.Columns[0].HeaderText = "商品名称";
            this.dataGridViewmonth.Columns[0].Width = 120;
            this.dataGridViewmonth.Columns[1].HeaderText = "进货总金额";
            this.dataGridViewmonth.Columns[1].Width = 150;

        }

        /// <summary>
        /// 进行商品信息查询显示---模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string searchSql = "select *from SellProductsInfo where 1 = 1 ";
                if (checkBoxId.Checked)
                {
                    searchSql += " and products_id = " + textBoxId.Text;
                }
                if (checkBoxType.Checked)
                {
                    searchSql += " and products_spec = '"+textBoxType.Text+"'";
                }
                if (checkBoxNum.Checked)
                {
                    searchSql += " and single_sum = " +textBoxNum.Text;
                }
                if (checkBoxDate.Checked)
                {
                    searchSql += " and bargain_date >= '" + dateTimePickerFrom.Text + "'";
                    searchSql += " and bargain_date <= '" + dateTimePickerTo.Text + "'";
                }

                operat.OperateData(searchSql);
                operat.DataBind(dataGridView1, searchSql, "SellProductsInfo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询商品时发生" + ex.Message + "错误");
                return;
            }
            finally
            {
                //关闭数据库
            }
        }

        private void checkBoxId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxId.Checked)
            {
                textBoxId.Enabled = true;
            }
            else
            {
                textBoxId.Enabled = false;
            }
        }

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxType.Checked)
            {
                textBoxType.Enabled = true;
            }
            else
            {
                textBoxType.Enabled = false;
            }
        }

        private void checkBoxNum_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNum.Checked)
            {
                textBoxNum.Enabled = true;
            }
            else
            {
                textBoxNum.Enabled = false;
            }
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
            {
                dateTimePickerFrom.Enabled = true;
                dateTimePickerTo.Enabled = true;
            }
            else
            {
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custum",500,300);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            printPreviewDialog1.Document = printDocument1;

            DialogResult result = printPreviewDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void MyPrintDocument_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBoxShow.Text,new Font(new FontFamily("黑体"),12),System.Drawing.Brushes.Black,10,35);
        }
    }
}
