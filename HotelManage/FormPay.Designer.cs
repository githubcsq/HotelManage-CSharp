namespace HotelManage
{
    partial class FormPay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxShuold = new System.Windows.Forms.TextBox();
            this.groupBoxVarity = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCash = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBankCard = new System.Windows.Forms.TextBox();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxVip = new System.Windows.Forms.TextBox();
            this.textBoxActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOrigianl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrivilege = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChange = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonCash = new System.Windows.Forms.RadioButton();
            this.radioButtonVarity = new System.Windows.Forms.RadioButton();
            this.radioButtonCard = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxVarity.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "应收款：";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(192, 389);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(116, 41);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "结算";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxShuold
            // 
            this.textBoxShuold.Location = new System.Drawing.Point(111, 20);
            this.textBoxShuold.Name = "textBoxShuold";
            this.textBoxShuold.Size = new System.Drawing.Size(100, 26);
            this.textBoxShuold.TabIndex = 2;
            // 
            // groupBoxVarity
            // 
            this.groupBoxVarity.Controls.Add(this.label7);
            this.groupBoxVarity.Controls.Add(this.textBoxCash);
            this.groupBoxVarity.Controls.Add(this.label6);
            this.groupBoxVarity.Controls.Add(this.textBoxBankCard);
            this.groupBoxVarity.Controls.Add(this.textBoxDiscount);
            this.groupBoxVarity.Controls.Add(this.label8);
            this.groupBoxVarity.Controls.Add(this.label9);
            this.groupBoxVarity.Controls.Add(this.textBoxVip);
            this.groupBoxVarity.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxVarity.Location = new System.Drawing.Point(12, 177);
            this.groupBoxVarity.Name = "groupBoxVarity";
            this.groupBoxVarity.Size = new System.Drawing.Size(509, 185);
            this.groupBoxVarity.TabIndex = 3;
            this.groupBoxVarity.TabStop = false;
            this.groupBoxVarity.Text = "多样性收款";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "现金：";
            // 
            // textBoxCash
            // 
            this.textBoxCash.Location = new System.Drawing.Point(108, 35);
            this.textBoxCash.Name = "textBoxCash";
            this.textBoxCash.Size = new System.Drawing.Size(100, 26);
            this.textBoxCash.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "银行卡：";
            // 
            // textBoxBankCard
            // 
            this.textBoxBankCard.Location = new System.Drawing.Point(108, 92);
            this.textBoxBankCard.Name = "textBoxBankCard";
            this.textBoxBankCard.Size = new System.Drawing.Size(384, 26);
            this.textBoxBankCard.TabIndex = 18;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Location = new System.Drawing.Point(108, 144);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(171, 26);
            this.textBoxDiscount.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "优惠券：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "VIP积分兑换:";
            // 
            // textBoxVip
            // 
            this.textBoxVip.Location = new System.Drawing.Point(364, 31);
            this.textBoxVip.Name = "textBoxVip";
            this.textBoxVip.Size = new System.Drawing.Size(100, 26);
            this.textBoxVip.TabIndex = 20;
            // 
            // textBoxActual
            // 
            this.textBoxActual.Location = new System.Drawing.Point(111, 63);
            this.textBoxActual.Name = "textBoxActual";
            this.textBoxActual.Size = new System.Drawing.Size(100, 26);
            this.textBoxActual.TabIndex = 5;
            this.textBoxActual.TextChanged += new System.EventHandler(this.textBoxActual_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "实收款：";
            // 
            // textBoxOrigianl
            // 
            this.textBoxOrigianl.Location = new System.Drawing.Point(318, 23);
            this.textBoxOrigianl.Name = "textBoxOrigianl";
            this.textBoxOrigianl.Size = new System.Drawing.Size(171, 26);
            this.textBoxOrigianl.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "原价：";
            // 
            // textBoxPrivilege
            // 
            this.textBoxPrivilege.Location = new System.Drawing.Point(318, 66);
            this.textBoxPrivilege.Name = "textBoxPrivilege";
            this.textBoxPrivilege.Size = new System.Drawing.Size(171, 26);
            this.textBoxPrivilege.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "优惠：";
            // 
            // textBoxChange
            // 
            this.textBoxChange.Location = new System.Drawing.Point(111, 111);
            this.textBoxChange.Name = "textBoxChange";
            this.textBoxChange.Size = new System.Drawing.Size(100, 26);
            this.textBoxChange.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "找零：";
            // 
            // radioButtonCash
            // 
            this.radioButtonCash.AutoSize = true;
            this.radioButtonCash.Location = new System.Drawing.Point(282, 117);
            this.radioButtonCash.Name = "radioButtonCash";
            this.radioButtonCash.Size = new System.Drawing.Size(58, 20);
            this.radioButtonCash.TabIndex = 12;
            this.radioButtonCash.TabStop = true;
            this.radioButtonCash.Text = "现金";
            this.radioButtonCash.UseVisualStyleBackColor = true;
            this.radioButtonCash.CheckedChanged += new System.EventHandler(this.radioButtonCash_CheckedChanged);
            // 
            // radioButtonVarity
            // 
            this.radioButtonVarity.AutoSize = true;
            this.radioButtonVarity.Location = new System.Drawing.Point(421, 117);
            this.radioButtonVarity.Name = "radioButtonVarity";
            this.radioButtonVarity.Size = new System.Drawing.Size(74, 20);
            this.radioButtonVarity.TabIndex = 13;
            this.radioButtonVarity.TabStop = true;
            this.radioButtonVarity.Text = "多样性";
            this.radioButtonVarity.UseVisualStyleBackColor = true;
            this.radioButtonVarity.CheckedChanged += new System.EventHandler(this.radioButtonVarity_CheckedChanged);
            // 
            // radioButtonCard
            // 
            this.radioButtonCard.AutoSize = true;
            this.radioButtonCard.Location = new System.Drawing.Point(346, 117);
            this.radioButtonCard.Name = "radioButtonCard";
            this.radioButtonCard.Size = new System.Drawing.Size(58, 20);
            this.radioButtonCard.TabIndex = 14;
            this.radioButtonCard.TabStop = true;
            this.radioButtonCard.Text = "刷卡";
            this.radioButtonCard.UseVisualStyleBackColor = true;
            this.radioButtonCard.CheckedChanged += new System.EventHandler(this.radioButtonCard_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxShuold);
            this.groupBox2.Controls.Add(this.radioButtonCard);
            this.groupBox2.Controls.Add(this.radioButtonVarity);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButtonCash);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxChange);
            this.groupBox2.Controls.Add(this.textBoxActual);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxOrigianl);
            this.groupBox2.Controls.Add(this.textBoxPrivilege);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 159);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // FormPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxVarity);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.Name = "FormPay";
            this.Text = "结账";
            this.Load += new System.EventHandler(this.FormPay_Load);
            this.groupBoxVarity.ResumeLayout(false);
            this.groupBoxVarity.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxShuold;
        private System.Windows.Forms.GroupBox groupBoxVarity;
        private System.Windows.Forms.TextBox textBoxActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOrigianl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrivilege;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonCash;
        private System.Windows.Forms.RadioButton radioButtonVarity;
        private System.Windows.Forms.RadioButton radioButtonCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBankCard;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxVip;
        private System.Windows.Forms.TextBox textBoxCash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}