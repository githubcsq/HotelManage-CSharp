using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
        }
        OperatorDBClass operat = new OperatorDBClass();
        private void InitDataGridViewHead()
        {
            dataGridView1.Columns[0].HeaderText = "商品编号";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "商品名称";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "商品规格";
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].HeaderText = "进价";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "零售价";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "数量";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].HeaderText = "生产日期";
            dataGridView1.Columns[6].Width = 180;
            dataGridView1.Columns[7].HeaderText = "保质期";
            dataGridView1.Columns[7].Width = 180;
            dataGridView1.Columns[8].HeaderText = "仓库编号";
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].HeaderText = "仓库名称";
            dataGridView1.Columns[9].Width = 180;
            dataGridView1.Columns[10].HeaderText = "零售价";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "库存数量";
            dataGridView1.Columns[11].Width = 180;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string searchSql = "select *from StoreInfoProduct where 1 = 1 ";
                if (checkBoxId.Checked)
                {
                    searchSql += " and products_id = "+textBoxId.Text;
                }
                if (checkBoxName.Checked)
                {
                    searchSql += " and products_name = '"+textBoxName.Text.ToString()+"'";
                }
                if (checkBoxSpec.Checked)
                {
                    searchSql += " and products_spec = '"+textBoxSpec.Text.ToString()+"'";
                }
                if (checkBoxQuality.Checked)
                {
                    searchSql += " and products_quality_date = "+comboBoxQuality.Text;
                }
                if (checkBoxShengcha.Checked)
                {
                    searchSql += " and products_date >= '"+dateTimePickerFrom.Text+"'";
                    searchSql += " and products_date <= '"+ dateTimePickeTo.Text+"'";
                }
                Console.WriteLine(searchSql);
                operat.OperateData(searchSql);
                operat.BindDataGridView(dataGridView1, searchSql);

            }catch(Exception ex)
            {
                MessageBox.Show("查询商品时发生"+ex.Message+"的错误");
                return;
            }
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            operat.BindDataGridView(dataGridView1, "select *from StoreInfoProduct");
            InitDataGridViewHead();

            this.textBoxId.Enabled = false;
            this.textBoxName.Enabled = false;
            this.textBoxSpec.Enabled = false;
            this.comboBoxQuality.Enabled = false;
            dateTimePickerFrom.Enabled = false;
            dateTimePickeTo.Enabled = false;

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

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {
                textBoxName.Enabled = true;
            }
            else
            {
                textBoxName.Enabled = false;
            }
        }

        private void checkBoxSpec_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpec.Checked)
            {
                textBoxSpec.Enabled = true;
            }
            else
            {
                textBoxSpec.Enabled = false;
            }
        }

        private void checkBoxQuality_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQuality.Checked)
            {
                comboBoxQuality.Enabled = true;
            }
            else
            {
                comboBoxQuality.Enabled = false;
            }
        }

        private void checkBoxShengcha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShengcha.Checked)
            {
                dateTimePickerFrom.Enabled = true;
                dateTimePickeTo.Enabled = true;
            }
            else
            {
                dateTimePickerFrom.Enabled = false;
                dateTimePickeTo.Enabled = false;
            }
        }
    }
}
