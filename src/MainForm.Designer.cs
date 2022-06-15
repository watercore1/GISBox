namespace GISBox
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MyMapObjects.moLayers moLayers1 = new MyMapObjects.moLayers();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mannualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ssss = new System.Windows.Forms.ToolStripButton();
            this.缩小 = new System.Windows.Forms.ToolStripButton();
            this.漫游 = new System.Windows.Forms.ToolStripButton();
            this.缩放到全图 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.按位置选择 = new System.Windows.Forms.ToolStripButton();
            this.按属性选择 = new System.Windows.Forms.ToolStripButton();
            this.识别要素 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.开始编辑ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.结束编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动要素 = new System.Windows.Forms.ToolStripButton();
            this.编辑折点 = new System.Windows.Forms.ToolStripButton();
            this.创建要素 = new System.Windows.Forms.ToolStripButton();
            this.moMapControl1 = new MyMapObjects.moMapControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuStrip,
            this.helpMenuStrip});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(993, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuStrip
            // 
            this.fileMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewLayerMenuItem,
            this.openFileMenuItem,
            this.outputImageMenuItem});
            this.fileMenuStrip.Name = "fileMenuStrip";
            this.fileMenuStrip.Size = new System.Drawing.Size(55, 24);
            this.fileMenuStrip.Text = "文件";
            // 
            // createNewLayerMenuItem
            // 
            this.createNewLayerMenuItem.Name = "createNewLayerMenuItem";
            this.createNewLayerMenuItem.Size = new System.Drawing.Size(226, 26);
            this.createNewLayerMenuItem.Text = "新建图层";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(226, 26);
            this.openFileMenuItem.Text = "打开 Shapefile 文件";
            // 
            // outputImageMenuItem
            // 
            this.outputImageMenuItem.Name = "outputImageMenuItem";
            this.outputImageMenuItem.Size = new System.Drawing.Size(226, 26);
            this.outputImageMenuItem.Text = "导出图片";
            // 
            // helpMenuStrip
            // 
            this.helpMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mannualMenuItem,
            this.说明ToolStripMenuItem});
            this.helpMenuStrip.Name = "helpMenuStrip";
            this.helpMenuStrip.Size = new System.Drawing.Size(55, 24);
            this.helpMenuStrip.Text = "帮助";
            // 
            // mannualMenuItem
            // 
            this.mannualMenuItem.Name = "mannualMenuItem";
            this.mannualMenuItem.Size = new System.Drawing.Size(156, 26);
            this.mannualMenuItem.Text = "操作文档";
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.说明ToolStripMenuItem.Text = "说明";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssss,
            this.缩小,
            this.漫游,
            this.缩放到全图,
            this.toolStripSeparator1,
            this.按位置选择,
            this.按属性选择,
            this.识别要素,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2,
            this.移动要素,
            this.编辑折点,
            this.创建要素});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(993, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ssss
            // 
            this.ssss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ssss.Image = ((System.Drawing.Image)(resources.GetObject("ssss.Image")));
            this.ssss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ssss.Name = "ssss";
            this.ssss.Size = new System.Drawing.Size(32, 32);
            this.ssss.Text = "toolStripButton1";
            this.ssss.ToolTipText = "放大";
            // 
            // 缩小
            // 
            this.缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.缩小.Image = ((System.Drawing.Image)(resources.GetObject("缩小.Image")));
            this.缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩小.Name = "缩小";
            this.缩小.Size = new System.Drawing.Size(32, 32);
            this.缩小.Text = "toolStripButton2";
            // 
            // 漫游
            // 
            this.漫游.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.漫游.Image = ((System.Drawing.Image)(resources.GetObject("漫游.Image")));
            this.漫游.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.漫游.Name = "漫游";
            this.漫游.Size = new System.Drawing.Size(32, 32);
            this.漫游.Text = "toolStripButton3";
            // 
            // 缩放到全图
            // 
            this.缩放到全图.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.缩放到全图.Image = ((System.Drawing.Image)(resources.GetObject("缩放到全图.Image")));
            this.缩放到全图.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩放到全图.Name = "缩放到全图";
            this.缩放到全图.Size = new System.Drawing.Size(32, 32);
            this.缩放到全图.Text = "toolStripButton4";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // 按位置选择
            // 
            this.按位置选择.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.按位置选择.Image = ((System.Drawing.Image)(resources.GetObject("按位置选择.Image")));
            this.按位置选择.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.按位置选择.Name = "按位置选择";
            this.按位置选择.Size = new System.Drawing.Size(32, 32);
            this.按位置选择.Text = "toolStripButton5";
            // 
            // 按属性选择
            // 
            this.按属性选择.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.按属性选择.Image = ((System.Drawing.Image)(resources.GetObject("按属性选择.Image")));
            this.按属性选择.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.按属性选择.Name = "按属性选择";
            this.按属性选择.Size = new System.Drawing.Size(32, 32);
            this.按属性选择.Text = "toolStripButton10";
            // 
            // 识别要素
            // 
            this.识别要素.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.识别要素.Image = ((System.Drawing.Image)(resources.GetObject("识别要素.Image")));
            this.识别要素.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.识别要素.Name = "识别要素";
            this.识别要素.Size = new System.Drawing.Size(32, 32);
            this.识别要素.Text = "toolStripButton6";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem1,
            this.结束编辑ToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(71, 32);
            this.toolStripDropDownButton2.Text = "编辑器";
            this.toolStripDropDownButton2.ToolTipText = "编辑器";
            // 
            // 开始编辑ToolStripMenuItem1
            // 
            this.开始编辑ToolStripMenuItem1.Name = "开始编辑ToolStripMenuItem1";
            this.开始编辑ToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.开始编辑ToolStripMenuItem1.Text = "开始编辑";
            // 
            // 结束编辑ToolStripMenuItem
            // 
            this.结束编辑ToolStripMenuItem.Name = "结束编辑ToolStripMenuItem";
            this.结束编辑ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.结束编辑ToolStripMenuItem.Text = "结束编辑";
            // 
            // 移动要素
            // 
            this.移动要素.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.移动要素.Image = ((System.Drawing.Image)(resources.GetObject("移动要素.Image")));
            this.移动要素.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.移动要素.Name = "移动要素";
            this.移动要素.Size = new System.Drawing.Size(32, 32);
            this.移动要素.Text = "toolStripButton7";
            // 
            // 编辑折点
            // 
            this.编辑折点.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.编辑折点.Image = global::GISBox.Properties.Resources.编辑节点;
            this.编辑折点.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.编辑折点.Name = "编辑折点";
            this.编辑折点.Size = new System.Drawing.Size(32, 32);
            this.编辑折点.Text = "toolStripButton8";
            // 
            // 创建要素
            // 
            this.创建要素.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.创建要素.Image = global::GISBox.Properties.Resources.创建要素;
            this.创建要素.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.创建要素.Name = "创建要素";
            this.创建要素.Size = new System.Drawing.Size(32, 32);
            this.创建要素.Text = "toolStripButton9";
            // 
            // moMapControl1
            // 
            this.moMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moMapControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.moMapControl1.FlashColor = System.Drawing.Color.Green;
            this.moMapControl1.Layers = moLayers1;
            this.moMapControl1.Location = new System.Drawing.Point(240, 66);
            this.moMapControl1.Name = "moMapControl1";
            this.moMapControl1.SelectionColor = System.Drawing.Color.Cyan;
            this.moMapControl1.Size = new System.Drawing.Size(741, 509);
            this.moMapControl1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(352, 597);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 616);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.moMapControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "GISBox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenuStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ssss;
        private System.Windows.Forms.ToolStripButton 缩小;
        private System.Windows.Forms.ToolStripButton 漫游;
        private System.Windows.Forms.ToolStripButton 缩放到全图;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 按位置选择;
        private System.Windows.Forms.ToolStripButton 识别要素;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton 移动要素;
        private System.Windows.Forms.ToolStripButton 编辑折点;
        private System.Windows.Forms.ToolStripButton 创建要素;
        private System.Windows.Forms.ToolStripButton 按属性选择;
        private System.Windows.Forms.ToolStripMenuItem createNewLayerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mannualMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private MyMapObjects.moMapControl moMapControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 结束编辑ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

