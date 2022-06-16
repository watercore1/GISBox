using System;
using System.Drawing;
using System.Security.Cryptography;

namespace MyMapObjects
{
    // 简单点符号
    public class moSimpleMarkerSymbol : moSymbol
    {
        #region 字段

        private string _Label = ""; //符号标签
        private bool _Visible = true; //是否可见
        private moSimpleMarkerSymbolStyleConstant _Style = moSimpleMarkerSymbolStyleConstant.SolidCircle; //形状，为了和moMapDrawingTools契合，默认为实心圆
        private Color _Color = Color.LightPink; //颜色
        private double _Size = 3; //尺寸，默认单位为毫米

        #endregion 字段

        #region 构造函数

        public moSimpleMarkerSymbol()
        {
            CreateRandomColor();
        }

        /// <summary>
        /// 给定符号标签
        /// </summary>
        /// <param name="label">符号标签</param>
        public moSimpleMarkerSymbol(string label)
        {
            _Label = label;
            CreateRandomColor();
        }

        #endregion 构造函数

        #region 属性

        public override moSymbolTypeConstant SymbolType
        {
            get { return moSymbolTypeConstant.SimpleMarkerSymbol; }
        }

        public string Label
        {
            get { return _Label; }
            set { _Label = value; }
        }

        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        /// <summary>
        /// 获取或设置简单点符号的形状类型
        /// </summary>
        public moSimpleMarkerSymbolStyleConstant Style
        {
            get { return _Style; }
            set { _Style = value; }
        }

        /// <summary>
        /// 获取或设置简单点符号的颜色
        /// </summary>
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        /// <summary>
        /// 获取或设置简单点符号的尺寸
        /// </summary>
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public override moSymbol Clone()
        {
            moSimpleMarkerSymbol sSymbol = new moSimpleMarkerSymbol();
            sSymbol._Label = _Label;
            sSymbol._Visible = _Visible;
            sSymbol._Style = _Style;
            sSymbol._Color = _Color;
            sSymbol._Size = _Size;
            return sSymbol;
        }

        #endregion 方法

        #region 私有函数

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        private void CreateRandomColor()
        {
            //总体思想：每个随机颜色RGB中总有一个为252，其他两个值的取值范围为179-245，这样取值的目的在于让地图颜色偏浅，美观（其实比较适合面状符号）
            //生成4个元素的字节数组，第一个值决定哪个通道取252，另外三个中的两个值决定另外两个通道的值
            byte[] sBytes = new byte[4];
            RNGCryptoServiceProvider sChanelRng = new RNGCryptoServiceProvider();
            sChanelRng.GetBytes(sBytes);
            int sChanelValue = sBytes[0];
            byte A = 255, R, G, B;
            if (sChanelValue <= 85)
            {
                R = 252;
                G = (byte)(179 + 66 * sBytes[2] / 255);
                B = (byte)(179 + 66 * sBytes[3] / 255);
            }
            else if (sChanelValue <= 170)
            {
                G = 252;
                R = (byte)(179 + 66 * sBytes[1] / 255);
                B = (byte)(179 + 66 * sBytes[3] / 255);
            }
            else
            {
                B = 252;
                R = (byte)(179 + 66 * sBytes[1] / 255);
                G = (byte)(179 + 66 * sBytes[2] / 255);
            }
            _Color = Color.FromArgb(A, R, G, B);
        }

        #endregion 私有函数
    }
}