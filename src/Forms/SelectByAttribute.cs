using System;
using System.Data;
using System.Windows.Forms;

namespace GISBox.Forms
{
    public partial class SelectByAttribute : Form
    {
        #region 字段

        public MainForm Main { get; }
        private int _layerSelectIndex;
        private int _fieldSelectIndex;

        private DataTable _dataTable;//数据表


        #endregion

        #region Constructors
        public SelectByAttribute(MainForm main)
        {
            InitializeComponent();
            Main = main;//连通父窗口
            Load_layerselect();//加载图层选择下拉框
            _layerSelectIndex = -1;
            _fieldSelectIndex = -1;
        }

        #endregion

        #region Methods
        //重新加载Layer_SelectBox的内容
        public void Load_layerselect()
        {
            for(int i=0;i<Main.mapControl.Layers.Count;i++)
            {
                Layer_SelectBox.Items.Add(Main.mapControl.Layers.GetItem(i).Name);
                //将图层的名字添加到下拉框里面
            }
        }

        //重新加载字段显示窗口
        //双引号："\""
        //单引号："\'"
        public void Load_fieldslist()
        {
            for(int i=0;i<Main.mapControl.Layers.GetItem(_layerSelectIndex).AttributeFields.Count;i++)
            {
                Fields_List.Items.Add
                    (Main.mapControl.Layers.GetItem(_layerSelectIndex).AttributeFields.GetItem(i).Name);
                //将字段名字添加到下拉框
            }
        }

        //加载数据表
        public void Load_datatable()
        {
            if (_layerSelectIndex < 0)
                return;
            //建表
            _dataTable = new DataTable();
            //做一个中间值便于表示
            MyMapObjects.moMapLayer layerTemp = Main.mapControl.Layers.GetItem(_layerSelectIndex);
            //建立字段
            for (int i = 0; i < layerTemp.AttributeFields.Count; i++)
            {
                if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dDouble)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(double));
                }
                else if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt16)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(short));
                }
                else if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt32)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(int));
                }
                else if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dInt64)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(long));
                }
                else if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dSingle)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(float));
                }
                else if (layerTemp.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dText)
                {
                    _dataTable.Columns.Add(layerTemp.AttributeFields.GetItem(i).Name, typeof(string));
                }
            }
            //读取字段数据,按行读取
            for (int i = 0; i < layerTemp.Features.Count; i++)
            {
                _dataTable.Rows.Add(layerTemp.Features.GetItem(i).Attributes.ToArray());
            }

        }
        #endregion

        #region 符号按钮

        private void Research_Load(object sender, EventArgs e)
        {

        }
        //=
        private void button1_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("=" + " ");
        }
        //<>
        private void button4_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("<>" + " ");
        }
        //Like
        private void button5_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("Like" + " ");
        }
        //>
        private void button2_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText(">" + " ");
        }
        //>=
        private void button6_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText(">=" + " ");
        }
        //And
        private void button8_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("And" + " ");
        }
        //<
        private void button3_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("<" + " ");
        }
        //<=
        private void button7_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("<=" + " ");
        }
        //Or
        private void button9_Click(object sender, EventArgs e)
        {
            SQL_text.AppendText("Or" + " ");
        }
        
        #endregion

        #region 操作按钮
        //选中某个图层后
        private void Layer_SelectBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _layerSelectIndex = Layer_SelectBox.SelectedIndex;//获取选中的图层的索引
            UniqueValues.Items.Clear();//重新选择了图层必然唯一值框要清零
            Fields_List.Items.Clear();//清零字段显示图层
            Load_fieldslist();//重新加载下拉框
            Load_datatable();//重新建立数据表
            _fieldSelectIndex = -1;//同时重新清零上次选中的字段
        }

        //选中某个字段后
        private void Fields_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            //暂时无用
        }

        //单击Fields_List时，单击一下选中，单击第二下将字体投到下方输入框
        private void Fields_List_MouseClick(object sender, MouseEventArgs e)
        {
            int index = Fields_List.IndexFromPoint(e.Location);//获取index
            if (index == ListBox.NoMatches)
                return;
            if(index==_fieldSelectIndex)
            {
                //如果是第二次选中了，就把名字添加到下面的文本框
                SQL_text.AppendText(Main.mapControl.Layers.GetItem(_layerSelectIndex).AttributeFields.GetItem(_fieldSelectIndex).Name + " ");
            }
            else
            {
                //第一次点就普普通通即可
                _fieldSelectIndex = index;//选中这个条目
            }
            Fields_List.SelectedIndex = index;//选中这个条目
        }
        //双击Fields_List时，直接将文本投入下面框
        private void Fields_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = Fields_List.IndexFromPoint(e.Location);//获取index
            if (index == ListBox.NoMatches)
                return;
            SQL_text.AppendText(Main.mapControl.Layers.GetItem(_layerSelectIndex).AttributeFields.GetItem(_fieldSelectIndex).Name + " ");
            _fieldSelectIndex = index;//选中这个条目
            Fields_List.SelectedIndex = index;//选中这个条目
        }
        //双击唯一值时，直接将文本投入下面框
        private void UniqueValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = UniqueValues.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
                return;
            UniqueValues.SelectedIndex = index;//选中这个条目
            SQL_text.AppendText(UniqueValues.Items[index]+" ");
        }

        //唯一值
        private void button17_Click(object sender, EventArgs e)
        {
            if (_fieldSelectIndex < 0)
                return;//如果没有选择字段，就return
            UniqueValues.Items.Clear();
            MyMapObjects.moMapLayer layerTemp = Main.mapControl.Layers.GetItem(_layerSelectIndex);
            for (int i=0;i < layerTemp.Features.Count;i++)
            {
                if(layerTemp.AttributeFields.GetItem(_fieldSelectIndex).ValueType==MyMapObjects.moValueTypeConstant.dText)
                {
                    UniqueValues.Items.Add("\'" + layerTemp.Features.GetItem(i).Attributes.GetItem(_fieldSelectIndex) + "\'");
                }
                else 
                {
                    UniqueValues.Items.Add(layerTemp.Features.GetItem(i).Attributes.GetItem(_fieldSelectIndex).ToString());
                }
            }
            for (int i = 0; i < UniqueValues.Items.Count; i++)
            {
                for (int j = i + 1; j < UniqueValues.Items.Count; j++)
                {
                    if (UniqueValues.Items[i].Equals(UniqueValues.Items[j]))
                    {
                        UniqueValues.Items.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
        //验证
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                _dataTable.Select(SQL_text.Text);
                MessageBox.Show(@"语句合法，验证成功");
            }
            catch
            {
                MessageBox.Show(@"非法语句，请重新输入");
            }
        }
        //确定
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dataRows = _dataTable.Select(SQL_text.Text);
                Main.mapControl.Layers.GetItem(_layerSelectIndex).SelectedFeatures.Clear();//清除被选中数据
                if (dataRows.Length > 0)
                {
                    for (int i = 0; i < dataRows.Length; i++)
                    {
                        Main.mapControl.Layers.GetItem(_layerSelectIndex).SelectedFeatures.Add(
                            Main.mapControl.Layers.GetItem(_layerSelectIndex).Features.GetItem(_dataTable.Rows.IndexOf(dataRows[i])));//更新被选中数据
                    }
                    //重新绘制要素图层
                    Main.mapControl.RedrawTrackingShapes();
                    //这里要有一句代码，更新属性表
                    Main.RedrawAttribute();
                }
                else
                    MessageBox.Show(@"未查询到符合条件要素");
                Close();
            }
            catch
            {
                MessageBox.Show(@"非法语句，请重新输入");
            }
        }
        //应用
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dataRows = _dataTable.Select(SQL_text.Text);
                Main.mapControl.Layers.GetItem(_layerSelectIndex).SelectedFeatures.Clear();//清除被选中数据
                if (dataRows.Length > 0)
                {
                    for (int i = 0; i < dataRows.Length; i++)
                    {
                        Main.mapControl.Layers.GetItem(_layerSelectIndex).SelectedFeatures.Add(
                            Main.mapControl.Layers.GetItem(_layerSelectIndex).Features.GetItem(_dataTable.Rows.IndexOf(dataRows[i])));//更新被选中数据
                    }
                    //重新绘制要素图层
                    Main.mapControl.RedrawTrackingShapes();
                    Main.RedrawAttribute();
                }
                else
                    MessageBox.Show(@"未查询到符合条件要素");
            }
            catch
            {
                MessageBox.Show(@"非法语句，请重新输入");
            }
        }


        #endregion

        //清空函数
        private void button23_Click(object sender, EventArgs e)
        {
            SQL_text.Clear();
        }
    }
}
