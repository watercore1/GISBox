using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MyMapObjects;

namespace GISBox.Forms
{
    public partial class AttributeTable : Form
    {
        #region 字段

        // (1) 主窗体和图层数据

        public MainForm Main { get; }
        public int FormIndex { get; set; }
        public int LayerIndex { get; }
        public moMapLayer Layer { get; set; }

        public DataTable Table { get; private set; }

        // (2) 操作变量

        public string NewFieldName { get; set; }
        public moValueTypeConstant NewFieldType { get; set; }

        public bool HasSelectField { get; private set; }
        public int SelectedFieldIndex { get; private set; }
        public bool IsAttributeChanged { get; private set; }

        #endregion 字段

        #region Constructors

        public AttributeTable(MainForm main, int index)
        {
            InitializeComponent();
            Main = main;
            LayerIndex = index;
            Layer = main.mapControl.Layers.GetItem(index);

            dataGridView.ReadOnly = true;
            HasSelectField = false;
            IsAttributeChanged = false;
            SelectedFieldIndex = -1;
            LoadData();
            Nameshow.Text = Layer.Name;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 每次调用都开一个全新线程
        /// </summary>
        public void BeginRefresh()
        {
            Thread thread = new Thread(InvokeWork);
            thread.Start();
        }

        private delegate void LoadDataHandler();

        public void InvokeWork()
        {
            LoadDataHandler mission = LoadData;
            BeginInvoke(mission);
        }

        /// <summary>
        /// load Data
        /// </summary>
        public void LoadData()
        {
            Table = new DataTable();
            dataGridView.DataSource = null;
            dataGridView.DataSource = Table;
            for (int i = 0; i < Layer.AttributeFields.Count; i++)
            {
                if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dDouble)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(double));
                }
                else if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dInt16)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(short));
                }
                else if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dInt32)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(int));
                }
                else if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dInt64)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(long));
                }
                else if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dSingle)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(float));
                }
                else if (Layer.AttributeFields.GetItem(i).ValueType == moValueTypeConstant.dText)
                {
                    Table.Columns.Add(Layer.AttributeFields.GetItem(i).Name, typeof(string));
                }
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //读取字段数据,按行读取
            for (int i = 0; i < Layer.Features.Count; i++)
            {
                Table.Rows.Add(Layer.Features.GetItem(i).Attributes.ToArray());
            }
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.LightBlue;
            RefreshDataFormByMainForm();
        }


    public void AddNewField()
    {
        moAttributes attributes = new moAttributes();
        List<object> array = new List<object>();
        for (int i = 0; i < Layer.Features.Count; i++)
            array.Add(0);
        attributes.FromArray(array.ToArray());
        Layer = Main.mapControl.Layers.GetItem(LayerIndex);

        BeginRefresh();//重新加载一下
    }


    /// <summary>
    /// 更新标签
    /// </summary>
    public void RefreshSelectedText()
    {
        lblSelectedNum.Text = (Layer.SelectedFeatures.Count.ToString() + @" / " + Layer.Features.Count.ToString() + @" 已选择");
    }


    public void RefreshDataFormByMainForm()
    {
        for (int i = 0; i < Layer.SelectedFeatures.Count; i++)
        {
            int index = Layer.Features.Find(Layer.SelectedFeatures.GetItem(i));
            dataGridView.Rows[index].Selected = true; //将该序号设置为亮
        }
        RefreshSelectedText();
    }


    public void RefreshMainFormByDataForm()
    {
        Layer.SelectedFeatures.Clear();
        for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
        {
            Layer.SelectedFeatures.Add(Layer.Features.GetItem(dataGridView.SelectedRows[i].HeaderCell.RowIndex));
        }
        Main.mapControl.RedrawTrackingShapes();
        RefreshSelectedText();
    }

    #endregion Methods

    #region 窗体和按钮处理


    private void btnStartEdit_Click(object sender, EventArgs e)
    {
        dataGridView.ReadOnly = false;
        MessageBox.Show(@"双击单元格编辑数据");
    }

    private void btnEndEdit_Click(object sender, EventArgs e)
    {
        dataGridView.ReadOnly = true;
    }


    private void btnDelField_Click(object sender, EventArgs e)
    {
        if (HasSelectField == false)
        {
            MessageBox.Show(@"请选择需要删除的字段");
            return;
        }
        Layer.AttributeFields.RemoveAt(SelectedFieldIndex);

        HasSelectField = false;
        SelectedFieldIndex = -1;

        MessageBox.Show(@"字段已成功删除");
        BeginRefresh();//重新加载一下
    }

    // 单击添加字段
    private void btnAddField_Click(object sender, EventArgs e)
    {

        AddNewField addNewField = new AddNewField(this);
        addNewField.Show();
    }

    // 单击表头，即表示要即将删除某个字段
    private void ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (SelectedFieldIndex == e.ColumnIndex)//初次选择
        {
            return;
        }
        if (SelectedFieldIndex != e.ColumnIndex && SelectedFieldIndex >= 0)
        {
            dataGridView.Columns[SelectedFieldIndex].DefaultCellStyle.BackColor = Color.White;
        }
        dataGridView.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.LightBlue;
        SelectedFieldIndex = e.ColumnIndex;
        HasSelectField = true;
    }

    //用户修改完当前单元格
    private void CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        int col = e.ColumnIndex;//获取被修改单元格的纵坐标
        int row = e.RowIndex;//获取被修改单元格的横坐标
                             
        Layer.Features.GetItem(row).Attributes.SetItem(col, e.Value);
        IsAttributeChanged = true;
        BeginRefresh(); //重新加载一下
    }

    //单击一行的最左边
    private void RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        dataGridView.Rows[e.RowIndex].Selected = true;//表示选中了这一行
        RefreshMainFormByDataForm();
    }

    //用于操作鼠标点选或者拖动要素
    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {

        if (e.ColumnIndex < 0)
        {
            RefreshMainFormByDataForm();
        }
        else
        {
            RefreshDataFormByMainForm();
        }
    }

    //全部选择
    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGridView.Rows.Count; i++)
        {
            dataGridView.Rows[i].Selected = true;
        }
        RefreshMainFormByDataForm();
    }

    //清除选择
    private void btnClearSelect_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Selected = false;
            }
            RefreshMainFormByDataForm();

    }


    #endregion 窗体和按钮处理

    private void AttributeTable_FormClosing(object sender, FormClosingEventArgs e)
    {
        for (int i = 0; i < Main.AttributeTables.Count; i++)
        {
            if (Main.AttributeTables[i].FormIndex == FormIndex)
            {
                Main.AttributeTables.RemoveAt(i);
                break;
            }
        }
    }

        private void btnSelectByAttribute_Click(object sender, EventArgs e)
        {
            SelectByAttribute researchSelect = new SelectByAttribute(Main);
            researchSelect.Owner = this;
            researchSelect.Show();
        }
    }
}