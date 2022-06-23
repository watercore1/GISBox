using GISBox.MapVariable;
using GISBox.Properties;
using GISBox.ShapeFile;
using GISBox.Forms;
using MyMapObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GISBox
{
    public partial class MainForm : Form
    {
        #region Properties

        // variable about setting
        private SettingVariable _setting;

        // variable about map operation
        private OperationVariable _operation;

        // variable about render
        internal RenderVariable Render;

        // variable about label
        internal LabelVariable Label;

        // Attribute Data
        public List<AttributeTable> AttributeTables { get; set; }
        public static int AttributeTableIndex;

        public moGeometryTypeConstant EditingLayerShape
        {
            get
            {
                if (_operation.EditedLayerIndex == -1)
                {
                    return moGeometryTypeConstant.None;
                }

                return mapControl.Layers.GetItem(_operation.EditedLayerIndex).ShapeType;
            }
        }

        #endregion Properties

        #region Constructors

        public MainForm()
        {
            InitializeProperty();
            InitializeComponent();
        }

        #endregion Constructors

        #region Forms and controls event handling

        // (1) menu

        /// <summary>
        /// open ShapeFile and add to layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            string shpFilePath;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = @"ShapeFile 文件|*.shp";
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
                string layerName = Path.GetFileNameWithoutExtension(shpFilePath);
                string layerPath = shpFilePath.Substring(0, shpFilePath.IndexOf(".shp", StringComparison.Ordinal));

                ShapeFileProcessor fileProcessor = new ShapeFileProcessor(layerPath);

                // convert to mapLayer
                moMapLayer mapLayer =
                    new moMapLayer(layerName, layerPath, fileProcessor.GeometryType, fileProcessor.Fields);

                // construct features, using geometries and attributes list
                moFeatures features = new moFeatures();
                for (int i = 0; i < fileProcessor.Geometries.Count; ++i)
                {
                    moFeature feature = new moFeature(fileProcessor.GeometryType,
                        fileProcessor.Geometries[i], fileProcessor.AttributesList[i]);
                    features.Add(feature);
                }

                mapLayer.Features = features;
                AddLayerToMap(mapLayer);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void createNewLayerMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewLayer newLayer = new CreateNewLayer();
            newLayer.Owner = this;
            newLayer.ShowDialog();
        }

        private void outputImageMenuItem_Click(object sender, EventArgs e)
        {
            if (mapControl.Layers.Count == 0) MessageBox.Show(@"未导入图层");
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.OverwritePrompt = true;
                saveFile.RestoreDirectory = true;
                saveFile.Title = @"保存 BMP 图片";
                saveFile.Filter = @"BMP 文件(*.bmp)|*.bmp";
                if (saveFile.ShowDialog() != DialogResult.OK) return;
                string fileName = saveFile.FileName;
                mapControl.BmpMap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        // (2) tool strip

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            _operation.MapStyle = MapOpStyle.ZoomIn;
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            _operation.MapStyle = MapOpStyle.ZoomOut;
        }

        private void panButton_Click(object sender, EventArgs e)
        {
            _operation.MapStyle = MapOpStyle.Pan;
        }

        private void fullExtentButton_Click(object sender, EventArgs e)
        {
            mapControl.FullExtent();
        }

        private void selectLocationButton_Click(object sender, EventArgs e)
        {
            if (_operation.SelectedLayerIndex == -1)
            {
                MessageBox.Show(@"请先选中图层，再编辑图层");
                return;
            }

            _operation.MapStyle = MapOpStyle.Select;
        }

        private void selectAttributeButton_Click(object sender, EventArgs e)
        {
            SelectByAttribute researchSelect = new SelectByAttribute(this);
            researchSelect.Owner = this;

            researchSelect.Show();
        }

        private void cleanSelectedButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapControl.Layers.Count; i++)
            {
                moMapLayer sLayer = mapControl.Layers.GetItem(i);
                sLayer.SelectedFeatures.Clear();
            }
            mapControl.RedrawMap();
        }

        private void identifyButton_Click(object sender, EventArgs e)
        {
            _operation.MapStyle = MapOpStyle.Identify;
        }

        private void editDropDownButton_Click(object sender, EventArgs e)
        {
            if (_operation.SelectedLayerIndex != -1)
                startEditMenuItem.Enabled = true;
        }

        private void startEditMenuItem_Click(object sender, EventArgs e)
        {
            _operation.EditedLayerIndex = _operation.SelectedLayerIndex;
            startEditMenuItem.Enabled = true;
            endEditMenuItem.Enabled = true;
            moveFeatureButton.Enabled = true;
            moveNodeButton.Enabled = true;
            if (EditingLayerShape != moGeometryTypeConstant.Point)
            {
                addNodeButton.Enabled = true;
                delNodeButton.Enabled = true;
            }
            createFeatureButton.Enabled = true;
            moveFeatureButton_Click(sender, e);
        }

        private void endEditMenuItem_Click(object sender, EventArgs e)
        {
            SaveNodeEdit();

            if (_operation.IsLayerChanged)
            {
                DialogResult dr = MessageBox.Show(@"是否保存编辑内容", @"保存", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            SaveEdit();
                            break;
                        }
                    case DialogResult.No:
                        {
                            CancelEdit();
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return;
                        }

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            startEditMenuItem.Enabled = true;
            endEditMenuItem.Enabled = false;
            moveFeatureButton.Enabled = false;
            moveNodeButton.Enabled = false;
            addNodeButton.Enabled = false;
            delNodeButton.Enabled = false;

            // clear the operation variable
            _operation.EndEditLayer();

            for (int i = 0; i < mapControl.Layers.Count; i++)
            {
                mapControl.Layers.GetItem(i).SelectedFeatures.Clear();
                mapControl.Layers.GetItem(i).SelectIndex.Clear();
            }

            mapControl.RedrawMap();
        }

        private void moveFeatureButton_Click(object sender, EventArgs e)
        {
            SaveNodeEdit();
            moveFeatureButton.Checked = true;
            moveNodeButton.Checked = false;
            addNodeButton.Checked = false;
            delNodeButton.Checked = false;
            createFeatureButton.Checked = false;
            _operation.MapStyle = MapOpStyle.SelectAndMoveFeature;
            mapControl.ContextMenuStrip = moveFeatureRightMenu;
        }

        private void moveNodeButton_Click(object sender, EventArgs e)
        {
            if (!GetEditGeometrySuccessfully()) return;
            moveFeatureButton.Checked = false;
            moveNodeButton.Checked = true;
            addNodeButton.Checked = false;
            delNodeButton.Checked = false;
            createFeatureButton.Checked = false;
            _operation.MapStyle = MapOpStyle.MoveNode;
            mapControl.ContextMenuStrip = null;
        }

        private void addNodeButton_Click(object sender, EventArgs e)
        {
            if (!GetEditGeometrySuccessfully()) return;
            moveFeatureButton.Checked = false;
            moveNodeButton.Checked = false;
            addNodeButton.Checked = true;
            delNodeButton.Checked = false;
            createFeatureButton.Checked = false;
            _operation.MapStyle = MapOpStyle.AddNode;
            mapControl.ContextMenuStrip = null;
        }

        private void delNodeButton_Click(object sender, EventArgs e)
        {
            if (!GetEditGeometrySuccessfully()) return;
            moveFeatureButton.Checked = false;
            moveNodeButton.Checked = false;
            addNodeButton.Checked = false;
            delNodeButton.Checked = true;
            createFeatureButton.Checked = false;
            _operation.MapStyle = MapOpStyle.DelNode;
            mapControl.ContextMenuStrip = null;
        }

        private void createFeatureButton_Click(object sender, EventArgs e)
        {
            SaveNodeEdit();
            moveFeatureButton.Checked = false;
            moveNodeButton.Checked = false;
            addNodeButton.Checked = false;
            delNodeButton.Checked = false;
            createFeatureButton.Checked = true;
            _operation.MapStyle = MapOpStyle.Create;
            mapControl.ContextMenuStrip = createFeatureRightMenu;
        }

        private void layersTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (layersTreeView.Nodes.Count <= 1) //结点数量少于2
            {
                return;
            }
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点
            int sIndex1 = moveNode.Index;
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            //寻找目标结点号
            int sIndex2 = 0;
            int sNodesNum = layersTreeView.Nodes.Count;
            Rectangle sFirstRect = layersTreeView.Nodes[0].Bounds;
            Rectangle sLastRect = layersTreeView.Nodes[sNodesNum - 1].Bounds;
            if (pt.Y <= sFirstRect.Y)
            {
                sIndex2 = 0;
            }
            else if (pt.Y >= (sLastRect.Y + sLastRect.Height))
            {
                sIndex2 = sNodesNum - 1;
            }
            else
            {
                for (int i = 0; i < sNodesNum; ++i)
                {
                    Rectangle sCurRect = layersTreeView.Nodes[i].Bounds;
                    if ((pt.Y > sCurRect.Y) && (pt.Y <= (sCurRect.Y + sCurRect.Height)))
                    {
                        sIndex2 = i;
                        break;
                    }
                }
            }
            if (sIndex1 == sIndex2) //没有交换顺序
            {
                return;
            }
            moMapLayer sMapLayer1 = mapControl.Layers.GetItem(sIndex1);
            moMapLayer sMapLayer2 = mapControl.Layers.GetItem(sIndex2);
            mapControl.Layers.RemoveAt(sIndex1);
            mapControl.Layers.Insert(sIndex1, sMapLayer2);
            mapControl.Layers.RemoveAt(sIndex2);
            mapControl.Layers.Insert(sIndex2, sMapLayer1);

            RefreshLayersTree();    //刷新图层列表
            mapControl.RedrawMap();  //刷新地图
        }

        private void layersTreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent("System.Windows.Forms.TreeNode") ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void layersTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void layersTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int sIndex = e.Node.Index;
            moMapLayer sMapLayer = mapControl.Layers.GetItem(sIndex);
            sMapLayer.Visible = e.Node.Checked;
            if (e.Node.Index == _operation.EditedLayerIndex)
            {
                endEditMenuItem_Click(sender, e);
            }
            mapControl.RedrawMap();
        }

        private void layersTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            foreach (TreeNode n in layersTreeView.Nodes)
            {
                n.BackColor = Color.Empty;
            }
            _operation.SelectedLayerIndex = e.Node.Index;
            e.Node.BackColor = Color.LightGray;
        }

        private void layersTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            Point clickPoint = new Point(e.X, e.Y);
            TreeNode currentNode = layersTreeView.GetNodeAt(clickPoint);
            if (currentNode != null)
            {
                layersTreeView.SelectedNode = currentNode;
                _operation.SelectedLayerIndex = currentNode.Index;
            }
        }

        private void btnScale1000000_Click(object sender, EventArgs e)
        {
            moPoint point = mapControl.ToMapPoint(mapControl.Width / 2.0, mapControl.Height / 2.0);
            double zoomRatio = mapControl.MapScale / 1000000.0;
            mapControl.ZoomByCenter(point, zoomRatio);
        }

        private void btnScale5000000_Click(object sender, EventArgs e)
        {
            moPoint point = mapControl.ToMapPoint(mapControl.Width / 2.0, mapControl.Height / 2.0);
            double zoomRatio = mapControl.MapScale / 5000000.0;
            mapControl.ZoomByCenter(point, zoomRatio);
        }

        private void btnScale10000000_Click(object sender, EventArgs e)
        {
            moPoint point = mapControl.ToMapPoint(mapControl.Width / 2.0, mapControl.Height / 2.0);
            double zoomRatio = mapControl.MapScale / 10000000.0;
            mapControl.ZoomByCenter(point, zoomRatio);
        }

        private void btnScale20000000_Click(object sender, EventArgs e)
        {
            moPoint point = mapControl.ToMapPoint(mapControl.Width / 2.0, mapControl.Height / 2.0);
            double zoomRatio = mapControl.MapScale / 20000000.0;
            mapControl.ZoomByCenter(point, zoomRatio);
        }

        private void extentToLayerMenuItem_Click(object sender, EventArgs e)
        {
            moMapLayer sLayer = mapControl.Layers.GetItem(_operation.SelectedLayerIndex);
            sLayer.UpdateExtent();
            moRectangle sRect = sLayer.Extent;
            mapControl.SetExtent(sRect);
        }

        private void upOneMenuItem_Click(object sender, EventArgs e)
        {
            int upIndex = _operation.SelectedLayerIndex;
            if (upIndex == 0) return;

            moMapLayer sLayer = mapControl.Layers.GetItem(upIndex);
            mapControl.Layers.RemoveAt(upIndex);
            mapControl.Layers.Insert(upIndex - 1, sLayer);
            RefreshLayersTree();    //刷新图层列表
            mapControl.RedrawMap();  //刷新地图
        }

        private void downOneMenuItem_Click(object sender, EventArgs e)
        {
            int downIndex = _operation.SelectedLayerIndex;
            if (downIndex == mapControl.Layers.Count - 1) return;

            moMapLayer sLayer = mapControl.Layers.GetItem(downIndex);
            mapControl.Layers.RemoveAt(downIndex);
            mapControl.Layers.Insert(downIndex + 1, sLayer);
            RefreshLayersTree();    //刷新图层列表
            mapControl.RedrawMap();  //刷新地图
        }

        private void upTopMenuItem_Click(object sender, EventArgs e)
        {
            int upIndex = _operation.SelectedLayerIndex;
            if (upIndex == 0) return;

            moMapLayer sLayer = mapControl.Layers.GetItem(upIndex);
            mapControl.Layers.RemoveAt(upIndex);
            mapControl.Layers.Insert(0, sLayer);
            RefreshLayersTree();    //刷新图层列表
            mapControl.RedrawMap();  //刷新地图
        }

        private void downBottomMenuItem_Click(object sender, EventArgs e)
        {
            int downIndex = _operation.SelectedLayerIndex;
            if (downIndex == mapControl.Layers.Count - 1) return;
            moMapLayer sLayer = mapControl.Layers.GetItem(downIndex);
            mapControl.Layers.RemoveAt(downIndex);
            mapControl.Layers.Insert(mapControl.Layers.Count, sLayer);
            RefreshLayersTree();    //刷新图层列表
            mapControl.RedrawMap();  //刷新地图
        }

        private void openAttributesListMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attributeTable = new AttributeTable(this, _operation.SelectedLayerIndex);
            attributeTable.Owner = this;
            attributeTable.Name = mapControl.Layers.GetItem(_operation.SelectedLayerIndex).Name;
            attributeTable.Show();
            attributeTable.SetDesktopLocation(Location.X + (Width - attributeTable.Width) / 2,
                Location.Y + (Height - attributeTable.Height) / 2);
            attributeTable.RefreshDataFormByMainForm();
            AttributeTables.Add(attributeTable);//将新打开的添加进去
            attributeTable.FormIndex = AttributeTableIndex;
            AttributeTableIndex++;
        }

        private void renderMenuItem_Click(object sender, EventArgs e)
        {
            Render.mIsInRenderer = false;
            moMapLayer sLayer = mapControl.Layers.GetItem(_operation.SelectedLayerIndex);//待渲染的图层
            if (sLayer.ShapeType == moGeometryTypeConstant.Point)
            {
                PointRenderer mPointRenderer = new PointRenderer(mapControl.Layers.GetItem(_operation.SelectedLayerIndex));
                mPointRenderer.Owner = this;
                mPointRenderer.ShowDialog();
                if (Render.mIsInRenderer == false)
                {
                    return;
                }
                //简单渲染
                if (Render.mPointRendererMode == 0)
                {
                    moSimpleRenderer sRenderer = new moSimpleRenderer();
                    moSimpleMarkerSymbol sSymbol = new moSimpleMarkerSymbol();
                    sSymbol.Style = (moSimpleMarkerSymbolStyleConstant)Render.mPointSymbolStyle;//修改样式
                    sSymbol.Color = Render.mPointSimpleRendererColor;//修改颜色
                    sSymbol.Size = Render.mPointSimpleRendererSize;//修改尺寸
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //唯一值渲染
                else if (Render.mPointRendererMode == 1)
                {
                    moUniqueValueRenderer sRenderer = new moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPointUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++) //加入所有要素的属性值
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(Render.mPointUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i < sValueCount; i++)
                    {
                        moSimpleMarkerSymbol sSymbol = new moSimpleMarkerSymbol();
                        sSymbol.Style = (moSimpleMarkerSymbolStyleConstant)Render.mPointSymbolStyle;//修改样式
                        sSymbol.Size = Render.mPointSimpleRendererSize;//修改尺寸
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new moSimpleMarkerSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //分级渲染
                else if (Render.mPointRendererMode == 2)
                {
                    moClassBreaksRenderer sRenderer = new moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPointClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndex = sLayer.AttributeFields.FindField(sRenderer.Field);
                    moValueTypeConstant sValueType = sLayer.AttributeFields.GetItem(sFieldIndex).ValueType;
                    if (sValueType == moValueTypeConstant.dText)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < Render.mPointClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / Render.mPointClassBreaksNum;
                        moSimpleMarkerSymbol sSymbol = new moSimpleMarkerSymbol();
                        sSymbol.Color = Render.mPointClassBreaksRendererColor;
                        sSymbol.Style = (moSimpleMarkerSymbolStyleConstant)Render.mPointSymbolStyle;
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    double sMinSize = Render.mPointClassBreaksRendererMinSize;
                    double sMaxSize = Render.mPointClassBreaksRendererMaxSize;
                    sRenderer.RampSize(sMinSize, sMaxSize);
                    sRenderer.DefaultSymbol = new moSimpleMarkerSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
            }
            else if (sLayer.ShapeType == moGeometryTypeConstant.MultiPolyline)
            {
                PolylineRenderer mPolylineRenderer = new PolylineRenderer(mapControl.Layers.GetItem(_operation.SelectedLayerIndex));
                mPolylineRenderer.Owner = this;
                mPolylineRenderer.ShowDialog();
                if (Render.mIsInRenderer == false)
                {
                    return;
                }
                //简单渲染
                if (Render.mPolylineRendererMode == 0)
                {
                    moSimpleRenderer sRenderer = new moSimpleRenderer();
                    moSimpleLineSymbol sSymbol = new moSimpleLineSymbol();
                    sSymbol.Style = (moSimpleLineSymbolStyleConstant)Render.mPolylineSymbolStyle;//传参修改
                    sSymbol.Color = Render.mPolylineSimpleRendererColor;//修改颜色
                    sSymbol.Size = Render.mPolylineSimpleRendererSize;//修改尺寸
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //唯一值渲染
                else if (Render.mPolylineRendererMode == 1)
                {
                    moUniqueValueRenderer sRenderer = new moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPolylineUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++)
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(Render.mPolylineUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i < sValueCount; i++)
                    {
                        moSimpleLineSymbol sSymbol = new moSimpleLineSymbol();
                        sSymbol.Style = (moSimpleLineSymbolStyleConstant)Render.mPolylineSymbolStyle;//修改样式
                        sSymbol.Size = Render.mPolylineUniqueRendererSize;//修改尺寸
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new moSimpleLineSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //分级渲染
                else if (Render.mPolylineRendererMode == 2)
                {
                    moClassBreaksRenderer sRenderer = new moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPolylineClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndex = sLayer.AttributeFields.FindField(sRenderer.Field);
                    moValueTypeConstant sValueType = sLayer.AttributeFields.GetItem(sFieldIndex).ValueType;
                    if (sValueType == moValueTypeConstant.dText)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }

                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < Render.mPolylineClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / Render.mPolylineClassBreaksNum;
                        moSimpleLineSymbol sSymbol = new moSimpleLineSymbol();
                        sSymbol.Color = Render.mPolylineClassBreaksRendererColor;
                        sSymbol.Style = (moSimpleLineSymbolStyleConstant)Render.mPolylineSymbolStyle;
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    double sMinSize = Render.mPolylineClassBreaksRendererMinSize;
                    double sMaxSize = Render.mPolylineClassBreaksRendererMaxSize;
                    sRenderer.RampSize(sMinSize, sMaxSize);
                    sRenderer.DefaultSymbol = new moSimpleLineSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
            }
            else if (sLayer.ShapeType == moGeometryTypeConstant.MultiPolygon)
            {
                PolygonRenderer mPolygonRenderer = new PolygonRenderer(mapControl.Layers.GetItem(_operation.SelectedLayerIndex));
                mPolygonRenderer.Owner = this;
                mPolygonRenderer.ShowDialog();
                if (Render.mIsInRenderer == false)
                {
                    return;
                }
                //简单渲染
                if (Render.mPolygonRendererMode == 0)
                {
                    moSimpleRenderer sRenderer = new moSimpleRenderer();
                    moSimpleFillSymbol sSymbol = new moSimpleFillSymbol();
                    sSymbol.Color = Render.mPolygonSimpleRendererColor;
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //唯一值渲染
                else if (Render.mPolygonRendererMode == 1)
                {
                    moUniqueValueRenderer sRenderer = new moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPolygonUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++)
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(Render.mPolygonUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i <= sValueCount - 1; i++)
                    {
                        moSimpleFillSymbol sSymbol = new moSimpleFillSymbol();
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new moSimpleFillSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
                //分级渲染
                else if (Render.mPolygonRendererMode == 2)
                {
                    moClassBreaksRenderer sRenderer = new moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(Render.mPolygonClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndex = sLayer.AttributeFields.FindField(sRenderer.Field);
                    moValueTypeConstant sValueType = sLayer.AttributeFields.GetItem(sFieldIndex).ValueType;
                    if (sValueType == moValueTypeConstant.dText)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    //获取最小最大值并分5级
                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < Render.mPolygonClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / Render.mPolygonClassBreaksNum;
                        moSimpleFillSymbol sSymbol = new moSimpleFillSymbol();
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    Color sStartColor = Render.mPolygonClassBreaksRendererStartColor;
                    Color sEndColor = Render.mPolygonClassBreaksRendererEndColor;
                    sRenderer.RampColor(sStartColor, sEndColor);
                    sRenderer.DefaultSymbol = new moSimpleFillSymbol();
                    sLayer.Renderer = sRenderer;
                    mapControl.RedrawMap();
                }
            }
        }

        private void annotationMenuItem_Click(object sender, EventArgs e)
        {
            moMapLayer sLayer = mapControl.Layers.GetItem(_operation.SelectedLayerIndex);//待显示注记的图层
            LabelForm mLabelForm = new LabelForm(sLayer);
            mLabelForm.Owner = this;
            mLabelForm.ShowDialog();
            moLabelRenderer sLabelRenderer = new moLabelRenderer();
            sLabelRenderer.Field = sLayer.AttributeFields.GetItem(Label.mLabelFieldIndex).Name;
            sLabelRenderer.TextSymbol.Font = Label.mLabelFont;
            sLabelRenderer.TextSymbol.FontColor = Label.mLabelColor;
            sLabelRenderer.TextSymbol.UseMask = Label.mLabelUseMask;
            sLabelRenderer.LabelFeatures = Label.mLabelVisible;
            sLayer.LabelRenderer = sLabelRenderer;
            mapControl.RedrawMap();
        }

        private void delLayerMenuItem_Click(object sender, EventArgs e)
        {
            if (_operation.EditedLayerIndex == _operation.SelectedLayerIndex)
            {
                endEditMenuItem_Click(sender, e);
            }
            mapControl.Layers.RemoveAt(_operation.SelectedLayerIndex);
            _operation.SelectedLayerIndex = -1;
            RefreshLayersTree();
            mapControl.RedrawMap();
        }

        private void finishDrawPartMenuItem_Click(object sender, EventArgs e)
        {
            EndCreatePart();
        }

        private void finishDrawFeatureMenuItem_Click(object sender, EventArgs e)
        {
            EndCreateFeature();
        }

        private void delFeatureMenuItem_Click(object sender, EventArgs e)
        {
            _operation.IsLayerChanged = true;
            mapControl.Layers.GetItem(_operation.SelectedLayerIndex).RemoveSelection();
            mapControl.RedrawMap();
        }



        #endregion Forms and controls event handling

        #region Map event handling

        private void MapControl_MapScaleChanged(object sender)
        {
            mapScaleSplitButton.Text = @"1 : " + mapControl.MapScale.ToString("0.00");
        }

        private void MapControl_AfterTrackingLayerDraw(object sender, moUserDrawingTool drawingTool)
        {
            // draw creating feature
            DrawCreatingFeature(drawingTool);

            // draw editing feature
            DrawEditingNodeFeature(drawingTool);
        }

        private void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            switch (_operation.MapStyle)
            {
                case MapOpStyle.AddNode:
                    {
                        AddNode_MouseClick(e);
                        break;
                    }
                case MapOpStyle.DelNode:
                    {
                        DelNode_MouseClick(e);
                        break;
                    }
                case MapOpStyle.Create:
                    {
                        CreateFeature_MouseClick(e);
                        break;
                    }
            }
        }

        private void mapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_operation.MapStyle == MapOpStyle.Create)
            {
                CreateFeature_MouseDoubleClick();
            }
        }

        private void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            switch (_operation.MapStyle)
            {
                case MapOpStyle.ZoomIn:
                    {
                        ZoomIn_MouseDown(e);
                        break;
                    }
                case MapOpStyle.ZoomOut:
                    {
                        ZoomOut_MouseDown(e);
                        break;
                    }
                case MapOpStyle.Pan:
                    {
                        Pan_MouseDown(e);
                        break;
                    }
                case MapOpStyle.Select:
                    {
                        Select_MouseDown(e);
                        break;
                    }
                case MapOpStyle.Identify:
                    {
                        Identify_MouseDown(e);
                        break;
                    }
                case MapOpStyle.SelectAndMoveFeature:
                    {
                        SelectAndMove_MouseDown(e);
                        break;
                    }
                case MapOpStyle.MoveNode:
                    {
                        MoveNode_MouseDown();
                        break;
                    }
            }
        }

        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinate(e.Location);
            switch (_operation.MapStyle)
            {
                case MapOpStyle.ZoomIn:
                    {
                        ZoomIn_MouseMove(e);
                        break;
                    }
                case MapOpStyle.ZoomOut:
                    {
                        ZoomOut_MouseMove(e);
                        break;
                    }
                case MapOpStyle.Pan:
                    {
                        Pan_MouseMove(e);
                        break;
                    }
                case MapOpStyle.Select:
                    {
                        Select_MouseMove(e);
                        break;
                    }
                case MapOpStyle.Identify:
                    {
                        Identify_MouseMove(e);
                        break;
                    }
                case MapOpStyle.SelectAndMoveFeature:
                    {
                        SelectAndMove_MouseMove(e);
                        break;
                    }
                case MapOpStyle.MoveNode:
                    {
                        MoveNode_MouseMove(e);
                        break;
                    }
                case MapOpStyle.AddNode:
                    {
                        AddNode_MouseMove(e);
                        break;
                    }
                case MapOpStyle.DelNode:
                    {
                        DelNode_MouseMove(e);
                        break;
                    }
                case MapOpStyle.Create:
                    {
                        CreateFeature_MouseMove(e);
                        break;
                    }
            }
        }

        private void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            switch (_operation.MapStyle)
            {
                case MapOpStyle.ZoomIn:
                {
                    ZoomIn_MouseUp(e);
                    break;
                }
                case MapOpStyle.ZoomOut:
                {
                    ZoomOut_MouseUp(e);
                    break;
                }
                case MapOpStyle.Pan:
                {
                    Pan_MouseUp(e);
                    break;
                }
                case MapOpStyle.Select:
                {
                    Select_MouseUp(e);
                    break;
                }
                case MapOpStyle.Identify:
                {
                    Identify_MouseUp(e);
                    break;
                }
                case MapOpStyle.SelectAndMoveFeature:
                {
                    SelectAndMove_MouseUp(e);
                    break;
                }
                case MapOpStyle.MoveNode:
                {
                    MoveNode_MouseUp();
                    break;
                }
            }
        }

        private void mapControl_MouseWheel(object sender, MouseEventArgs e)
        {
            double sX = mapControl.ClientRectangle.Width / 2.0;
            double sY = mapControl.ClientRectangle.Height / 2.0;
            moPoint sPoint = mapControl.ToMapPoint(sX, sY);
            if (e.Delta > 0)
                mapControl.ZoomByCenter(sPoint, _setting.ZoomRatioClick);
            else
                mapControl.ZoomByCenter(sPoint, 1 / _setting.ZoomRatioClick);
        }

        #endregion Map event handling

        #region Private functions

        private void InitializeProperty()
        {
            _setting = new SettingVariable();
            _operation = new OperationVariable();
            Render = new RenderVariable();
            Label = new LabelVariable();
            AttributeTables = new List<AttributeTable>();
            MouseWheel += mapControl_MouseWheel;
        }

        private bool GetEditGeometrySuccessfully()
        {
            if (_operation.EditedLayerIndex == -1) return false;
            moMapLayer layer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
            if (layer.SelectedFeatures.Count != 1)
            {
                MessageBox.Show(@"请选择单个可编辑的要素进行修改");
                return false;
            }

            _operation.EditingNodeGeometry = layer.SelectedFeatures.GetItem(0).Geometry;

            mapControl.RedrawTrackingShapes();
            return true;
        }

        /// <summary>
        /// drawing the creating feature
        /// </summary>
        /// <param name="drawingTool"></param>
        private void DrawCreatingFeature(moUserDrawingTool drawingTool)
        {
            if (_operation.EditedLayerIndex == -1) return;

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        if (_operation.CreatingPoint.Count == 0) return;

                        drawingTool.DrawPoint(_operation.CreatingPoint[0], _setting.EditingNodeSymbol);
                        break;
                    }
                case moGeometryTypeConstant.MultiPolyline:
                    {
                        if (_operation.CreatingFeature.Count == 0)
                            return;
                        int partCount = _operation.CreatingFeature.Count;

                        // draw finished parts
                        for (int i = 0; i < partCount - 1; i++)
                        {
                            drawingTool.DrawPolyline(_operation.CreatingFeature[i], _setting.EditingPolylineSymbol);
                        }

                        // draw creating part
                        moPoints lastPart = _operation.CreatingFeature.Last();
                        if (lastPart.Count > 1)
                        {
                            drawingTool.DrawPolyline(lastPart, _setting.EditingPolylineSymbol);
                        }

                        // drawing all nodes
                        for (int i = 0; i < partCount; i++)
                        {
                            moPoints points = _operation.CreatingFeature[i];
                            drawingTool.DrawPoints(points, _setting.EditingNodeSymbol);
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        if (_operation.CreatingFeature == null)
                            return;
                        int partCount = _operation.CreatingFeature.Count;

                        // draw finished pars
                        for (int i = 0; i < partCount - 1; i++)
                        {
                            drawingTool.DrawPolygon(_operation.CreatingFeature[i], _setting.EditingPolygonSymbol);
                        }

                        // draw creating part
                        // use polyline to express polygon
                        moPoints lastPart = _operation.CreatingFeature.Last();
                        if (lastPart.Count > 1)
                            drawingTool.DrawPolyline(lastPart, _setting.EditingPolygonSymbol.Outline);

                        // draw all nodes
                        for (int i = 0; i <= partCount - 1; i++)
                        {
                            moPoints points = _operation.CreatingFeature[i];
                            drawingTool.DrawPoints(points, _setting.EditingNodeSymbol);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// drawing feature in editing nodes
        /// </summary>
        /// <param name="drawingTool"></param>
        private void DrawEditingNodeFeature(moUserDrawingTool drawingTool)
        {
            if (_operation.EditingNodeGeometry == null)
                return;

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        moPoint point = (moPoint)_operation.EditingNodeGeometry;
                        drawingTool.DrawPoint(point, _setting.EditingNodeSymbol);
                        break;
                    }
                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline multiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        drawingTool.DrawMultiPolyline(multiPolyline, _setting.EditingPolylineSymbol);

                        int partCount = multiPolyline.Parts.Count;
                        for (int i = 0; i < partCount; i++)
                        {
                            moPoints points = multiPolyline.Parts.GetItem(i);
                            drawingTool.DrawPoints(points, _setting.EditingNodeSymbol);
                        }

                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;

                        // draw border (transparent fill)
                        drawingTool.DrawMultiPolygon(sMultiPolygon, _setting.EditingPolygonSymbol);

                        // draw nodes
                        int partCount = sMultiPolygon.Parts.Count;
                        for (int i = 0; i <= partCount - 1; i++)
                        {
                            moPoints points = sMultiPolygon.Parts.GetItem(i);
                            drawingTool.DrawPoints(points, _setting.EditingNodeSymbol);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Add Layer to map
        /// </summary>
        /// <param name="mapLayer">新图层</param>
        private void AddLayerToMap(moMapLayer mapLayer)
        {
            int index = GetInsertIndex(mapLayer.ShapeType);
            _operation.SelectedLayerIndex = index;
            mapControl.Layers.Insert(index, mapLayer);
            RefreshLayersTree();
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
        /// the default order of layers is point polyline polygon
        /// get the layer index when insert a specified type layer
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private int GetInsertIndex(moGeometryTypeConstant shapeType)
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
        /// refresh the layers tree according to Layers
        /// add context menu to node
        /// </summary>
        private void RefreshLayersTree()
        {
            layersTreeView.Nodes.Clear();
            for (int i = 0; i < mapControl.Layers.Count; i++)
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
            _operation.MapStyle = MapOpStyle.None;
            if(_operation.SelectedLayerIndex != -1)
                layersTreeView.Nodes[_operation.SelectedLayerIndex].BackColor = Color.LightGray;
        }

        private void SaveEdit()
        {
            return;
        }

        private void CancelEdit()
        {
            return;
        }

        private void SaveNodeEdit()
        {
            if (_operation.IsNodeChanged)
            {
                moMapLayer layer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
                layer.SelectedFeatures.GetItem(0).Geometry = _operation.EditingNodeGeometry;
                layer.UpdateExtent();
            }
            _operation.EndEditNode();
            mapControl.RedrawMap();
        }

        private void AddNode_MouseClick(MouseEventArgs e)
        {
            // if not near node, return
            if (_operation.MouseOnPartIndex == -1 || _operation.MouseOnPointIndex == -1) return;
            _operation.IsNodeChanged = true;
            moPoint addedPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline multiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        moPoints points = multiPolyline.Parts.GetItem(_operation.MouseOnPartIndex);
                        points.Insert(_operation.MouseOnPointIndex + 1, addedPoint);
                        multiPolyline.UpdateExtent();
                        _operation.EditingNodeGeometry = multiPolyline;
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon multiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;
                        moPoints sPoints = multiPolygon.Parts.GetItem(_operation.MouseOnPartIndex);
                        sPoints.Insert(_operation.MouseOnPointIndex + 1, addedPoint);
                        multiPolygon.UpdateExtent();
                        _operation.EditingNodeGeometry = multiPolygon;

                        break;
                    }
            }
            mapControl.RedrawTrackingShapes();
            _operation.MouseOnPartIndex = -1;
            _operation.MouseOnPointIndex = -1;
        }

        private void DelNode_MouseClick(MouseEventArgs e)
        {
            if (_operation.MouseOnPartIndex == -1 || _operation.MouseOnPointIndex == -1) return;
            _operation.IsNodeChanged = true;
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline multiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        moPoints points = multiPolyline.Parts.GetItem(_operation.MouseOnPartIndex);
                        if (points.Count > 2)
                        {
                            points.RemoveAt(_operation.MouseOnPointIndex);
                        }
                        else
                        {
                            MessageBox.Show(@"要素节点数量不足，无法删减");
                            // return to move node state
                            moveNodeButton_Click(new object(), e);
                            return;
                        }
                        multiPolyline.UpdateExtent();
                        _operation.EditingNodeGeometry = multiPolyline;
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon multiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;
                        moPoints points = multiPolygon.Parts.GetItem(_operation.MouseOnPartIndex);
                        if (points.Count > 3)
                        {
                            points.RemoveAt(_operation.MouseOnPointIndex);
                        }
                        else
                        {
                            MessageBox.Show(@"要素节点数量不足，无法删减");
                            // trans to move node state
                            moveNodeButton_Click(new object(), e);
                            return;
                        }
                        multiPolygon.UpdateExtent();
                        _operation.EditingNodeGeometry = multiPolygon;
                        break;
                    }
            }
            mapControl.RedrawTrackingShapes();
            _operation.MouseOnPartIndex = -1;
            _operation.MouseOnPointIndex = -1;
        }

        private void CreateFeature_MouseClick(MouseEventArgs e)
        {
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        //将屏幕坐标转换为地图坐标并加入描绘图形
                        moPoint point = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
                        _operation.CreatingPoint.Add(point);
                        EndCreateFeature();
                        //地图控件重绘跟踪图层
                        mapControl.RedrawTrackingShapes();
                        break;
                    }
                case moGeometryTypeConstant.MultiPolyline:
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        //将屏幕坐标转换为地图坐标并加入描绘图形
                        moPoint sPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
                        _operation.CreatingFeature.Last().Add(sPoint);
                        //地图控件重绘跟踪图层
                        mapControl.RedrawTrackingShapes();
                        break;
                    }
            }
        }

        private void EndCreatePart()
        {
            _operation.IsLayerChanged = true;
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.MultiPolyline:
                    {
                        //判断是否可以结束，即是否最少两个点
                        if (_operation.CreatingFeature.Last().Count < 2)
                            return;
                        //往描绘图形中增加一个多点对象
                        moPoints sPoints = new moPoints();
                        _operation.CreatingFeature.Add(sPoints);
                        //重绘跟踪层
                        mapControl.RedrawTrackingShapes();
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        //判断是否可以结束，即是否最少三个点
                        if (_operation.CreatingFeature.Last().Count < 3)
                            return;
                        //往描绘图形中增加一个多点对象
                        moPoints sPoints = new moPoints();
                        _operation.CreatingFeature.Add(sPoints);
                        //重绘跟踪层
                        mapControl.RedrawTrackingShapes();
                        break;
                    }
            }
        }

        private void EndCreateFeature()
        {
            _operation.IsLayerChanged = true;
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        if (_operation.CreatingPoint.Count == 1)
                        {
                            moMapLayer layer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
                            moFeature feature = layer.GetNewFeature();
                            feature.Geometry = _operation.CreatingPoint[0];
                            layer.Features.Add(feature);
                            layer.UpdateExtent();
                            layer.SelectedFeatures.Clear();
                            layer.SelectedFeatures.Add(feature);
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        if (_operation.CreatingFeature.Last().Count == 1)
                            return;
                        //如果最后一个部件的点数等于 2，则删除最后一个部件
                        if (_operation.CreatingFeature.Last().Count == 0)
                        {
                            _operation.CreatingFeature.Remove(_operation.CreatingFeature.Last());
                        }

                        //如果用户的确输入了，则加入多边形图层
                        if (_operation.CreatingFeature.Count > 0)
                        {
                            //查找多边形图层，如果有则加入该图层
                            moMapLayer layer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
                            //新建复合多边形
                            moMultiPolyline multiPolyline = new moMultiPolyline();
                            multiPolyline.Parts.AddRange(_operation.CreatingFeature.ToArray());
                            multiPolyline.UpdateExtent();
                            //生成要素并加入图层
                            moFeature feature = layer.GetNewFeature();
                            feature.Geometry = multiPolyline;
                            layer.Features.Add(feature);
                            layer.UpdateExtent();
                            layer.SelectedFeatures.Clear();
                            layer.SelectedFeatures.Add(feature);
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        if (_operation.CreatingFeature.Last().Count >= 1 && _operation.CreatingFeature.Last().Count < 3)
                            return;
                        //如果最后一个部件的点数小于3，则删除最后一个部件
                        if (_operation.CreatingFeature.Last().Count == 0)
                        {
                            _operation.CreatingFeature.Remove(_operation.CreatingFeature.Last());
                        }
                        //如果用户的确输入了，则加入多边形图层
                        if (_operation.CreatingFeature.Count > 0)
                        {
                            //查找多边形图层，如果有则加入该图层
                            moMapLayer layer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
                            //新建复合多边形
                            moMultiPolygon multiPolygon = new moMultiPolygon();
                            multiPolygon.Parts.AddRange(_operation.CreatingFeature.ToArray());
                            multiPolygon.UpdateExtent();
                            //生成要素并加入图层
                            moFeature sFeature = layer.GetNewFeature();
                            sFeature.Geometry = multiPolygon;
                            layer.Features.Add(sFeature);
                            layer.UpdateExtent();
                            layer.SelectedFeatures.Clear();
                            layer.SelectedFeatures.Add(sFeature);
                        }
                        break;
                    }
            }
            _operation.EndCreateFeature();
            mapControl.RedrawMap();
            moveFeatureButton_Click(new object(),EventArgs.Empty);
        }

        private void CreateFeature_MouseDoubleClick()
        {
            EndCreatePart();
            EndCreateFeature();
        }

        private void ZoomIn_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;
            Cursor = new Cursor(Resources.zoom.Handle);
        }

        private void ZoomOut_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;
            Cursor = new Cursor(Resources.zoom.Handle);
        }

        private void Pan_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;
            Cursor = new Cursor(Resources.pan.Handle);
        }

        private void Select_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;
        }

        private void Identify_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;
        }

        private void SelectAndMove_MouseDown(MouseEventArgs e)
        {
            _operation.StartMouseLocation = e.Location;
            _operation.IsLeftMousePressed = true;

            // 选择是进行选择，还是进行移动
            _operation.IsMouseDownOnSelectedFeature = false;
            moPoint mousePoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            moFeatures editedSelectedFeatures = mapControl.Layers.GetItem(_operation.EditedLayerIndex).SelectedFeatures;
            double mapTolerance = mapControl.ToMapDistance(_setting.Tolerance);

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        for (int i = 0; i < editedSelectedFeatures.Count; i++)
                        {
                            moPoint featurePoint = (moPoint)editedSelectedFeatures.GetItem(i).Geometry;
                            if (!moMapTools.IsPointOnPoint(mousePoint, featurePoint, mapTolerance)) continue;
                            _operation.IsMouseDownOnSelectedFeature = true;
                            break;
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        for (int i = 0; i < editedSelectedFeatures.Count; i++)
                        {
                            moMultiPolyline sMultiPolyline = (moMultiPolyline)editedSelectedFeatures.GetItem(i).Geometry;
                            if (!moMapTools.IsPointOnMultiPolyline(mousePoint, sMultiPolyline, mapTolerance)) continue;
                            _operation.IsMouseDownOnSelectedFeature = true;
                            break;
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        for (int i = 0; i < editedSelectedFeatures.Count; i++)
                        {
                            moMultiPolygon sMultiPolygon = (moMultiPolygon)editedSelectedFeatures.GetItem(i).Geometry;
                            if (!moMapTools.IsPointWithinMultiPolygon(mousePoint, sMultiPolygon)) continue;
                            _operation.IsMouseDownOnSelectedFeature = true;
                            break;
                        }
                        break;
                    }
            }

            if (_operation.IsMouseDownOnSelectedFeature)
            {
                GetMovingGeometries();
            }
        }

        private void GetMovingGeometries()
        {
            _operation.MovingGeometries.Clear();

            moFeatures editedSelectedFeatures = mapControl.Layers.GetItem(_operation.EditedLayerIndex).SelectedFeatures;
            int sSelFeatureCount = editedSelectedFeatures.Count;

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        for (int i = 0; i < sSelFeatureCount; ++i)
                        {
                            moPoint point = (moPoint)editedSelectedFeatures.GetItem(i).Geometry;
                            _operation.MovingGeometries.Add(point);
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        for (int i = 0; i < sSelFeatureCount; ++i)
                        {
                            moMultiPolyline multiPolyline = (moMultiPolyline)editedSelectedFeatures.GetItem(i).Geometry;
                            _operation.MovingGeometries.Add(multiPolyline);
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolygon:
                    {
                        for (int i = 0; i < sSelFeatureCount; ++i)
                        {
                            moMultiPolygon multiPolygon = (moMultiPolygon)editedSelectedFeatures.GetItem(i).Geometry;
                            _operation.MovingGeometries.Add(multiPolygon);
                        }
                        break;
                    }
            }
        }

        private void MoveNode_MouseDown()
        {
            if (_operation.MouseOnPartIndex == -1 || _operation.MouseOnPointIndex == -1) return;
            _operation.IsMouseDownNearNode = true;
        }

        private void ZoomIn_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;
            mapControl.Refresh();
            moRectangle sRect = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, _setting.ZoomBoxSymbol);
        }

        private void ZoomOut_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;
            mapControl.Refresh();
            moRectangle sRect = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, _setting.ZoomBoxSymbol);
        }

        private void Pan_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;
            mapControl.PanMapImageTo(e.Location.X - _operation.StartMouseLocation.X, e.Location.Y - _operation.StartMouseLocation.Y);
        }

        private void Select_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;
            mapControl.Refresh();
            moRectangle sRect = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, _setting.SelectBoxSymbol);
        }

        private void Identify_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;
            mapControl.Refresh();
            moRectangle sRect = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, _setting.SelectBoxSymbol);
        }

        private void SelectAndMove_MouseMove(MouseEventArgs e)
        {
            if (_operation.IsMouseDownOnSelectedFeature)
            {
                _operation.IsSelectedFeatureMoved = true;
                _operation.IsLayerChanged = true;

                //修改移动图形的坐标
                double deltaX = mapControl.ToMapDistance(e.Location.X - _operation.StartMouseLocation.X);
                double deltaY = mapControl.ToMapDistance(_operation.StartMouseLocation.Y - e.Location.Y);
                ModifyMovingGeometriesLocation(deltaX, deltaY);

                //刷新地图并绘制移动图形
                mapControl.Refresh();

                DrawMovingGeometries();

                //重新设置鼠标位置
                _operation.StartMouseLocation = e.Location;
            }
            else
            {
                Select_MouseMove(e);
            }
        }

        private void ModifyMovingGeometriesLocation(double deltaX, double deltaY)
        {
            int count = _operation.MovingGeometries.Count;
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moPoint sPoint = (moPoint)_operation.MovingGeometries[i];
                            sPoint.X += deltaX;
                            sPoint.Y += deltaY;
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moMultiPolyline sMultiPolyline =
                                (moMultiPolyline)_operation.MovingGeometries[i];
                            int sPartCount = sMultiPolyline.Parts.Count;
                            for (int j = 0; j <= sPartCount - 1; j++)
                            {
                                moPoints sPoints = sMultiPolyline.Parts.GetItem(j);
                                int sPointCount = sPoints.Count;
                                for (int k = 0; k <= sPointCount - 1; k++)
                                {
                                    moPoint sPoint = sPoints.GetItem(k);
                                    sPoint.X += deltaX;
                                    sPoint.Y += deltaY;
                                }
                            }

                            sMultiPolyline.UpdateExtent();
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.MovingGeometries[i];
                            int sPartCount = sMultiPolygon.Parts.Count;
                            for (int j = 0; j <= sPartCount - 1; j++)
                            {
                                moPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                                int sPointCount = sPoints.Count;
                                for (int k = 0; k <= sPointCount - 1; k++)
                                {
                                    moPoint sPoint = sPoints.GetItem(k);
                                    sPoint.X += deltaX;
                                    sPoint.Y += deltaY;
                                }
                            }
                            sMultiPolygon.UpdateExtent();
                        }
                        break;
                    }
            }
        }

        private void DrawMovingGeometries()
        {
            moUserDrawingTool drawingTool = mapControl.GetDrawingTool();
            int count = _operation.MovingGeometries.Count;
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moPoint point = (moPoint)_operation.MovingGeometries[i];
                            drawingTool.DrawPoint(point, _setting.MovingPointSymbol);
                        }

                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moMultiPolyline multiPolyline =
                                (moMultiPolyline)_operation.MovingGeometries[i];
                            drawingTool.DrawMultiPolyline(multiPolyline, _setting.MovingPolylineSymbol);
                        }

                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            moMultiPolygon multiPolygon =
                                (moMultiPolygon)_operation.MovingGeometries[i];
                            drawingTool.DrawMultiPolygon(multiPolygon, _setting.MovingPolygonSymbol);
                        }

                        break;
                    }
            }
        }

        private void MoveNode_MouseMove(MouseEventArgs e)
        {

            // not select node, just move around
            if (!_operation.IsMouseDownNearNode)
            {
                SelectNodeToMove_MouseMove(e);
            }

            // move the selected node
            else
            {
                MoveSelectedNode_MouseMove(e);
            }
        }

        private void SelectNodeToMove_MouseMove(MouseEventArgs e)
        {
            moPoint sPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            double mapTolerance = mapControl.ToMapDistance(_setting.Tolerance);

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        moPoint sEditingPoint = (moPoint)_operation.EditingNodeGeometry;

                        if (moMapTools.IsPointOnPoint(sPoint, sEditingPoint, mapTolerance))
                        {
                            _operation.MouseOnPartIndex = 0;
                            _operation.MouseOnPointIndex = 0;
                            Cursor = new Cursor(Resources.node.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline sMultiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        if (PointCloseToMultiPolylinePoint(sPoint, sMultiPolyline, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.node.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;
                        
                        if (PointCloseToMultiPolygonPoint(sPoint, sMultiPolygon, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.node.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
            }
        }

        private void MoveSelectedNode_MouseMove(MouseEventArgs e)
        {
            moPoint sPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        
                        _operation.IsNodeChanged = true;
                        _operation.EditingNodeGeometry = sPoint;
                        mapControl.RedrawTrackingShapes();
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        _operation.IsNodeChanged = true;
                        moMultiPolyline sMultiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        
                            moPoint newPoint = sMultiPolyline.Parts.GetItem(_operation.MouseOnPartIndex).GetItem(_operation.MouseOnPointIndex);
                            newPoint.X = sPoint.X; newPoint.Y = sPoint.Y;
                            sMultiPolyline.UpdateExtent();
                            _operation.EditingNodeGeometry = sMultiPolyline;
                            mapControl.RedrawTrackingShapes();
               
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        _operation.IsNodeChanged = true;
                        moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;
                        moPoint newPoint = sMultiPolygon.Parts.GetItem(_operation.MouseOnPartIndex).GetItem(_operation.MouseOnPointIndex);
                        newPoint.X = sPoint.X; newPoint.Y = sPoint.Y;
                        sMultiPolygon.UpdateExtent();
                        _operation.EditingNodeGeometry = sMultiPolygon;
                        mapControl.RedrawTrackingShapes();
                        break;
                    }
            }
        }

        private bool PointCloseToMultiPolylinePoint(moPoint sPoint, moMultiPolyline sMultiPolyline, double sTolerance)
        {
            switch (_operation.MapStyle)
            {
                case MapOpStyle.MoveNode:
                case MapOpStyle.DelNode:
                    {
                        for (int i = 0; i < sMultiPolyline.Parts.Count; i++)
                        {
                            moPoints sPoints = sMultiPolyline.Parts.GetItem(i);
                            int j = 0;
                            for (; j < sPoints.Count; j++)
                            {
                                if (moMapTools.IsPointOnPoint(sPoint, sPoints.GetItem(j), sTolerance))
                                {
                                    _operation.MouseOnPartIndex = i;
                                    _operation.MouseOnPointIndex = j;
                                    return true;
                                }
                            }
                        }
                        break;
                    }
                case MapOpStyle.AddNode:
                    {
                        for (int i = 0; i < sMultiPolyline.Parts.Count; i++)
                        {
                            moPoints sPoints = sMultiPolyline.Parts.GetItem(i);
                            for (int j = 0; j < sPoints.Count - 1; j++)
                            {
                                moPoints tempPoints = new moPoints();
                                tempPoints.Add(sPoints.GetItem(j));
                                tempPoints.Add(sPoints.GetItem(j + 1));
                                tempPoints.UpdateExtent();
                                if (moMapTools.IsPointOnPolyline(sPoint, tempPoints, sTolerance))
                                {
                                    _operation.MouseOnPartIndex = i;
                                    _operation.MouseOnPointIndex = j;
                                    return true;
                                }
                            }
                        }
                        break;
                    }
            }
            return false;
        }


        private bool PointCloseToMultiPolygonPoint(moPoint point, moMultiPolygon multiPolygon, double tolerance)
        {
            switch (_operation.MapStyle)
            {
                case MapOpStyle.MoveNode:
                case MapOpStyle.DelNode:
                    {
                        for (int i = 0; i < multiPolygon.Parts.Count; i++)
                        {
                            moPoints sPoints = multiPolygon.Parts.GetItem(i);
                            for (int j = 0; j < sPoints.Count; j++)
                            {
                                if (moMapTools.IsPointOnPoint(point, sPoints.GetItem(j), tolerance))
                                {
                                    _operation.MouseOnPartIndex = i;
                                    _operation.MouseOnPointIndex = j;
                                    return true;
                                }
                            }
                        }
                        break;
                    }
                case MapOpStyle.AddNode:
                    {
                        for (int i = 0; i < multiPolygon.Parts.Count; i++)
                        {
                            moPoints points = multiPolygon.Parts.GetItem(i);
                            for (int j = 0; j < points.Count; j++)
                            {
                                moPoints tempPoints = new moPoints();
                                tempPoints.Add(points.GetItem(j));
                                tempPoints.Add(j < points.Count - 1 ? points.GetItem(j + 1) : points.GetItem(0));
                                tempPoints.UpdateExtent();
                                if (moMapTools.IsPointOnPolyline(point, tempPoints, tolerance))
                                {
                                    _operation.MouseOnPartIndex = i;
                                    _operation.MouseOnPointIndex = j;
                                    return true;
                                }
                            }
                        }
                        break;
                    }
            }
            return false;
        }

        private void AddNode_MouseMove(MouseEventArgs e)
        {
            moPoint sPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            double mapTolerance = mapControl.ToMapDistance(_setting.Tolerance);

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        moPoint sEditingPoint = (moPoint)_operation.EditingNodeGeometry;

                        if (moMapTools.IsPointOnPoint(sPoint, sEditingPoint, mapTolerance))
                        {
                            _operation.MouseOnPartIndex = 0;
                            _operation.MouseOnPointIndex = 0;
                            Cursor = new Cursor(Resources.add.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline sMultiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        if (PointCloseToMultiPolylinePoint(sPoint, sMultiPolyline, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.add.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;

                        if (PointCloseToMultiPolygonPoint(sPoint, sMultiPolygon, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.add.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
            }
        }

        private void DelNode_MouseMove(MouseEventArgs e)
        {
            moPoint sPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            double mapTolerance = mapControl.ToMapDistance(_setting.Tolerance);

            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.Point:
                    {
                        moPoint sEditingPoint = (moPoint)_operation.EditingNodeGeometry;

                        if (moMapTools.IsPointOnPoint(sPoint, sEditingPoint, mapTolerance))
                        {
                            _operation.MouseOnPartIndex = 0;
                            _operation.MouseOnPointIndex = 0;
                            Cursor = new Cursor(Resources.del.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }

                case moGeometryTypeConstant.MultiPolyline:
                    {
                        moMultiPolyline sMultiPolyline = (moMultiPolyline)_operation.EditingNodeGeometry;
                        if (PointCloseToMultiPolylinePoint(sPoint, sMultiPolyline, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.del.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
                case moGeometryTypeConstant.MultiPolygon:
                    {
                        moMultiPolygon sMultiPolygon = (moMultiPolygon)_operation.EditingNodeGeometry;

                        if (PointCloseToMultiPolygonPoint(sPoint, sMultiPolygon, mapTolerance))
                        {
                            Cursor = new Cursor(Resources.del.Handle);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _operation.MouseOnPartIndex = -1;
                            _operation.MouseOnPointIndex = -1;
                        }
                        break;
                    }
            }
        }

        private void CreateFeature_MouseMove(MouseEventArgs e)
        {
            moPoint mapPoint = mapControl.ToMapPoint(e.Location.X, e.Location.Y);
            switch (EditingLayerShape)
            {
                case moGeometryTypeConstant.MultiPolyline:
                {
                    moPoints sLastPart = _operation.CreatingFeature.Last();
                    int sPointCount = sLastPart.Count;
                    if (sPointCount == 0)
                    { }
                    else
                    {
                        mapControl.Refresh();
                        moPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                        moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
                        sDrawingTool.DrawLine(sLastPoint, mapPoint, _setting.ElasticSymbol);
                    }
                    break;
                }
                case moGeometryTypeConstant.MultiPolygon:
                {
                    moPoints sLastPart = _operation.CreatingFeature.Last();
                    int sPointCount = sLastPart.Count;
                    if (sPointCount == 0)
                    { }
                    else if (sPointCount == 1)
                    {
                        mapControl.Refresh();
                        //只有一个顶点，则绘制一条橡皮筋
                        moPoint sFirstPoint = sLastPart.GetItem(0);
                        moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
                        sDrawingTool.DrawLine(sFirstPoint, mapPoint, _setting.ElasticSymbol);
                    }
                    else
                    {
                        mapControl.Refresh();
                        //两个以上顶点，则绘制两条橡皮筋
                        moPoint sFirstPoint = sLastPart.GetItem(0);
                        moPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                        moUserDrawingTool sDrawingTool = mapControl.GetDrawingTool();
                        sDrawingTool.DrawLine(sFirstPoint, mapPoint, _setting.ElasticSymbol);
                        sDrawingTool.DrawLine(sLastPoint, mapPoint, _setting.ElasticSymbol);
                    }
                    break;
                }
            }
        }

        private void ZoomIn_MouseUp(MouseEventArgs e)
        {
            if(_operation .IsLeftMousePressed == false)  return;
            
            _operation.IsLeftMousePressed = false;
            if (Math.Abs(_operation.StartMouseLocation.X - e.Location.X) < _setting.Tolerance && Math.Abs(_operation.StartMouseLocation.Y - e.Location.Y) < _setting.Tolerance)
            {
                moPoint sPoint = mapControl.ToMapPoint(_operation.StartMouseLocation.X, _operation.StartMouseLocation.Y);
                mapControl.ZoomByCenter(sPoint, _setting.ZoomRatioClick);
            }
            else
            {
                moRectangle sBox = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
                mapControl.ZoomToExtent(sBox);
            }
            Cursor = Cursors.Default;

        }

        private void ZoomOut_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false) return;

            _operation.IsLeftMousePressed = false;
            if (Math.Abs(_operation.StartMouseLocation.X - e.Location.X) < _setting.Tolerance && Math.Abs(_operation.StartMouseLocation.Y - e.Location.Y) < _setting.Tolerance)
            {
                moPoint sPoint = mapControl.ToMapPoint(_operation.StartMouseLocation.X, _operation.StartMouseLocation.Y);
                mapControl.ZoomByCenter(sPoint, 1/_setting.ZoomRatioClick);
            }
            else
            {
                moRectangle sBox = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
                mapControl.ZoomOutToExtent(sBox);
            }
            Cursor = Cursors.Default;
        }

        private void Pan_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false)
                return;
            _operation.IsLeftMousePressed = false;
            double sDeltaX = mapControl.ToMapDistance(e.Location.X - _operation.StartMouseLocation.X);
            double sDeltaY = mapControl.ToMapDistance(_operation.StartMouseLocation.Y - e.Location.Y);
            mapControl.PanDelta(sDeltaX, sDeltaY);
            Cursor = Cursors.Default;
        }
        private void Select_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false)
            {
                return;
            }
            _operation.IsLeftMousePressed = false;
            moRectangle sBox = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            double sTolerance = mapControl.ToMapDistance(_setting.Tolerance);
            mapControl.SelectLayerByBox(sBox, sTolerance, _operation.SelectedLayerIndex);
            mapControl.RedrawTrackingShapes();
            RedrawAttribute();
        }
        private void Identify_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false)
            {
                return;
            }
            _operation.IsLeftMousePressed = false;
            mapControl.Refresh();
            moRectangle sBox = mapControl.GetMapRectByTwoPoints(_operation.StartMouseLocation, e.Location);
            double sTolerance = mapControl.ToMapDistance(_setting.Tolerance);
            
            if (mapControl.Layers.Count == 0)
            {
                return;
            }

            moMapLayer sLayer = mapControl.Layers.GetItem(_operation.SelectedLayerIndex);
            moFeatures sFeatures = sLayer.SearchByBox(sBox, sTolerance);
            int sSelFeatureCount = sFeatures.Count;
            if (sSelFeatureCount > 0)
            {
                moShape[] sGeometries = new moShape[sSelFeatureCount];
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    sGeometries[i] = sFeatures.GetItem(i).Geometry;
                }
                mapControl.FlashShapes(sGeometries, 2, 500);

            }

            if (sSelFeatureCount <= 0) return;
            Identify mIdentify = new Identify(mapControl.Layers.GetItem(_operation.SelectedLayerIndex), sFeatures);
            mIdentify.Owner = this;
            mIdentify.ShowDialog();
        }
        private void SelectAndMove_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsLeftMousePressed == false)
            {
                return;
            }

            if (_operation.IsMouseDownOnSelectedFeature)
            {
                MoveSelectedFeature_MouseUp(e);
            }
            else
            {
                Select_MouseUp(e);
            }
            _operation.IsLeftMousePressed = false;
        }

        private void MoveSelectedFeature_MouseUp(MouseEventArgs e)
        {
            if (_operation.IsSelectedFeatureMoved)
            {
                _operation.IsSelectedFeatureMoved = false;
                moMapLayer sLayer = mapControl.Layers.GetItem(_operation.EditedLayerIndex);
                for (int i = 0; i < sLayer.SelectedFeatures.Count; i++)
                {
                    moFeature sFeature = sLayer.SelectedFeatures.GetItem(i);
                    sFeature.Geometry = _operation.MovingGeometries[i];
                }
                sLayer.UpdateExtent();
                mapControl.RedrawMap();
            }
            else
            {
                moRectangle sBox = mapControl.GetMapRectByTwoPoints(e.Location, e.Location);
                double sTolerance = mapControl.ToMapDistance(_setting.Tolerance);
                mapControl.SelectLayerByBox(sBox, sTolerance, _operation.EditedLayerIndex);
                mapControl.RedrawTrackingShapes();
            }
            //清除移动图形列表
            _operation.MovingGeometries.Clear();
        }

        private void MoveNode_MouseUp()
        {
            _operation.IsMouseDownNearNode = false;
            _operation.MouseOnPartIndex = -1;
            _operation.MouseOnPointIndex = -1;
        }
        public void RedrawAttribute()
        {
            foreach (var t in AttributeTables)
                t.BeginRefresh();
        }

        //在该函数中接收新建图层的参数
        public void GetCreateLayerInfo(string layerName, moGeometryTypeConstant layerType, string savePath)
        {
            moField sField = new moField("id", moValueTypeConstant.dInt32);
            moFields sFields = new moFields();
            sFields.Append(sField);
            sFields.PrimaryField = sField.Name;
            moMapLayer sMapLayer = new moMapLayer(layerName,savePath, layerType, sFields);
            moFeatures sFeatures = new moFeatures();
            sMapLayer.Features = sFeatures;
            AddLayerToMap(sMapLayer);
        }

        private void ShowCoordinate(PointF point)
        {
            moPoint sPoint = mapControl.ToMapPoint(point.X, point.Y);
            if (!isProjectionCheckBox.Checked)
            {
                moPoint sLngLat = mapControl.ProjectionCS.TransferToLngLat(sPoint);
                double sX = Math.Round(sLngLat.X, 4);
                double sY = Math.Round(sLngLat.Y, 4);
                string lng = " °E ";
                string lat = " °N ";
                if (sX < 0) lng = " °W ";
                if (sY < 0) lat = " °S ";
                coordinateStatusLabel.Text = sX + lng + @" , " + sY + lat;
            }
            else
            {
                double sX = Math.Round(sPoint.X);
                double sY = Math.Round(sPoint.Y);
                coordinateStatusLabel.Text = @"X: " + sX + @", Y: " + sY;

            }
        }



        #endregion Private functions

        

        
    }
}