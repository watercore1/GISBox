using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MyMapObjects;

namespace GISBox
{
    public partial class MainForm : Form
    {
        #region 字段
        //(1)选项变量
        
        //(2)地图操作
        private MapOpStyle _mapOpStyle = MapOpStyle.None;   //地图操作方式

        private int _selectedLayerIndex;    //选中的图层索引
        //(3)文件管理
        public List<ShxShpFileProcessor> ShxShpFiles { get; } = new List<ShxShpFileProcessor>();
        public List<DbfFileProcessor> DbfFiles { get; } = new List<DbfFileProcessor>();

        #endregion

        #region 构造函数

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体和控件事件处理

        private void openFileMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = @"ShapeFile 文件|*.shp";
            string shpFilePath;
            //如果打开成功
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                shpFilePath = fileDialog.FileName;
                fileDialog.Dispose();
            }
            else
            {
                fileDialog.Dispose();
                return;
            }

            try
            {
                //图层名字
                string layerPath = Path.GetFileNameWithoutExtension(shpFilePath);
                string dbfFilePath = layerPath + ".dbf";
                //(1) 读取文件
                ShxShpFileProcessor shxShpFile = new ShxShpFileProcessor(shpFilePath);
                DbfFileProcessor dbfFile = new DbfFileProcessor(dbfFilePath, true);
                //(2) 设置主字段
                for (int i = 0; i < dbfFile.MapFields.Count; i++)
                {
                    if (dbfFile.MapFields.GetItem(i).Name == "id" && dbfFile.MapFields.GetItem(i).ValueType ==
                        MyMapObjects.moValueTypeConstant.dInt32)
                    {
                        dbfFile.MapFields.PrimaryField = "id";
                    }
                    else
                    {
                        dbfFile.MapFields.PrimaryField = dbfFile.MapFields.GetItem(1).Name;
                    }
                }

                //(3)新建图层装载数据并加载图层
                MyMapObjects.moMapLayer mapLayer =
                    new MyMapObjects.moMapLayer(layerPath, shxShpFile.GeometryType, dbfFile.MapFields);
                MyMapObjects.moFeatures features = new MyMapObjects.moFeatures();
                for (int i = 0; i < shxShpFile.Geometries.Count; ++i)
                {
                    MyMapObjects.moFeature feature = new MyMapObjects.moFeature(shxShpFile.GeometryType,
                        shxShpFile.Geometries[i], dbfFile.MapAttributesList[i]);
                    features.Add(feature);
                }

                mapLayer.Features = features;
                AddLayerToMap(mapLayer, shxShpFile, dbfFile);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
        }

        #endregion

        #region 地图事件处理

        #endregion

        #region 私有函数

        /// <summary>
        /// 将图层添加到地图中进行渲染
        /// 并管理对应的文件数据
        /// </summary>
        /// <param name="mapLayer">新图层</param>
        /// <param name="shxShpFile">要素地理文件数据</param>
        /// <param name="dbfFile">要素属性文件数据</param>
        private void AddLayerToMap(moMapLayer mapLayer, ShxShpFileProcessor shxShpFile,
            DbfFileProcessor dbfFile)
        {
            int index = GetInsertIndex(mapLayer.ShapeType);
            _selectedLayerIndex = index;
            mapControl.Layers.Insert(index, mapLayer);
            ShxShpFiles.Insert(index, shxShpFile); //添加至要素地理文件管理列表
            DbfFiles.Insert(index, dbfFile);       //添加至要素属性文件管理列表
            RefreshLayersTree(); //刷新图层列表
            if (mapControl.Layers.Count == 1)
            {
                mapControl.FullExtent();
            }
            else
            {
                mapControl.RedrawMap();
            }
        }

        /// <summary>
        /// 新加入图层时，根据图层的类型确定插入的位置
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private int GetInsertIndex(MyMapObjects.moGeometryTypeConstant shapeType)
        {
            int index = 0;
            for (; index < mapControl.Layers.Count; index++)
            {
                if (shapeType < mapControl.Layers.GetItem(index).ShapeType)
                {
                    return index;
                }
            }

            return index;
        }

        /// <summary>
        /// 刷新图层列表
        /// </summary>
        private void RefreshLayersTree()
        {
            layersTreeView.Nodes.Clear();
            for (Int32 i = 0; i < mapControl.Layers.Count; i++)
            {
                TreeNode layerNode = new TreeNode
                {
                    Text = mapControl.Layers.GetItem(i).Name,
                    Checked = mapControl.Layers.GetItem(i).Visible,
                    ContextMenuStrip = layerRightMenu
                };
                layersTreeView.Nodes.Add(layerNode);
            }
            layersTreeView.Refresh();
            _mapOpStyle = MapOpStyle.None;
            layersTreeView.Nodes[_selectedLayerIndex].BackColor = Color.LightGray;
        }

        #endregion
    }
}