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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.panButton = new System.Windows.Forms.ToolStripButton();
            this.fullExtentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectLocationButton = new System.Windows.Forms.ToolStripButton();
            this.selectAttributeButton = new System.Windows.Forms.ToolStripButton();
            this.cleanSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.identifyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.startEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveFeatureButton = new System.Windows.Forms.ToolStripButton();
            this.moveNodeButton = new System.Windows.Forms.ToolStripButton();
            this.addNodeButton = new System.Windows.Forms.ToolStripButton();
            this.delNodeButton = new System.Windows.Forms.ToolStripButton();
            this.createFeatureButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mapScaleSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.coordinateStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.isProjectionCheckBox = new System.Windows.Forms.CheckBox();
            this.layersTreeView = new System.Windows.Forms.TreeView();
            this.layerRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stackOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downBottomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extentToLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAttributesListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveFeatureRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delFeatureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFeatureRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.finishDrawPartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishDrawFeatureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale1000000 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale5000000 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale10000000 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale20000000 = new System.Windows.Forms.ToolStripMenuItem();
            this.mapControl = new MyMapObjects.moMapControl();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.layerRightMenu.SuspendLayout();
            this.moveFeatureRightMenu.SuspendLayout();
            this.createFeatureRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuStrip,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(993, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "菜单栏";
            // 
            // fileMenuStrip
            // 
            this.fileMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.createNewLayerMenuItem,
            this.outputImageMenuItem});
            this.fileMenuStrip.Name = "fileMenuStrip";
            this.fileMenuStrip.Size = new System.Drawing.Size(55, 24);
            this.fileMenuStrip.Text = "文件";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(226, 26);
            this.openFileMenuItem.Text = "打开 Shapefile 文件";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // createNewLayerMenuItem
            // 
            this.createNewLayerMenuItem.Name = "createNewLayerMenuItem";
            this.createNewLayerMenuItem.Size = new System.Drawing.Size(226, 26);
            this.createNewLayerMenuItem.Text = "新建图层";
            this.createNewLayerMenuItem.Click += new System.EventHandler(this.createNewLayerMenuItem_Click);
            // 
            // outputImageMenuItem
            // 
            this.outputImageMenuItem.Name = "outputImageMenuItem";
            this.outputImageMenuItem.Size = new System.Drawing.Size(226, 26);
            this.outputImageMenuItem.Text = "导出图片";
            this.outputImageMenuItem.Click += new System.EventHandler(this.outputImageMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpMenuItem.Text = "帮助";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInButton,
            this.zoomOutButton,
            this.panButton,
            this.fullExtentButton,
            this.toolStripSeparator1,
            this.selectLocationButton,
            this.selectAttributeButton,
            this.cleanSelectedButton,
            this.identifyButton,
            this.toolStripSeparator2,
            this.editDropDownButton,
            this.moveFeatureButton,
            this.moveNodeButton,
            this.addNodeButton,
            this.delNodeButton,
            this.createFeatureButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(993, 35);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "工具栏";
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(32, 32);
            this.zoomInButton.Text = "放大";
            this.zoomInButton.ToolTipText = "放大";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(32, 32);
            this.zoomOutButton.Text = "缩小";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // panButton
            // 
            this.panButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.panButton.Image = ((System.Drawing.Image)(resources.GetObject("panButton.Image")));
            this.panButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(32, 32);
            this.panButton.Text = "漫游";
            this.panButton.Click += new System.EventHandler(this.panButton_Click);
            // 
            // fullExtentButton
            // 
            this.fullExtentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fullExtentButton.Image = ((System.Drawing.Image)(resources.GetObject("fullExtentButton.Image")));
            this.fullExtentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fullExtentButton.Name = "fullExtentButton";
            this.fullExtentButton.Size = new System.Drawing.Size(32, 32);
            this.fullExtentButton.Text = "缩放至全图";
            this.fullExtentButton.Click += new System.EventHandler(this.fullExtentButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // selectLocationButton
            // 
            this.selectLocationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectLocationButton.Image = ((System.Drawing.Image)(resources.GetObject("selectLocationButton.Image")));
            this.selectLocationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectLocationButton.Name = "selectLocationButton";
            this.selectLocationButton.Size = new System.Drawing.Size(32, 32);
            this.selectLocationButton.Text = "按位置选择";
            this.selectLocationButton.Click += new System.EventHandler(this.selectLocationButton_Click);
            // 
            // selectAttributeButton
            // 
            this.selectAttributeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAttributeButton.Image = ((System.Drawing.Image)(resources.GetObject("selectAttributeButton.Image")));
            this.selectAttributeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectAttributeButton.Name = "selectAttributeButton";
            this.selectAttributeButton.Size = new System.Drawing.Size(32, 32);
            this.selectAttributeButton.Text = "按属性选择";
            this.selectAttributeButton.Click += new System.EventHandler(this.selectAttributeButton_Click);
            // 
            // cleanSelectedButton
            // 
            this.cleanSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cleanSelectedButton.Image = global::GISBox.Properties.Resources.清除所选要素;
            this.cleanSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cleanSelectedButton.Name = "cleanSelectedButton";
            this.cleanSelectedButton.Size = new System.Drawing.Size(32, 32);
            this.cleanSelectedButton.Text = "清除所选要素";
            this.cleanSelectedButton.Click += new System.EventHandler(this.cleanSelectedButton_Click);
            // 
            // identifyButton
            // 
            this.identifyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.identifyButton.Image = ((System.Drawing.Image)(resources.GetObject("identifyButton.Image")));
            this.identifyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.identifyButton.Name = "identifyButton";
            this.identifyButton.Size = new System.Drawing.Size(32, 32);
            this.identifyButton.Text = "识别要素";
            this.identifyButton.Click += new System.EventHandler(this.identifyButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // editDropDownButton
            // 
            this.editDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEditMenuItem,
            this.endEditMenuItem});
            this.editDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("editDropDownButton.Image")));
            this.editDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editDropDownButton.Name = "editDropDownButton";
            this.editDropDownButton.Size = new System.Drawing.Size(71, 32);
            this.editDropDownButton.Text = "编辑器";
            this.editDropDownButton.ToolTipText = "编辑器";
            this.editDropDownButton.Click += new System.EventHandler(this.editDropDownButton_Click);
            // 
            // startEditMenuItem
            // 
            this.startEditMenuItem.Enabled = false;
            this.startEditMenuItem.Name = "startEditMenuItem";
            this.startEditMenuItem.Size = new System.Drawing.Size(156, 26);
            this.startEditMenuItem.Text = "开始编辑";
            this.startEditMenuItem.Click += new System.EventHandler(this.startEditMenuItem_Click);
            // 
            // endEditMenuItem
            // 
            this.endEditMenuItem.Enabled = false;
            this.endEditMenuItem.Name = "endEditMenuItem";
            this.endEditMenuItem.Size = new System.Drawing.Size(156, 26);
            this.endEditMenuItem.Text = "结束编辑";
            this.endEditMenuItem.Click += new System.EventHandler(this.endEditMenuItem_Click);
            // 
            // moveFeatureButton
            // 
            this.moveFeatureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveFeatureButton.Enabled = false;
            this.moveFeatureButton.Image = ((System.Drawing.Image)(resources.GetObject("moveFeatureButton.Image")));
            this.moveFeatureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveFeatureButton.Name = "moveFeatureButton";
            this.moveFeatureButton.Size = new System.Drawing.Size(32, 32);
            this.moveFeatureButton.Text = "移动要素";
            this.moveFeatureButton.Click += new System.EventHandler(this.moveFeatureButton_Click);
            // 
            // moveNodeButton
            // 
            this.moveNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveNodeButton.Enabled = false;
            this.moveNodeButton.Image = global::GISBox.Properties.Resources.移动节点;
            this.moveNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveNodeButton.Name = "moveNodeButton";
            this.moveNodeButton.Size = new System.Drawing.Size(32, 32);
            this.moveNodeButton.Text = "移动节点";
            this.moveNodeButton.Click += new System.EventHandler(this.moveNodeButton_Click);
            // 
            // addNodeButton
            // 
            this.addNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNodeButton.Enabled = false;
            this.addNodeButton.Image = global::GISBox.Properties.Resources.添加节点;
            this.addNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(32, 32);
            this.addNodeButton.Text = "添加节点";
            this.addNodeButton.Click += new System.EventHandler(this.addNodeButton_Click);
            // 
            // delNodeButton
            // 
            this.delNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delNodeButton.Enabled = false;
            this.delNodeButton.Image = global::GISBox.Properties.Resources.删除节点;
            this.delNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delNodeButton.Name = "delNodeButton";
            this.delNodeButton.Size = new System.Drawing.Size(32, 32);
            this.delNodeButton.Text = "删除节点";
            this.delNodeButton.Click += new System.EventHandler(this.delNodeButton_Click);
            // 
            // createFeatureButton
            // 
            this.createFeatureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createFeatureButton.Enabled = false;
            this.createFeatureButton.Image = ((System.Drawing.Image)(resources.GetObject("createFeatureButton.Image")));
            this.createFeatureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createFeatureButton.Name = "createFeatureButton";
            this.createFeatureButton.Size = new System.Drawing.Size(32, 32);
            this.createFeatureButton.Text = "创建要素";
            this.createFeatureButton.Click += new System.EventHandler(this.createFeatureButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapScaleSplitButton,
            this.coordinateStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 586);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(993, 30);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "状态栏";
            // 
            // mapScaleSplitButton
            // 
            this.mapScaleSplitButton.AutoSize = false;
            this.mapScaleSplitButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapScaleSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mapScaleSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnScale20000000,
            this.btnScale10000000,
            this.btnScale5000000,
            this.btnScale1000000});
            this.mapScaleSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("mapScaleSplitButton.Image")));
            this.mapScaleSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapScaleSplitButton.Name = "mapScaleSplitButton";
            this.mapScaleSplitButton.RightToLeftAutoMirrorImage = true;
            this.mapScaleSplitButton.Size = new System.Drawing.Size(200, 28);
            this.mapScaleSplitButton.Text = "地图比例尺";
            // 
            // coordinateStatusLabel
            // 
            this.coordinateStatusLabel.AutoSize = false;
            this.coordinateStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.coordinateStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinateStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.coordinateStatusLabel.Name = "coordinateStatusLabel";
            this.coordinateStatusLabel.Size = new System.Drawing.Size(200, 24);
            this.coordinateStatusLabel.Text = "坐标";
            // 
            // isProjectionCheckBox
            // 
            this.isProjectionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isProjectionCheckBox.AutoSize = true;
            this.isProjectionCheckBox.Location = new System.Drawing.Point(532, 597);
            this.isProjectionCheckBox.Name = "isProjectionCheckBox";
            this.isProjectionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.isProjectionCheckBox.TabIndex = 4;
            this.isProjectionCheckBox.Text = "投影坐标系";
            this.isProjectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // layersTreeView
            // 
            this.layersTreeView.AllowDrop = true;
            this.layersTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.layersTreeView.CheckBoxes = true;
            this.layersTreeView.Location = new System.Drawing.Point(12, 83);
            this.layersTreeView.Name = "layersTreeView";
            this.layersTreeView.Size = new System.Drawing.Size(250, 499);
            this.layersTreeView.TabIndex = 5;
            this.layersTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.layersTreeView_AfterCheck);
            this.layersTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.layersTreeView_ItemDrag);
            this.layersTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.layersTreeView_NodeMouseClick);
            this.layersTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.layersTreeView_DragDrop);
            this.layersTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.layersTreeView_DragEnter);
            this.layersTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layersTreeView_MouseDown);
            // 
            // layerRightMenu
            // 
            this.layerRightMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.layerRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stackOrderMenuItem,
            this.extentToLayerMenuItem,
            this.openAttributesListMenuItem,
            this.renderMenuItem,
            this.annotationMenuItem,
            this.delLayerMenuItem});
            this.layerRightMenu.Name = "layerRightMenu";
            this.layerRightMenu.Size = new System.Drawing.Size(159, 148);
            // 
            // stackOrderMenuItem
            // 
            this.stackOrderMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upOneMenuItem,
            this.downOneMenuItem,
            this.upTopMenuItem,
            this.downBottomMenuItem});
            this.stackOrderMenuItem.Name = "stackOrderMenuItem";
            this.stackOrderMenuItem.Size = new System.Drawing.Size(158, 24);
            this.stackOrderMenuItem.Text = "叠放顺序";
            // 
            // upOneMenuItem
            // 
            this.upOneMenuItem.Name = "upOneMenuItem";
            this.upOneMenuItem.Size = new System.Drawing.Size(224, 26);
            this.upOneMenuItem.Text = "上移一层";
            this.upOneMenuItem.Click += new System.EventHandler(this.upOneMenuItem_Click);
            // 
            // downOneMenuItem
            // 
            this.downOneMenuItem.Name = "downOneMenuItem";
            this.downOneMenuItem.Size = new System.Drawing.Size(224, 26);
            this.downOneMenuItem.Text = "下移一层";
            this.downOneMenuItem.Click += new System.EventHandler(this.downOneMenuItem_Click);
            // 
            // upTopMenuItem
            // 
            this.upTopMenuItem.Name = "upTopMenuItem";
            this.upTopMenuItem.Size = new System.Drawing.Size(224, 26);
            this.upTopMenuItem.Text = "上移到最顶层";
            this.upTopMenuItem.Click += new System.EventHandler(this.upTopMenuItem_Click);
            // 
            // downBottomMenuItem
            // 
            this.downBottomMenuItem.Name = "downBottomMenuItem";
            this.downBottomMenuItem.Size = new System.Drawing.Size(224, 26);
            this.downBottomMenuItem.Text = "下移到最低层";
            this.downBottomMenuItem.Click += new System.EventHandler(this.downBottomMenuItem_Click);
            // 
            // extentToLayerMenuItem
            // 
            this.extentToLayerMenuItem.Name = "extentToLayerMenuItem";
            this.extentToLayerMenuItem.Size = new System.Drawing.Size(210, 24);
            this.extentToLayerMenuItem.Text = "缩放至图层";
            this.extentToLayerMenuItem.Click += new System.EventHandler(this.extentToLayerMenuItem_Click);
            // 
            // openAttributesListMenuItem
            // 
            this.openAttributesListMenuItem.Name = "openAttributesListMenuItem";
            this.openAttributesListMenuItem.Size = new System.Drawing.Size(210, 24);
            this.openAttributesListMenuItem.Text = "打开属性表";
            this.openAttributesListMenuItem.Click += new System.EventHandler(this.openAttributesListMenuItem_Click);
            // 
            // renderMenuItem
            // 
            this.renderMenuItem.Name = "renderMenuItem";
            this.renderMenuItem.Size = new System.Drawing.Size(210, 24);
            this.renderMenuItem.Text = "渲染";
            this.renderMenuItem.Click += new System.EventHandler(this.renderMenuItem_Click);
            // 
            // annotationMenuItem
            // 
            this.annotationMenuItem.Name = "annotationMenuItem";
            this.annotationMenuItem.Size = new System.Drawing.Size(210, 24);
            this.annotationMenuItem.Text = "注记";
            this.annotationMenuItem.Click += new System.EventHandler(this.annotationMenuItem_Click);
            // 
            // delLayerMenuItem
            // 
            this.delLayerMenuItem.Name = "delLayerMenuItem";
            this.delLayerMenuItem.Size = new System.Drawing.Size(210, 24);
            this.delLayerMenuItem.Text = "移除";
            this.delLayerMenuItem.Click += new System.EventHandler(this.delLayerMenuItem_Click);
            // 
            // moveFeatureRightMenu
            // 
            this.moveFeatureRightMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.moveFeatureRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delFeatureMenuItem});
            this.moveFeatureRightMenu.Name = "moveFeatureRightMenu";
            this.moveFeatureRightMenu.Size = new System.Drawing.Size(111, 28);
            // 
            // delFeatureMenuItem
            // 
            this.delFeatureMenuItem.Name = "delFeatureMenuItem";
            this.delFeatureMenuItem.Size = new System.Drawing.Size(110, 24);
            this.delFeatureMenuItem.Text = "删除";
            this.delFeatureMenuItem.Click += new System.EventHandler(this.delFeatureMenuItem_Click);
            // 
            // createFeatureRightMenu
            // 
            this.createFeatureRightMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.createFeatureRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finishDrawPartMenuItem,
            this.finishDrawFeatureMenuItem});
            this.createFeatureRightMenu.Name = "createFeatureRightMenu";
            this.createFeatureRightMenu.Size = new System.Drawing.Size(143, 52);
            // 
            // finishDrawPartMenuItem
            // 
            this.finishDrawPartMenuItem.Name = "finishDrawPartMenuItem";
            this.finishDrawPartMenuItem.Size = new System.Drawing.Size(142, 24);
            this.finishDrawPartMenuItem.Text = "完成部件";
            this.finishDrawPartMenuItem.Click += new System.EventHandler(this.finishDrawPartMenuItem_Click);
            // 
            // finishDrawFeatureMenuItem
            // 
            this.finishDrawFeatureMenuItem.Name = "finishDrawFeatureMenuItem";
            this.finishDrawFeatureMenuItem.Size = new System.Drawing.Size(142, 24);
            this.finishDrawFeatureMenuItem.Text = "完成绘制";
            this.finishDrawFeatureMenuItem.Click += new System.EventHandler(this.finishDrawFeatureMenuItem_Click);
            // 
            // btnScale1000000
            // 
            this.btnScale1000000.Name = "btnScale1000000";
            this.btnScale1000000.Size = new System.Drawing.Size(224, 26);
            this.btnScale1000000.Text = "1 : 1000000";
            this.btnScale1000000.Click += new System.EventHandler(this.btnScale1000000_Click);
            // 
            // btnScale5000000
            // 
            this.btnScale5000000.Name = "btnScale5000000";
            this.btnScale5000000.Size = new System.Drawing.Size(224, 26);
            this.btnScale5000000.Text = "1 : 5000000";
            this.btnScale5000000.Click += new System.EventHandler(this.btnScale5000000_Click);
            // 
            // btnScale10000000
            // 
            this.btnScale10000000.Name = "btnScale10000000";
            this.btnScale10000000.Size = new System.Drawing.Size(224, 26);
            this.btnScale10000000.Text = "1 : 10000000";
            this.btnScale10000000.Click += new System.EventHandler(this.btnScale10000000_Click);
            // 
            // btnScale20000000
            // 
            this.btnScale20000000.Name = "btnScale20000000";
            this.btnScale20000000.Size = new System.Drawing.Size(224, 26);
            this.btnScale20000000.Text = "1 : 20000000";
            this.btnScale20000000.Click += new System.EventHandler(this.btnScale20000000_Click);
            // 
            // mapControl
            // 
            this.mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapControl.FlashColor = System.Drawing.Color.Green;
            this.mapControl.Location = new System.Drawing.Point(269, 83);
            this.mapControl.Margin = new System.Windows.Forms.Padding(4);
            this.mapControl.Name = "mapControl";
            this.mapControl.SelectionColor = System.Drawing.Color.Cyan;
            this.mapControl.Size = new System.Drawing.Size(712, 499);
            this.mapControl.TabIndex = 2;
            this.mapControl.MapScaleChanged += new MyMapObjects.moMapControl.MapScaleChangedHandle(this.MapControl_MapScaleChanged);
            this.mapControl.AfterTrackingLayerDraw += new MyMapObjects.moMapControl.AfterTrackingLayerDrawHandle(this.MapControl_AfterTrackingLayerDraw);
            this.mapControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseClick);
            this.mapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseDoubleClick);
            this.mapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseDown);
            this.mapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseMove);
            this.mapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 616);
            this.Controls.Add(this.layersTreeView);
            this.Controls.Add(this.isProjectionCheckBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "GISBox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.layerRightMenu.ResumeLayout(false);
            this.moveFeatureRightMenu.ResumeLayout(false);
            this.createFeatureRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripButton panButton;
        private System.Windows.Forms.ToolStripButton fullExtentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton selectLocationButton;
        private System.Windows.Forms.ToolStripButton identifyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveFeatureButton;
        private System.Windows.Forms.ToolStripButton moveNodeButton;
        private System.Windows.Forms.ToolStripButton createFeatureButton;
        private System.Windows.Forms.ToolStripButton selectAttributeButton;
        private System.Windows.Forms.ToolStripMenuItem createNewLayerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputImageMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSplitButton mapScaleSplitButton;
        private System.Windows.Forms.ToolStripDropDownButton editDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem startEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endEditMenuItem;
        private System.Windows.Forms.CheckBox isProjectionCheckBox;
        private System.Windows.Forms.ToolStripStatusLabel coordinateStatusLabel;
        private System.Windows.Forms.TreeView layersTreeView;
        private System.Windows.Forms.ContextMenuStrip layerRightMenu;
        private System.Windows.Forms.ToolStripMenuItem stackOrderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extentToLayerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAttributesListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upOneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downOneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upTopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downBottomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delLayerMenuItem;
        internal MyMapObjects.moMapControl mapControl;
        private System.Windows.Forms.ToolStripButton addNodeButton;
        private System.Windows.Forms.ToolStripButton delNodeButton;
        private System.Windows.Forms.ToolStripButton cleanSelectedButton;
        private System.Windows.Forms.ContextMenuStrip moveFeatureRightMenu;
        private System.Windows.Forms.ContextMenuStrip createFeatureRightMenu;
        private System.Windows.Forms.ToolStripMenuItem delFeatureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishDrawPartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishDrawFeatureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnScale20000000;
        private System.Windows.Forms.ToolStripMenuItem btnScale10000000;
        private System.Windows.Forms.ToolStripMenuItem btnScale5000000;
        private System.Windows.Forms.ToolStripMenuItem btnScale1000000;
    }
}

