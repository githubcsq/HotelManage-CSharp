namespace HotelManage
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.button_Member = new System.Windows.Forms.Button();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.buttonSystem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGuaji = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabeluser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabellogintime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabeltime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "前台销售";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "采购进货";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(205, 3);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(93, 72);
            this.buttonStore.TabIndex = 2;
            this.buttonStore.Text = "库存管理";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // button_Member
            // 
            this.button_Member.Location = new System.Drawing.Point(304, 3);
            this.button_Member.Name = "button_Member";
            this.button_Member.Size = new System.Drawing.Size(93, 72);
            this.button_Member.TabIndex = 3;
            this.button_Member.Text = "会员管理";
            this.button_Member.UseVisualStyleBackColor = true;
            this.button_Member.Click += new System.EventHandler(this.button_Member_Click);
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(403, 3);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(93, 72);
            this.buttonStatistics.TabIndex = 4;
            this.buttonStatistics.Text = "统计";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // buttonSystem
            // 
            this.buttonSystem.Location = new System.Drawing.Point(502, 3);
            this.buttonSystem.Name = "buttonSystem";
            this.buttonSystem.Size = new System.Drawing.Size(93, 72);
            this.buttonSystem.TabIndex = 5;
            this.buttonSystem.Text = "系统设置";
            this.buttonSystem.UseVisualStyleBackColor = true;
            this.buttonSystem.Click += new System.EventHandler(this.buttonSystem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonGuaji);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonStatistics);
            this.panel1.Controls.Add(this.buttonSystem);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button_Member);
            this.panel1.Controls.Add(this.buttonStore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 82);
            this.panel1.TabIndex = 6;
            // 
            // buttonGuaji
            // 
            this.buttonGuaji.Location = new System.Drawing.Point(601, 3);
            this.buttonGuaji.Name = "buttonGuaji";
            this.buttonGuaji.Size = new System.Drawing.Size(93, 72);
            this.buttonGuaji.TabIndex = 8;
            this.buttonGuaji.Text = "挂机";
            this.buttonGuaji.UseVisualStyleBackColor = true;
            this.buttonGuaji.Click += new System.EventHandler(this.buttonGuaji_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManage.Properties.Resources.meitehao1;
            this.pictureBox1.Location = new System.Drawing.Point(800, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(700, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(93, 72);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabeluser,
            this.toolStripStatusLabellogintime,
            this.toolStripStatusLabeltime,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabeluser
            // 
            this.toolStripStatusLabeluser.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabeluser.Name = "toolStripStatusLabeluser";
            this.toolStripStatusLabeluser.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabeluser.Text = "当前用户";
            // 
            // toolStripStatusLabellogintime
            // 
            this.toolStripStatusLabellogintime.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabellogintime.Name = "toolStripStatusLabellogintime";
            this.toolStripStatusLabellogintime.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabellogintime.Text = "登录时间";
            // 
            // toolStripStatusLabeltime
            // 
            this.toolStripStatusLabeltime.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabeltime.Name = "toolStripStatusLabeltime";
            this.toolStripStatusLabeltime.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabeltime.Text = "当前时间：";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(496, 17);
            this.toolStripStatusLabel3.Text = "开发者：太原工业学院-计算机工程系-网络工程-李棋、冯晨成、张超";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1019, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "超市收银管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button button_Member;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Button buttonSystem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabeluser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabeltime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabellogintime;
        private System.Windows.Forms.Button buttonGuaji;
    }
}

