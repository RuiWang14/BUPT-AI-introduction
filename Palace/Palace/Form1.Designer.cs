namespace Palace
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.宫殿设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.生成九宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求解ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.广度优先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.宫殿设置ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.求解ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1399, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 宫殿设置ToolStripMenuItem
            // 
            this.宫殿设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.设置ToolStripMenuItem});
            this.宫殿设置ToolStripMenuItem.Name = "宫殿设置ToolStripMenuItem";
            this.宫殿设置ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.宫殿设置ToolStripMenuItem.Text = "宫殿设置";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 30);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.生成九宫ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 30);
            this.toolStripMenuItem3.Text = "按顺序生成数字";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // 生成九宫ToolStripMenuItem
            // 
            this.生成九宫ToolStripMenuItem.Name = "生成九宫ToolStripMenuItem";
            this.生成九宫ToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.生成九宫ToolStripMenuItem.Text = "随机生成数字";
            this.生成九宫ToolStripMenuItem.Click += new System.EventHandler(this.生成九宫ToolStripMenuItem_Click);
            // 
            // 求解ToolStripMenuItem
            // 
            this.求解ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.广度优先ToolStripMenuItem,
            this.终止计算ToolStripMenuItem});
            this.求解ToolStripMenuItem.Name = "求解ToolStripMenuItem";
            this.求解ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.求解ToolStripMenuItem.Text = "求解";
            // 
            // 广度优先ToolStripMenuItem
            // 
            this.广度优先ToolStripMenuItem.Name = "广度优先ToolStripMenuItem";
            this.广度优先ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.广度优先ToolStripMenuItem.Text = "广度优先";
            this.广度优先ToolStripMenuItem.Click += new System.EventHandler(this.广度优先ToolStripMenuItem_Click);
            // 
            // 终止计算ToolStripMenuItem
            // 
            this.终止计算ToolStripMenuItem.Name = "终止计算ToolStripMenuItem";
            this.终止计算ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.终止计算ToolStripMenuItem.Text = "终止计算";
            this.终止计算ToolStripMenuItem.Click += new System.EventHandler(this.终止计算ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1399, 1030);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 宫殿设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成九宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 求解ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 广度优先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 终止计算ToolStripMenuItem;
    }
}

