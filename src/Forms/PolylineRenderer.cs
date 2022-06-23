using System;
using System.Drawing;
using System.Windows.Forms;

namespace GISBox.Forms
{
    public partial class PolylineRenderer : Form
    {
        #region 字段

        private int _mRendererMode; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染
        private int _mSymbolStyle; //样式索引
        //简单渲染参数
        private Color _mSimpleRendererColor = Color.LightCoral; //符号颜色
        private double _mSimpleRendererSize = 0.5; //符号尺寸
        //唯一值渲染参数
        private int _mUniqueFieldIndex; //绑定字段索引
        private double _mUniqueRendererSize = 0.5; //符号尺寸
        //分级渲染参数
        private int _mClassBreaksFieldIndex; //绑定字段索引
        private int _mClassBreaksNum = 5; //分类数
        private Color _mClassBreaksRendererColor = Color.LightCoral; //符号颜色
        private double _mClassBreaksRendererMinSize = 0.5; //符号起始尺寸,线图层采用符号宽度进行分级表示
        private double _mClassBreaksRendererMaxSize = 1.5; //符号终止尺寸

        #endregion

        #region Constructors
        public PolylineRenderer(MyMapObjects.moMapLayer layer)
        {
            InitializeComponent();
            cboStyle.Items.Add("Solid");
            cboStyle.Items.Add("Dash");
            cboStyle.Items.Add("Dot");
            cboStyle.Items.Add("DashDot");
            cboStyle.Items.Add("DashDotDot");

            int fieldCount = layer.AttributeFields.Count;
            for (int i = 0; i <= fieldCount - 1; i++)
            {
                
                cboClassBreaksField.Items.Add(layer.AttributeFields.GetItem(i).Name);
            }
            cboStyle.SelectedIndex = 0;
            cboClassBreaksField.SelectedIndex = 0;
            if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.Simple)
            {
                MyMapObjects.moSimpleRenderer sRenderer = (MyMapObjects.moSimpleRenderer)layer.Renderer;
                MyMapObjects.moSimpleLineSymbol sSymbol = (MyMapObjects.moSimpleLineSymbol)sRenderer.Symbol;
                cboStyle.SelectedIndex = (int)sSymbol.Style;
                _mSimpleRendererColor = sSymbol.Color;
                nudSimpleSize.Value = Convert.ToDecimal(sSymbol.Size);
                rbtnSimple.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.UniqueValue)
            {
                MyMapObjects.moUniqueValueRenderer sRenderer = (MyMapObjects.moUniqueValueRenderer)layer.Renderer;
                MyMapObjects.moSimpleLineSymbol sSymbol = (MyMapObjects.moSimpleLineSymbol)sRenderer.GetSymbol(0);
                cboStyle.SelectedIndex = (int)sSymbol.Style;
                rbtnUniqueValue.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.ClassBreaks)
            {
                MyMapObjects.moClassBreaksRenderer sRenderer = (MyMapObjects.moClassBreaksRenderer)layer.Renderer;

                MyMapObjects.moSimpleLineSymbol sStartSymbol = (MyMapObjects.moSimpleLineSymbol)sRenderer.GetSymbol(0);
                MyMapObjects.moSimpleLineSymbol sEndSymbol = (MyMapObjects.moSimpleLineSymbol)sRenderer.GetSymbol(sRenderer.BreakCount - 1);
                cboStyle.SelectedIndex = (int)sStartSymbol.Style;
                btnClassBreaksColor.BackColor = sStartSymbol.Color;
                _mClassBreaksRendererColor = sStartSymbol.Color;
                cboClassBreaksField.SelectedIndex = layer.AttributeFields.FindField(sRenderer.Field);
                nudClassBreaksNum.Value = sRenderer.BreakCount;
                nudClassBreaksMinSize.Value = Convert.ToDecimal(sStartSymbol.Size);
                nudClassBreaksMaxSize.Value = Convert.ToDecimal(sEndSymbol.Size);
                rbtnClassBreaks.Checked = true;
                rbtnClassBreaks.Checked = true;
            }

            SetEnabled();
        }

        #endregion

        #region 窗体操作

        private void SetEnabled()
        {
            if (rbtnSimple.Checked)
            {
                nudSimpleSize.Enabled = true;
                cboClassBreaksField.Enabled = false;
                nudClassBreaksNum.Enabled = false;
                btnClassBreaksColor.Enabled = true;
                nudClassBreaksMinSize.Enabled = false;
                nudClassBreaksMaxSize.Enabled = false;
            }
            else if (rbtnUniqueValue.Checked)
            {
                nudSimpleSize.Enabled = true;
                cboClassBreaksField.Enabled = true;
                nudClassBreaksNum.Enabled = false;
                btnClassBreaksColor.Enabled = false;
                nudClassBreaksMinSize.Enabled = false;
                nudClassBreaksMaxSize.Enabled = false;
            }
            else if (rbtnClassBreaks.Checked)
            {
                nudSimpleSize.Enabled = false;
                cboClassBreaksField.Enabled = true;
                nudClassBreaksNum.Enabled = true;
                btnClassBreaksColor.Enabled = true;
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
            _mSimpleRendererSize = (double)nudSimpleSize.Value;
            _mUniqueRendererSize = (double)nudSimpleSize.Value;
        }


        //选择分级渲染字段
        private void cboClassBreaksField_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mClassBreaksFieldIndex = cboClassBreaksField.SelectedIndex;
            _mUniqueFieldIndex = cboClassBreaksField.SelectedIndex;
        }

        //选择分级渲染分级数
        private void nudClassBreaksNum_ValueChanged(object sender, EventArgs e)
        {
            _mClassBreaksNum = (int)nudClassBreaksNum.Value;
        }

        //选择分级渲染符号颜色
        private void btnClassBreaksColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldPolylineRenderer.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                _mClassBreaksRendererColor = cldPolylineRenderer.Color;
                _mSimpleRendererColor = cldPolylineRenderer.Color;
                btnClassBreaksColor.BackColor = cldPolylineRenderer.Color;
            }
        }

        //选择分级渲染符号最小尺寸
        private void nudClassBreaksMinSize_ValueChanged(object sender, EventArgs e)
        {
            _mClassBreaksRendererMinSize = (double)nudClassBreaksMinSize.Value;
        }

        //选择分级渲染符号最大尺寸
        private void nudClassBreaksMaxSize_ValueChanged(object sender, EventArgs e)
        {
            double tmpSize = (double)nudClassBreaksMaxSize.Value;
            if (tmpSize < _mClassBreaksRendererMinSize)
            {
                MessageBox.Show(@"终止尺寸必须大于起始尺寸,请重新设置!");
                return;
            }

            _mClassBreaksRendererMaxSize = tmpSize;
        }

        //确认
        private void btnPolylineRendererConfirm_Click(object sender, EventArgs e)
        {
            MainForm main = (MainForm)Owner;
            GetRendererMode();
            main.Render.GetPolylineRenderer(_mRendererMode, _mSymbolStyle, _mSimpleRendererColor, _mSimpleRendererSize,
                _mUniqueFieldIndex, _mUniqueRendererSize, _mClassBreaksFieldIndex, _mClassBreaksNum,
                _mClassBreaksRendererColor, _mClassBreaksRendererMinSize, _mClassBreaksRendererMaxSize);
            Close();
        }

        //取消
        private void btnPolylineRendererCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


    }
}
