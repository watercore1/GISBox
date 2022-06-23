using System;
using System.Drawing;

namespace GISBox.MapVariable
{
    public class LabelVariable
    {
        internal Color mLabelColor = Color.Black;
        internal Font mLabelFont = new Font("宋体", 12);
        internal Int32 mLabelFieldIndex = 0;
        internal bool mLabelUseMask = false;
        internal bool mLabelVisible = false;

        public LabelVariable()
        {

        }

        public void GetLabel(bool visible, bool useMask, Int32 fieldIndex, Color color, Font font)
        {
            mLabelVisible = visible;
            mLabelUseMask = useMask;
            mLabelFieldIndex = fieldIndex;
            mLabelColor = color;
            mLabelFont = font;
        }
    }
}