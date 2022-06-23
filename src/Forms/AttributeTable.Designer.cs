namespace GISBox.Forms
{
    partial class AttributeTable
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnStartEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAddDield = new System.Windows.Forms.ToolStripButton();
            this.btnDelField = new System.Windows.Forms.ToolStripButton();
            this.btnEndEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectByAttribute = new System.Windows.Forms.ToolStripButton();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnClearSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.Nameshow = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartEdit,
            this.btnAddDield,
            this.btnDelField,
            this.btnEndEdit,
            this.toolStripSeparator3,
            this.btnSelectByAttribute,
            this.btnSelectAll,
            this.btnClearSelect,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(982, 35);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnStartEdit
            // 
            this.btnStartEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartEdit.Image = global::GISBox.Properties.Resources.开始编辑;
            this.btnStartEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartEdit.Name = "btnStartEdit";
            this.btnStartEdit.Size = new System.Drawing.Size(32, 32);
            this.btnStartEdit.Text = "开始编辑";
            this.btnStartEdit.Click += new System.EventHandler(this.btnStartEdit_Click);
            // 
            // btnAddDield
            // 
            this.btnAddDield.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDield.Image = global::GISBox.Properties.Resources.添加字段;
            this.btnAddDield.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDield.Name = "btnAddDield";
            this.btnAddDield.Size = new System.Drawing.Size(32, 32);
            this.btnAddDield.Text = "添加字段";
            this.btnAddDield.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnDelField
            // 
            this.btnDelField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelField.Image = global::GISBox.Properties.Resources.删除字段;
            this.btnDelField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelField.Name = "btnDelField";
            this.btnDelField.Size = new System.Drawing.Size(32, 32);
            this.btnDelField.Text = "删除字段";
            this.btnDelField.Click += new System.EventHandler(this.btnDelField_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEndEdit.Image = global::GISBox.Properties.Resources.保存编辑;
            this.btnEndEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(32, 32);
            this.btnEndEdit.Text = "停止编辑";
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // btnSelectByAttribute
            // 
            this.btnSelectByAttribute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectByAttribute.Image = global::GISBox.Properties.Resources.按属性选择;
            this.btnSelectByAttribute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectByAttribute.Name = "btnSelectByAttribute";
            this.btnSelectByAttribute.Size = new System.Drawing.Size(32, 32);
            this.btnSelectByAttribute.Text = "按属性选择";
            this.btnSelectByAttribute.Click += new System.EventHandler(this.btnSelectByAttribute_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectAll.Image = global::GISBox.Properties.Resources.全部选择;
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(32, 32);
            this.btnSelectAll.Text = "全部选择";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelect
            // 
            this.btnClearSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearSelect.Image = global::GISBox.Properties.Resources.清除所选要素;
            this.btnClearSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelect.Name = "btnClearSelect";
            this.btnClearSelect.Size = new System.Drawing.Size(32, 32);
            this.btnClearSelect.Text = "清除选择";
            this.btnClearSelect.Click += new System.EventHandler(this.btnClearSelect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nameshow,
            this.lblSelectedNum});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(982, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // Nameshow
            // 
            this.Nameshow.Name = "Nameshow";
            this.Nameshow.Size = new System.Drawing.Size(46, 20);
            this.Nameshow.Text = "name";
            // 
            // lblSelectedNum
            // 
            this.lblSelectedNum.AutoSize = false;
            this.lblSelectedNum.Name = "lblSelectedNum";
            this.lblSelectedNum.Size = new System.Drawing.Size(90, 20);
            this.lblSelectedNum.Text = "0/0已选择";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 35);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(982, 492);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.CellParsing);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ColumnHeaderMouseClick);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RowHeaderMouseClick);
            // 
            // AttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttributeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttributeTable_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnStartEdit;
        private System.Windows.Forms.ToolStripButton btnEndEdit;
        private System.Windows.Forms.ToolStripButton btnAddDield;
        private System.Windows.Forms.ToolStripButton btnDelField;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.ToolStripButton btnClearSelect;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedNum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel Nameshow;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSelectByAttribute;
    }
}