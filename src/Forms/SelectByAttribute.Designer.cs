namespace GISBox.Forms
{
    partial class SelectByAttribute
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
            this.Layer_SelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Fields_List = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.UniqueValues = new System.Windows.Forms.ListBox();
            this.SQL_text = new System.Windows.Forms.TextBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button23 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Layer_SelectBox
            // 
            this.Layer_SelectBox.DropDownHeight = 120;
            this.Layer_SelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layer_SelectBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Layer_SelectBox.FormattingEnabled = true;
            this.Layer_SelectBox.IntegralHeight = false;
            this.Layer_SelectBox.Location = new System.Drawing.Point(120, 26);
            this.Layer_SelectBox.Margin = new System.Windows.Forms.Padding(4);
            this.Layer_SelectBox.Name = "Layer_SelectBox";
            this.Layer_SelectBox.Size = new System.Drawing.Size(295, 25);
            this.Layer_SelectBox.TabIndex = 0;
            this.Layer_SelectBox.SelectionChangeCommitted += new System.EventHandler(this.Layer_SelectBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(53, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "图层:";
            // 
            // Fields_List
            // 
            this.Fields_List.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Fields_List.FormattingEnabled = true;
            this.Fields_List.ItemHeight = 17;
            this.Fields_List.Location = new System.Drawing.Point(57, 85);
            this.Fields_List.Margin = new System.Windows.Forms.Padding(4);
            this.Fields_List.Name = "Fields_List";
            this.Fields_List.Size = new System.Drawing.Size(357, 174);
            this.Fields_List.TabIndex = 2;
            this.Fields_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Fields_List_MouseClick);
            this.Fields_List.SelectedIndexChanged += new System.EventHandler(this.Fields_List_SelectedIndexChanged);
            this.Fields_List.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Fields_List_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 290);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 330);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 370);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(112, 290);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 38);
            this.button4.TabIndex = 6;
            this.button4.Text = "<>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(167, 290);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 38);
            this.button5.TabIndex = 7;
            this.button5.Text = "Like";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(112, 330);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 38);
            this.button6.TabIndex = 8;
            this.button6.Text = ">=";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(112, 370);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 38);
            this.button7.TabIndex = 9;
            this.button7.Text = "<=";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(167, 330);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 38);
            this.button8.TabIndex = 10;
            this.button8.Text = "And";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(167, 370);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 38);
            this.button9.TabIndex = 11;
            this.button9.Text = "Or";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(241, 431);
            this.button17.Margin = new System.Windows.Forms.Padding(4);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(175, 38);
            this.button17.TabIndex = 19;
            this.button17.Text = "获取唯一值";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // UniqueValues
            // 
            this.UniqueValues.FormattingEnabled = true;
            this.UniqueValues.ItemHeight = 15;
            this.UniqueValues.Location = new System.Drawing.Point(241, 290);
            this.UniqueValues.Margin = new System.Windows.Forms.Padding(4);
            this.UniqueValues.Name = "UniqueValues";
            this.UniqueValues.Size = new System.Drawing.Size(173, 124);
            this.UniqueValues.TabIndex = 20;
            this.UniqueValues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UniqueValues_MouseDoubleClick);
            // 
            // SQL_text
            // 
            this.SQL_text.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SQL_text.Location = new System.Drawing.Point(56, 486);
            this.SQL_text.Margin = new System.Windows.Forms.Padding(4);
            this.SQL_text.Multiline = true;
            this.SQL_text.Name = "SQL_text";
            this.SQL_text.Size = new System.Drawing.Size(357, 95);
            this.SQL_text.TabIndex = 22;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(320, 603);
            this.button19.Margin = new System.Windows.Forms.Padding(4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(80, 38);
            this.button19.TabIndex = 23;
            this.button19.Text = "应用";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(232, 603);
            this.button20.Margin = new System.Windows.Forms.Padding(4);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(80, 38);
            this.button20.TabIndex = 26;
            this.button20.Text = "确定";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(144, 603);
            this.button21.Margin = new System.Windows.Forms.Padding(4);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(80, 38);
            this.button21.TabIndex = 25;
            this.button21.Text = "验证";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(196, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "字段列表";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(56, 602);
            this.button23.Margin = new System.Windows.Forms.Padding(4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(80, 39);
            this.button23.TabIndex = 29;
            this.button23.Text = "清除";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // Research
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 658);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.SQL_text);
            this.Controls.Add(this.UniqueValues);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Fields_List);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Layer_SelectBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectByAttribute";
            this.Text = "按属性查询";
            this.Load += new System.EventHandler(this.Research_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Layer_SelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ListBox UniqueValues;
        private System.Windows.Forms.TextBox SQL_text;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.ListBox Fields_List;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button23;
    }
}