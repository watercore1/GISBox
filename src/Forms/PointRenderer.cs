using System;
using System.Drawing;
using System.Windows.Forms;

namespace GISBox.Forms
{
    public partial class PointRenderer : Form
    {
        #region 字段

        private Int32 _mRendererMode; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染

        private Int32 _mSymbolStyle; //样式索引

        //简单渲染参数
        private Color _mSimpleRendererColor = Color.LightCoral; //符号颜色

        private Double _mSimpleRendererSize = 5; //符号尺寸

        //唯一值渲染参数
        private Int32 _mUniqueFieldIndex; //绑定字段索引

        private Double _mUniqueRendererSize = 5; //符号尺寸

        //分级渲染参数
        private Int32 _mClassBreaksFieldIndex; //绑定字段索引
        private Int32 _mClassBreaksNum = 5; //分类数
        private Color _mClassBreaksRendererColor = Color.LightCoral; //符号颜色
        private Double _mClassBreaksRendererMinSize = 3; //符号起始尺寸,点图层采用符号尺寸进行分级表示
        private Double _mClassBreaksRendererMaxSize = 6; //符号终止尺寸

        #endregion

        #region 构造函数

        public PointRenderer(MyMapObjects.moMapLayer layer)
        {
            InitializeComponent();
            //填充样式下拉列表
            cboStyle.Items.Add("Circle");
            cboStyle.Items.Add("SolidCircle");
            cboStyle.Items.Add("Triangle");
            cboStyle.Items.Add("SolidTriangle");
            cboStyle.Items.Add("Square");
            cboStyle.Items.Add("SolidSquare");
            cboStyle.Items.Add("CircleDot");
            cboStyle.Items.Add("CircleCircle");
            //填充字段下拉列表
            Int32 fieldCount = layer.AttributeFields.Count;
            for (Int32 i = 0; i < fieldCount; i++)
            {
                cboField.Items.Add(layer.AttributeFields.GetItem(i).Name);
            }

            cboStyle.SelectedIndex = 0;
            cboField.SelectedIndex = 0;


            if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.Simple)
            {
                MyMapObjects.moSimpleRenderer sRenderer = (MyMapObjects.moSimpleRenderer)layer.Renderer;
                MyMapObjects.moSimpleMarkerSymbol sSymbol = (MyMapObjects.moSimpleMarkerSymbol)sRenderer.Symbol;
                cboStyle.SelectedIndex = (Int32)sSymbol.Style;
                btnColor.BackColor = sSymbol.Color;
                _mSimpleRendererColor = sSymbol.Color;
                nudSize.Value = Convert.ToDecimal(sSymbol.Size);
                rbtnSimple.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.UniqueValue)
            {
                MyMapObjects.moUniqueValueRenderer sRenderer = (MyMapObjects.moUniqueValueRenderer)layer.Renderer;
                MyMapObjects.moSimpleMarkerSymbol sSymbol = (MyMapObjects.moSimpleMarkerSymbol)sRenderer.GetSymbol(0);
                cboStyle.SelectedIndex = (Int32)sSymbol.Style;
                cboField.SelectedIndex = layer.AttributeFields.FindField(sRenderer.Field);
                nudSize.Value = Convert.ToDecimal(sSymbol.Size);
                rbtnUniqueValue.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.ClassBreaks)
            {
                MyMapObjects.moClassBreaksRenderer sRenderer = (MyMapObjects.moClassBreaksRenderer)layer.Renderer;

                MyMapObjects.moSimpleMarkerSymbol sStartSymbol =
                    (MyMapObjects.moSimpleMarkerSymbol)sRenderer.GetSymbol(0);
                MyMapObjects.moSimpleMarkerSymbol sEndSymbol =
                    (MyMapObjects.moSimpleMarkerSymbol)sRenderer.GetSymbol(sRenderer.BreakCount - 1);
                cboStyle.SelectedIndex = (Int32)sStartSymbol.Style;
                btnColor.BackColor = sStartSymbol.Color;
                _mClassBreaksRendererColor = sStartSymbol.Color;
                cboField.SelectedIndex = layer.AttributeFields.FindField(sRenderer.Field);
                nudClassBreaksNum.Value = sRenderer.BreakCount;
                nudClassBreaksMinSize.Value = Convert.ToDecimal(sStartSymbol.Size);
                nudClassBreaksMaxSize.Value = Convert.ToDecimal(sEndSymbol.Size);
                rbtnClassBreaks.Checked = true;
            }

            SetEnabled();
        }

        #endregion

        #region 窗体操作

        //设置选项是否可选
        private void SetEnabled()
        {
            if (rbtnSimple.Checked)
            {
                btnColor.Enabled = true;
                nudSize.Enabled = true;
                cboField.Enabled = false;
                nudClassBreaksNum.Enabled = false;
                nudClassBreaksMinSize.Enabled = false;
                nudClassBreaksMaxSize.Enabled = false;
            }
            else if (rbtnUniqueValue.Checked)
            {
                btnColor.Enabled = false;
                nudSize.Enabled = true;
                cboField.Enabled = true;
                nudClassBreaksNum.Enabled = false;
                nudClassBreaksMinSize.Enabled = false;
                nudClassBreaksMaxSize.Enabled = false;
            }
            else if (rbtnClassBreaks.Checked)
            {
                btnColor.Enabled = true;
                nudSize.Enabled = true;
                cboField.Enabled = true;
                nudClassBreaksNum.Enabled = true;
                nudClassBreaksMinSize.Enabled = true;
                nudClassBreaksMaxSize.Enabled = true;
            }
        }

        private void rbtnSimple_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void rbtnUniqueValue_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void rbtnClassBreaks_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        //选择渲染方式
        private void GetRendererMode()
        {
            if (rbtnSimple.Checked)
            {
                _mRendererMode = 0;
            }
            else if (rbtnUniqueValue.Checked)
            {
                _mRendererMode = 1;
            }
            else if (rbtnClassBreaks.Checked)
            {
                _mRendererMode = 2;
            }
        }

        //选择样式
        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mSymbolStyle = cboStyle.SelectedIndex;
        }




        //选择简单渲染符号大小
        private void nudSimpleSize_ValueChanged(object sender, EventArgs e)
        {
            _mSimpleRendererSize = (Double)nudSize.Value;
        }







        //确认
        private void btnPointRendererConfirm_Click(object sender, EventArgs e)
        {

            MainForm main = (MainForm)Owner;
            GetRendererMode();
            main.Render.GetPointRenderer(_mRendererMode, _mSymbolStyle, _mSimpleRendererColor, _mSimpleRendererSize,
                _mUniqueFieldIndex, _mUniqueRendererSize, _mClassBreaksFieldIndex, _mClassBreaksNum,
                _mClassBreaksRendererColor, _mClassBreaksRendererMinSize, _mClassBreaksRendererMaxSize);
            Close();
        }

        //取消
        private void btnPointRendererCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mUniqueFieldIndex = cboField.SelectedIndex;
            _mClassBreaksFieldIndex = cboField.SelectedIndex;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldPointRenderer.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                _mClassBreaksRendererColor = cldPointRenderer.Color;
                _mSimpleRendererColor = cldPointRenderer.Color;
                btnColor.BackColor = cldPointRenderer.Color;
            }
        }

        private void nudClassBreaksNum_ValueChanged(object sender, EventArgs e)
        {
            _mClassBreaksNum = (Int32)nudClassBreaksNum.Value;
        }

        private void nudClassBreaksMinSize_ValueChanged(object sender, EventArgs e)
        {
            _mClassBreaksRendererMinSize = (Double)nudClassBreaksMinSize.Value;
        }

        private void nudClassBreaksMaxSize_ValueChanged(object sender, EventArgs e)
        {
            Double tmpSize = (Double)nudClassBreaksMaxSize.Value;
            if (tmpSize < _mClassBreaksRendererMinSize)
            {
                MessageBox.Show(@"终止尺寸必须大于起始尺寸,请重新设置!");
                return;
            }

            _mClassBreaksRendererMaxSize = tmpSize;
        }
    }
}
