namespace GISBox.Forms
{
    partial class PointRenderer
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
            this.btnPointRendererCancel = new System.Windows.Forms.Button();
            this.btnPointRendererConfirm = new System.Windows.Forms.Button();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnClassBreaks = new System.Windows.Forms.RadioButton();
            this.rbtnUniqueValue = new System.Windows.Forms.RadioButton();
            this.rbtnSimple = new System.Windows.Forms.RadioButton();
            this.cldPointRenderer = new System.Windows.Forms.ColorDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.nudClassBreaksMaxSize = new System.Windows.Forms.NumericUpDown();
            this.nudClassBreaksMinSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudClassBreaksNum = new System.Windows.Forms.NumericUpDown();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPointRendererCancel
            // 
            this.btnPointRendererCancel.Location = new System.Drawing.Point(326, 346);
            this.btnPointRendererCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnPointRendererCancel.Name = "btnPointRendererCancel";
            this.btnPointRendererCancel.Size = new System.Drawing.Size(100, 29);
            this.btnPointRendererCancel.TabIndex = 27;
            this.btnPointRendererCancel.Text = "取消";
            this.btnPointRendererCancel.UseVisualStyleBackColor = true;
            this.btnPointRendererCancel.Click += new System.EventHandler(this.btnPointRendererCancel_Click);
            // 
            // btnPointRendererConfirm
            // 
            this.btnPointRendererConfirm.Location = new System.Drawing.Point(109, 346);
            this.btnPointRendererConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnPointRendererConfirm.Name = "btnPointRendererConfirm";
            this.btnPointRendererConfirm.Size = new System.Drawing.Size(100, 29);
            this.btnPointRendererConfirm.TabIndex = 26;
            this.btnPointRendererConfirm.Text = "确定";
            this.btnPointRendererConfirm.UseVisualStyleBackColor = true;
            this.btnPointRendererConfirm.Click += new System.EventHandler(this.btnPointRendererConfirm_Click);
            // 
            // nudSize
            // 
            this.nudSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudSize.Location = new System.Drawing.Point(394, 120);
            this.nudSize.Margin = new System.Windows.Forms.Padding(4);
            this.nudSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(113, 30);
            this.nudSize.TabIndex = 6;
            this.nudSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSimpleSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(322, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "大小:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(53, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "样式:";
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(125, 124);
            this.cboStyle.Margin = new System.Windows.Forms.Padding(4);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(129, 23);
            this.cboStyle.TabIndex = 21;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
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
            this.groupBox1.TabIndex = 20;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(462, 256);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "-";
            // 
            // nudClassBreaksMaxSize
            // 
            this.nudClassBreaksMaxSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksMaxSize.Location = new System.Drawing.Point(482, 248);
            this.nudClassBreaksMaxSize.Margin = new System.Windows.Forms.Padding(4);
            this.nudClassBreaksMaxSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudClassBreaksMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudClassBreaksMaxSize.Name = "nudClassBreaksMaxSize";
            this.nudClassBreaksMaxSize.Size = new System.Drawing.Size(65, 30);
            this.nudClassBreaksMaxSize.TabIndex = 10;
            this.nudClassBreaksMaxSize.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudClassBreaksMaxSize.ValueChanged += new System.EventHandler(this.nudClassBreaksMaxSize_ValueChanged);
            // 
            // nudClassBreaksMinSize
            // 
            this.nudClassBreaksMinSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksMinSize.Location = new System.Drawing.Point(394, 248);
            this.nudClassBreaksMinSize.Margin = new System.Windows.Forms.Padding(4);
            this.nudClassBreaksMinSize.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.nudClassBreaksMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudClassBreaksMinSize.Name = "nudClassBreaksMinSize";
            this.nudClassBreaksMinSize.Size = new System.Drawing.Size(65, 30);
            this.nudClassBreaksMinSize.TabIndex = 8;
            this.nudClassBreaksMinSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudClassBreaksMinSize.ValueChanged += new System.EventHandler(this.nudClassBreaksMinSize_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(322, 252);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "大小:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(322, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "字段:";
            // 
            // nudClassBreaksNum
            // 
            this.nudClassBreaksNum.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksNum.Location = new System.Drawing.Point(144, 252);
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
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(394, 193);
            this.cboField.Margin = new System.Windows.Forms.Padding(4);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(96, 23);
            this.cboField.TabIndex = 8;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(53, 257);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "分级数:";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.LightCoral;
            this.btnColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColor.Location = new System.Drawing.Point(122, 191);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(132, 23);
            this.btnColor.TabIndex = 32;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(53, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "颜色:";
            // 
            // PointRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 463);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.nudClassBreaksMaxSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudClassBreaksMinSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.nudClassBreaksNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPointRendererCancel);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.btnPointRendererConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStyle);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PointRenderer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层渲染";
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPointRendererCancel;
        private System.Windows.Forms.Button btnPointRendererConfirm;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnClassBreaks;
        private System.Windows.Forms.RadioButton rbtnUniqueValue;
        private System.Windows.Forms.RadioButton rbtnSimple;
        private System.Windows.Forms.ColorDialog cldPointRenderer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudClassBreaksMaxSize;
        private System.Windows.Forms.NumericUpDown nudClassBreaksMinSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudClassBreaksNum;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label2;
    }
}