using System;
using System.Drawing;
using System.Windows.Forms;

namespace GISBox.Forms
{
    public partial class LabelForm : Form
    {
        #region 字段

        private Color mColor = Color.Black;
        private Font mFont = new Font("宋体", 12);
        private int mFieldIndex = 0;
        private bool mUseMask = false;
        private bool mVisible = false;

        #endregion

        #region Constructors
        public LabelForm(MyMapObjects.moMapLayer layer)
        {
            InitializeComponent();
            int sFieldCount = layer.AttributeFields.Count;
            for (int i = 0; i < sFieldCount; i++)
            {
                cboField.Items.Add(layer.AttributeFields.GetItem(i).Name);
            }
            cboField.SelectedIndex = 0;
            MyMapObjects.moLabelRenderer sLabelRenderer = layer.LabelRenderer;
            if (sLabelRenderer != null)
            {
                cboField.SelectedIndex = layer.AttributeFields.FindField(sLabelRenderer.Field);
                btnFontColor.BackColor = sLabelRenderer.TextSymbol.FontColor;
                mColor = sLabelRenderer.TextSymbol.FontColor;
                btnFont.Text = sLabelRenderer.TextSymbol.Font.Name;
                mFont = sLabelRenderer.TextSymbol.Font;
                mUseMask = sLabelRenderer.TextSymbol.UseMask;
                chbMask.Checked = sLabelRenderer.TextSymbol.UseMask;
                mVisible = sLabelRenderer.LabelFeatures;
                chbVisible.Checked = sLabelRenderer.LabelFeatures;
                labelFontSize.Text = Convert.ToString(mFont.Size);
            }

        }

        #endregion


        #region 窗体操作
        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            mFieldIndex = cboField.SelectedIndex;
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldLabel.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                mColor = cldLabel.Color;
                btnFontColor.BackColor = mColor;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            DialogResult sFontDialogResult = labelFontDialog.ShowDialog();
            if (sFontDialogResult == DialogResult.OK)
            {
                mFont = labelFontDialog.Font;
                btnFont.Font = mFont;
                btnFont.Text = mFont.Name;
                labelFontSize.Text = Convert.ToString(mFont.Size);
            }
        }

        private void chbMask_CheckedChanged(object sender, EventArgs e)
        {
            if(chbMask.Checked)
            {
                mUseMask = true;
            }
            else
            {
                mUseMask = false; 
            }
        }

        private void chbVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVisible.Checked)
            {
                mVisible = true;
            }
            else
            {
                mVisible = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MainForm main = (MainForm)Owner;
            main.Label.GetLabel(mVisible, mUseMask, mFieldIndex, mColor, mFont);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
