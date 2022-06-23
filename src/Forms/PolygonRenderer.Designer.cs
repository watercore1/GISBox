namespace GISBox.Forms
{
    partial class PolygonRenderer
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
            this.btnPolygonRendererCancel = new System.Windows.Forms.Button();
            this.btnPolygonRendererConfirm = new System.Windows.Forms.Button();
            this.btnClassBreaksEndColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClassBreaksStartColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudClassBreaksNum = new System.Windows.Forms.NumericUpDown();
            this.cboClassBreaksField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnClassBreaks = new System.Windows.Forms.RadioButton();
            this.rbtnUniqueValue = new System.Windows.Forms.RadioButton();
            this.rbtnSimple = new System.Windows.Forms.RadioButton();
            this.cldPolygonRenderer = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSimpleColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPolygonRendererCancel
            // 
            this.btnPolygonRendererCancel.Location = new System.Drawing.Point(276, 362);
            this.btnPolygonRendererCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnPolygonRendererCancel.Name = "btnPolygonRendererCancel";
            this.btnPolygonRendererCancel.Size = new System.Drawing.Size(100, 29);
            this.btnPolygonRendererCancel.TabIndex = 33;
            this.btnPolygonRendererCancel.Text = "取消";
            this.btnPolygonRendererCancel.UseVisualStyleBackColor = true;
            this.btnPolygonRendererCancel.Click += new System.EventHandler(this.btnPolygonRendererCancel_Click);
            // 
            // btnPolygonRendererConfirm
            // 
            this.btnPolygonRendererConfirm.Location = new System.Drawing.Point(141, 362);
            this.btnPolygonRendererConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnPolygonRendererConfirm.Name = "btnPolygonRendererConfirm";
            this.btnPolygonRendererConfirm.Size = new System.Drawing.Size(100, 29);
            this.btnPolygonRendererConfirm.TabIndex = 32;
            this.btnPolygonRendererConfirm.Text = "确定";
            this.btnPolygonRendererConfirm.UseVisualStyleBackColor = true;
            this.btnPolygonRendererConfirm.Click += new System.EventHandler(this.btnPolygonRendererConfirm_Click);
            // 
            // btnClassBreaksEndColor
            // 
            this.btnClassBreaksEndColor.BackColor = System.Drawing.Color.LightCoral;
            this.btnClassBreaksEndColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClassBreaksEndColor.Location = new System.Drawing.Point(411, 268);
            this.btnClassBreaksEndColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnClassBreaksEndColor.Name = "btnClassBreaksEndColor";
            this.btnClassBreaksEndColor.Size = new System.Drawing.Size(100, 30);
            this.btnClassBreaksEndColor.TabIndex = 11;
            this.btnClassBreaksEndColor.UseVisualStyleBackColor = false;
            this.btnClassBreaksEndColor.Click += new System.EventHandler(this.btnClassBreaksEndColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(297, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "终止颜色:";
            // 
            // btnClassBreaksStartColor
            // 
            this.btnClassBreaksStartColor.BackColor = System.Drawing.Color.LightGreen;
            this.btnClassBreaksStartColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClassBreaksStartColor.Location = new System.Drawing.Point(169, 265);
            this.btnClassBreaksStartColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnClassBreaksStartColor.Name = "btnClassBreaksStartColor";
            this.btnClassBreaksStartColor.Size = new System.Drawing.Size(100, 30);
            this.btnClassBreaksStartColor.TabIndex = 8;
            this.btnClassBreaksStartColor.UseVisualStyleBackColor = false;
            this.btnClassBreaksStartColor.Click += new System.EventHandler(this.btnClassBreaksStartColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(56, 268);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "起始颜色:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(56, 193);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "字段:";
            // 
            // nudClassBreaksNum
            // 
            this.nudClassBreaksNum.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksNum.Location = new System.Drawing.Point(388, 186);
            this.nudClassBreaksNum.Margin = new System.Windows.Forms.Padding(4);
            this.nudClassBreaksNum.Name = "nudClassBreaksNum";
            this.nudClassBreaksNum.Size = new System.Drawing.Size(113, 30);
            this.nudClassBreaksNum.TabIndex = 6;
            this.nudClassBreaksNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudClassBreaksNum.ValueChanged += new System.EventHandler(this.nudClassBreaksNum_ValueChanged);
            // 
            // cboClassBreaksField
            // 
            this.cboClassBreaksField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassBreaksField.FormattingEnabled = true;
            this.cboClassBreaksField.Location = new System.Drawing.Point(128, 192);
            this.cboClassBreaksField.Margin = new System.Windows.Forms.Padding(4);
            this.cboClassBreaksField.Name = "cboClassBreaksField";
            this.cboClassBreaksField.Size = new System.Drawing.Size(96, 23);
            this.cboClassBreaksField.TabIndex = 8;
            this.cboClassBreaksField.SelectedIndexChanged += new System.EventHandler(this.cboClassBreaksField_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(297, 191);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "分级数:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnClassBreaks);
            this.groupBox1.Controls.Add(this.rbtnUniqueValue);
            this.groupBox1.Controls.Add(this.rbtnSimple);
            this.groupBox1.Location = new System.Drawing.Point(48, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(468, 70);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // rbtnClassBreaks
            // 
            this.rbtnClassBreaks.AutoSize = true;
            this.rbtnClassBreaks.Location = new System.Drawing.Point(337, 26);
            this.rbtnClassBreaks.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnClassBreaks.Name = "rbtnClassBreaks";
            this.rbtnClassBreaks.Size = new System.Drawing.Size(88, 19);
            this.rbtnClassBreaks.TabIndex = 2;
            this.rbtnClassBreaks.Text = "分级渲染";
            this.rbtnClassBreaks.UseVisualStyleBackColor = true;
            this.rbtnClassBreaks.CheckedChanged += new System.EventHandler(this.rbtnClassBreaks_CheckedChanged);
            // 
            // rbtnUniqueValue
            // 
            this.rbtnUniqueValue.AutoSize = true;
            this.rbtnUniqueValue.Location = new System.Drawing.Point(184, 25);
            this.rbtnUniqueValue.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnUniqueValue.Name = "rbtnUniqueValue";
            this.rbtnUniqueValue.Size = new System.Drawing.Size(103, 19);
            this.rbtnUniqueValue.TabIndex = 1;
            this.rbtnUniqueValue.Text = "唯一值渲染";
            this.rbtnUniqueValue.UseVisualStyleBackColor = true;
            this.rbtnUniqueValue.CheckedChanged += new System.EventHandler(this.rbtnUniqueValue_CheckedChanged);
            // 
            // rbtnSimple
            // 
            this.rbtnSimple.AutoSize = true;
            this.rbtnSimple.Checked = true;
            this.rbtnSimple.Location = new System.Drawing.Point(32, 25);
            this.rbtnSimple.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnSimple.Name = "rbtnSimple";
            this.rbtnSimple.Size = new System.Drawing.Size(118, 19);
            this.rbtnSimple.TabIndex = 0;
            this.rbtnSimple.TabStop = true;
            this.rbtnSimple.Text = "单一符号渲染";
            this.rbtnSimple.UseVisualStyleBackColor = true;
            this.rbtnSimple.CheckedChanged += new System.EventHandler(this.rbtnSimple_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(56, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "颜色:";
            // 
            // btnSimpleColor
            // 
            this.btnSimpleColor.BackColor = System.Drawing.Color.LightCoral;
            this.btnSimpleColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSimpleColor.Location = new System.Drawing.Point(125, 119);
            this.btnSimpleColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleColor.Name = "btnSimpleColor";
            this.btnSimpleColor.Size = new System.Drawing.Size(100, 30);
            this.btnSimpleColor.TabIndex = 5;
            this.btnSimpleColor.UseVisualStyleBackColor = false;
            this.btnSimpleColor.Click += new System.EventHandler(this.btnSimpleColor_Click);
            // 
            // PolygonRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 421);
            this.Controls.Add(this.btnClassBreaksEndColor);
            this.Controls.Add(this.btnSimpleColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPolygonRendererCancel);
            this.Controls.Add(this.btnClassBreaksStartColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPolygonRendererConfirm);
            this.Controls.Add(this.nudClassBreaksNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboClassBreaksField);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PolygonRenderer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层渲染";
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPolygonRendererCancel;
        private System.Windows.Forms.Button btnPolygonRendererConfirm;
        private System.Windows.Forms.Button btnClassBreaksEndColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClassBreaksStartColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudClassBreaksNum;
        private System.Windows.Forms.ComboBox cboClassBreaksField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnClassBreaks;
        private System.Windows.Forms.RadioButton rbtnUniqueValue;
        private System.Windows.Forms.RadioButton rbtnSimple;
        private System.Windows.Forms.ColorDialog cldPolygonRenderer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSimpleColor;
    }
}