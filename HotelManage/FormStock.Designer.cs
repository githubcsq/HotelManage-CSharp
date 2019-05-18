namespace HotelManage
{
    partial class FormStock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSpec = new System.Windows.Forms.CheckBox();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.dateTimePickeTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.textBoxSpec = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxQuality = new System.Windows.Forms.CheckBox();
            this.checkBoxShengcha = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(829, 220);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxShengcha);
            this.groupBox1.Controls.Add(this.checkBoxQuality);
            this.groupBox1.Controls.Add(this.checkBoxName);
            this.groupBox1.Controls.Add(this.checkBoxSpec);
            this.groupBox1.Controls.Add(this.checkBoxId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.dateTimePickeTo);
            this.groupBox1.Controls.Add(this.dateTimePickerFrom);
            this.groupBox1.Controls.Add(this.comboBoxQuality);
            this.groupBox1.Controls.Add(this.textBoxSpec);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存管理";
            // 
            // checkBoxSpec
            // 
            this.checkBoxSpec.AutoSize = true;
            this.checkBoxSpec.Location = new System.Drawing.Point(23, 81);
            this.checkBoxSpec.Name = "checkBoxSpec";
            this.checkBoxSpec.Size = new System.Drawing.Size(91, 20);
            this.checkBoxSpec.TabIndex = 19;
            this.checkBoxSpec.Text = "商品规格";
            this.checkBoxSpec.UseVisualStyleBackColor = true;
            this.checkBoxSpec.CheckedChanged += new System.EventHandler(this.checkBoxSpec_CheckedChanged);
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(23, 44);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(75, 20);
            this.checkBoxId.TabIndex = 18;
            this.checkBoxId.Text = "条形码";
            this.checkBoxId.UseVisualStyleBackColor = true;
            this.checkBoxId.CheckedChanged += new System.EventHandler(this.checkBoxId_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "从";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(281, 143);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(24, 16);
            this.label.TabIndex = 16;
            this.label.Text = "至";
            // 
            // dateTimePickeTo
            // 
            this.dateTimePickeTo.Location = new System.Drawing.Point(311, 138);
            this.dateTimePickeTo.Name = "dateTimePickeTo";
            this.dateTimePickeTo.Size = new System.Drawing.Size(119, 26);
            this.dateTimePickeTo.TabIndex = 15;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(157, 138);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(119, 26);
            this.dateTimePickerFrom.TabIndex = 14;
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Location = new System.Drawing.Point(435, 90);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(141, 24);
            this.comboBoxQuality.TabIndex = 13;
            // 
            // textBoxSpec
            // 
            this.textBoxSpec.Location = new System.Drawing.Point(135, 79);
            this.textBoxSpec.Name = "textBoxSpec";
            this.textBoxSpec.Size = new System.Drawing.Size(141, 26);
            this.textBoxSpec.TabIndex = 6;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(435, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(141, 26);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(135, 42);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(141, 26);
            this.textBoxId.TabIndex = 2;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(212, 196);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(132, 34);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "查询";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Location = new System.Drawing.Point(334, 44);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(91, 20);
            this.checkBoxName.TabIndex = 20;
            this.checkBoxName.Text = "商品名称";
            this.checkBoxName.UseVisualStyleBackColor = true;
            this.checkBoxName.CheckedChanged += new System.EventHandler(this.checkBoxName_CheckedChanged);
            // 
            // checkBoxQuality
            // 
            this.checkBoxQuality.AutoSize = true;
            this.checkBoxQuality.Location = new System.Drawing.Point(334, 94);
            this.checkBoxQuality.Name = "checkBoxQuality";
            this.checkBoxQuality.Size = new System.Drawing.Size(75, 20);
            this.checkBoxQuality.TabIndex = 21;
            this.checkBoxQuality.Text = "保质期";
            this.checkBoxQuality.UseVisualStyleBackColor = true;
            this.checkBoxQuality.CheckedChanged += new System.EventHandler(this.checkBoxQuality_CheckedChanged);
            // 
            // checkBoxShengcha
            // 
            this.checkBoxShengcha.AutoSize = true;
            this.checkBoxShengcha.Location = new System.Drawing.Point(23, 138);
            this.checkBoxShengcha.Name = "checkBoxShengcha";
            this.checkBoxShengcha.Size = new System.Drawing.Size(91, 20);
            this.checkBoxShengcha.TabIndex = 22;
            this.checkBoxShengcha.Text = "生产日期";
            this.checkBoxShengcha.UseVisualStyleBackColor = true;
            this.checkBoxShengcha.CheckedChanged += new System.EventHandler(this.checkBoxShengcha_CheckedChanged);
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormStock";
            this.Text = "库存管理";
            this.Load += new System.EventHandler(this.FormStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ComboBox comboBoxQuality;
        private System.Windows.Forms.TextBox textBoxSpec;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DateTimePicker dateTimePickeTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxSpec;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxQuality;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxShengcha;
    }
}