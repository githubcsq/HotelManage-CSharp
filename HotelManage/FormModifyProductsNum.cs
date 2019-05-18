using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManage
{
    public partial class FormModifyProductsNum : Form
    {
        public FormModifyProductsNum() : this(null)
        {

        }

        public string TextBoxValue
        {
            get { return textBoxNum.Text; }
            set { textBoxNum.Text = value; }
        }
        public FormModifyProductsNum(string value)
        {
            InitializeComponent();
            TextBoxValue = value;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
