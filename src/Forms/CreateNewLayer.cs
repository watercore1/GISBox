using System;
using System.IO;
using System.Windows.Forms;
using MyMapObjects;

namespace GISBox.Forms
{
    public partial class CreateNewLayer : Form
    {
        #region 字段

        private string _layerName;
        private moGeometryTypeConstant _layerType;
        private string _savePath;

        #endregion

        #region Constructors
        public CreateNewLayer()
        {
            InitializeComponent();
            _layerName = string.Empty;
            _layerType = moGeometryTypeConstant.None;
            _savePath = string.Empty;

            cboLayerType.Items.Add("Point");
            cboLayerType.Items.Add("MultiPolyline");
            cboLayerType.Items.Add("MultiPolygon");
            cboLayerType.SelectedIndex = 0;
        }
        #endregion

        #region 窗体

        //选择路径
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            sfd.Filter = @"自定义图层(*shp)|*.shp";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            _savePath = sfd.FileName;
            textSavePath.Text = _savePath;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(cboLayerType.SelectedIndex == 0)
            {
                _layerType = moGeometryTypeConstant.Point;
            }
            else if (cboLayerType.SelectedIndex == 1)
            {
                _layerType = moGeometryTypeConstant.MultiPolyline;
            }
            else if (cboLayerType.SelectedIndex == 2)
            {
                _layerType = moGeometryTypeConstant.MultiPolygon;
            }

            _savePath = textSavePath.Text;
            if (_savePath == string.Empty)
            {
                MessageBox.Show(@"请选择保存路径");
            }
            else
            {
                _layerName = Path.GetFileNameWithoutExtension(_savePath);
                MainForm main = (MainForm)Owner;
                main.GetCreateLayerInfo(_layerName, _layerType, _savePath);
                Close();
            }
            
        }

        #endregion
    }
}
