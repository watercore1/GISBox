using System;

namespace MyMapObjects
{
    // 复合多边形，或称多多边形
    public class moMultiPolygon : moGeometry
    {
        #region 字段

        private moParts _Parts;
        private double _MinX = double.MaxValue;
        private double _MaxX = double.MinValue;
        private double _MinY = double.MaxValue;
        private double _MaxY = double.MinValue;

        #endregion 字段

        #region 构造函数

        public moMultiPolygon()
        {
            _Parts = new moParts();
        }

        public moMultiPolygon(moPoints points)
        {
            _Parts = new moParts();
            _Parts.Add(points);
        }

        public moMultiPolygon(moParts parts)
        {
            _Parts = parts;
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 获取或设置部件集合
        /// </summary>
        public moParts Parts
        {
            get { return _Parts; }
            set { _Parts = value; }
        }

        /// <summary>
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        public double MaxX
        {
            get { return _MaxX; }
        }

        public double MinY
        {
            get { return _MinY; }
        }

        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion 属性

        #region 方法

        public moRectangle GetEnvelope()
        {
            moRectangle sRect = new moRectangle(_MinX, _MaxX, _MinY, _MaxY);
            return sRect;
        }

        public void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moMultiPolygon Clone()
        {
            moMultiPolygon sMultiPolygon = new moMultiPolygon();
            sMultiPolygon.Parts = _Parts.Clone();
            sMultiPolygon._MinX = _MinX;
            sMultiPolygon._MaxX = _MaxX;
            sMultiPolygon._MinY = _MinY;
            sMultiPolygon._MaxY = _MaxY;
            return sMultiPolygon;
        }

        #endregion 方法

        #region 私有函数

        //计算坐标范围
        private void CalExtent()
        {
            double sMinX = double.MaxValue, sMaxX = double.MinValue;
            double sMinY = double.MaxValue, sMaxY = double.MinValue;
            int sPartCount = _Parts.Count;
            for (int i = 0; i <= sPartCount - 1; i++)
            {
                _Parts.GetItem(i).UpdateExtent();
                if (_Parts.GetItem(i).MinX < sMinX)
                    sMinX = _Parts.GetItem(i).MinX;
                if (_Parts.GetItem(i).MaxX > sMaxX)
                    sMaxX = _Parts.GetItem(i).MaxX;
                if (_Parts.GetItem(i).MinY < sMinY)
                    sMinY = _Parts.GetItem(i).MinY;
                if (_Parts.GetItem(i).MaxY > sMaxY)
                    sMaxY = _Parts.GetItem(i).MaxY;
            }
            _MinX = sMinX;
            _MaxX = sMaxX;
            _MinY = sMinY;
            _MaxY = sMaxY;
        }

        #endregion 私有函数
    }
}