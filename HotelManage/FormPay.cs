using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormPay : Form
    {
        public FormPay()
        {
            InitializeComponent();

            this.radioButtonCash.Checked = true;    //默认采用现金付款
            this.groupBoxVarity.Enabled = false;    //多样性付款不可用

            textBoxShuold.Text = operat.ProductsTotalPrice().ToString() + ".00";    //应收款
            textBoxOrigianl.Text = textBoxShuold.Text;                           //原价
            textBoxPrivilege.Text = "0.00";                                      //默认没有优惠
        }
        OperatorDBClass operat = new OperatorDBClass();

        /// <summary>
        /// 进行商品结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxActual.Text != "")
                {
                    //operat.InsertSeall();
                    if (DialogResult.OK == MessageBox.Show("你确定要结算吗？\n结算后将不能再次进行修改!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        operat.DeleteTableContent("Products_Temp");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("请输入金额！\n", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("进行商品结算时发生" + ex.Message + "的错误");
                return;
            }
            finally
            {
                //关闭数据库的链接
                operat.CloseDatabaseCnn();
            }
        }

        private void radioButtonVarity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVarity.Checked)
            {
                this.textBoxCash.Enabled = true;
                this.textBoxVip.Enabled = true;
                this.textBoxDiscount.Enabled = true;
                this.textBoxBankCard.Enabled = true;
            }
        }

        private void FormPay_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonCash.Checked)
            {
                this.textBoxCash.Enabled = false;
                this.textBoxVip.Enabled = false;
                this.textBoxDiscount.Enabled = false;
                this.textBoxBankCard.Enabled = false;
            }
            else
            {

            }
        }

        private void radioButtonCard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonCard.Checked)
            {
                this.groupBoxVarity.Enabled = true;

                this.textBoxCash.Enabled = false;
                this.textBoxVip.Enabled = false;
                this.textBoxDiscount.Enabled = false;
                this.textBoxBankCard.Enabled = true;
            }
        }


        private void textBoxActual_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxActual.Text.ToString().Length >= 1)
                {
                    double cash = Convert.ToDouble(textBoxShuold.Text);
                    double change = Convert.ToDouble(textBoxActual.Text) - cash;
                    textBoxChange.Text = change.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("计算零钱时发生了" + ex.Message + "的错误!");
                return;
            }

        }
    }
}
