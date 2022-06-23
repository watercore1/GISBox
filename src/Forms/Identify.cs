using System;
using System.Data;
using System.Windows.Forms;

namespace GISBox.Forms
{
    public partial class Identify : Form
    {
        private DataTable dataTable_select;//选中数据的数据表
        private MyMapObjects.moMapLayer mLayer;
        private MyMapObjects.moFeatures mFeatures;
        
        public Identify(MyMapObjects.moMapLayer layer, MyMapObjects.moFeatures features)
        {

            InitializeComponent();
            mLayer = layer;
            mFeatures = features;
            lblLayerName.Text = mLayer.Name;
            for (int i = 0; i < mFeatures.Count; i++)
            {
                MyMapObjects.moFeature sFeature = mFeatures.GetItem(i);
                MyMapObjects.moAttributes curAttributes = sFeature.Attributes;
                treeView.Nodes.Add(Convert.ToString(curAttributes.GetItem(0)));
            }
            treeView.Nodes[0].Expand();
            ShowTable(0);
        }

        private void ShowTable(int nodeIndex)
        {
            int sFieldCount = mLayer.AttributeFields.Count;
            dataTable_select = new DataTable();
            table.DataSource = null;
            table.DataSource = dataTable_select;
            dataTable_select.Columns.Add("字段", typeof(string));
            dataTable_select.Columns.Add("值", typeof(string));
            if (nodeIndex < mFeatures.Count)
            {
                for (int i = 0; i < sFieldCount; i++)
                {
                    dataTable_select.Rows.Add(mLayer.AttributeFields.GetItem(i).Name, Convert.ToString(mFeatures.GetItem(nodeIndex).Attributes.GetItem(i)));
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = e.Node.Index;
            ShowTable(index);
        }
    }
}