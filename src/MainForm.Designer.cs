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
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开Shapefile文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.编辑器 = new System.Windows.Forms.ToolStripSplitButton();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存编辑内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动要素 = new System.Windows.Forms.ToolStripButton();
            this.编辑折点 = new System.Windows.Forms.ToolStripButton();
            this.创建要素 = new System.Windows.Forms.ToolStripButton();
            this.moMapControl1 = new MyMapObjects.moMapControl();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(993, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建图层ToolStripMenuItem,
            this.打开Shapefile文件ToolStripMenuItem,
            this.导出图片ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建图层ToolStripMenuItem
            // 
            this.新建图层ToolStripMenuItem.Name = "新建图层ToolStripMenuItem";
            this.新建图层ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.新建图层ToolStripMenuItem.Text = "新建图层";
            // 
            // 打开Shapefile文件ToolStripMenuItem
            // 
            this.打开Shapefile文件ToolStripMenuItem.Name = "打开Shapefile文件ToolStripMenuItem";
            this.打开Shapefile文件ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.打开Shapefile文件ToolStripMenuItem.Text = "打开 Shapefile 文件";
            // 
            // 导出图片ToolStripMenuItem
            // 
            this.导出图片ToolStripMenuItem.Name = "导出图片ToolStripMenuItem";
            this.导出图片ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.导出图片ToolStripMenuItem.Text = "导出图片";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作文档ToolStripMenuItem,
            this.说明ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 操作文档ToolStripMenuItem
            // 
            this.操作文档ToolStripMenuItem.Name = "操作文档ToolStripMenuItem";
            this.操作文档ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.操作文档ToolStripMenuItem.Text = "操作文档";
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
            this.编辑器,
            this.移动要素,
            this.编辑折点,
            this.创建要素});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
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
            // 编辑器
            // 
            this.编辑器.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.编辑器.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem,
            this.保存编辑内容ToolStripMenuItem});
            this.编辑器.Image = ((System.Drawing.Image)(resources.GetObject("编辑器.Image")));
            this.编辑器.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.编辑器.Name = "编辑器";
            this.编辑器.Size = new System.Drawing.Size(76, 32);
            this.编辑器.Text = "编辑器";
            // 
            // 开始编辑ToolStripMenuItem
            // 
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.开始编辑ToolStripMenuItem.Text = "开始编辑";
            // 
            // 保存编辑内容ToolStripMenuItem
            // 
            this.保存编辑内容ToolStripMenuItem.Name = "保存编辑内容ToolStripMenuItem";
            this.保存编辑内容ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.保存编辑内容ToolStripMenuItem.Text = "停止编辑";
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
            this.moMapControl1.Location = new System.Drawing.Point(456, 66);
            this.moMapControl1.Name = "moMapControl1";
            this.moMapControl1.SelectionColor = System.Drawing.Color.Cyan;
            this.moMapControl1.Size = new System.Drawing.Size(525, 538);
            this.moMapControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 616);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ssss;
        private System.Windows.Forms.ToolStripButton 缩小;
        private System.Windows.Forms.ToolStripButton 漫游;
        private System.Windows.Forms.ToolStripButton 缩放到全图;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 按位置选择;
        private System.Windows.Forms.ToolStripButton 识别要素;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton 编辑器;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存编辑内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton 移动要素;
        private System.Windows.Forms.ToolStripButton 编辑折点;
        private System.Windows.Forms.ToolStripButton 创建要素;
        private System.Windows.Forms.ToolStripButton 按属性选择;
        private System.Windows.Forms.ToolStripMenuItem 新建图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开Shapefile文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private MyMapObjects.moMapControl moMapControl1;
    }
}

