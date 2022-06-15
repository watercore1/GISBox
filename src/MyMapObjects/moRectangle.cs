namespace MyMapObjects
{
    // 自定义的矩形
    public class moRectangle : moShape
    {
        #region 字段

        private double _MinX, _MinY, _MaxX, _MaxY;

        #endregion 字段

        #region 构造函数

        public moRectangle(double minX, double maxX, double minY, double maxY)
        {
            _MinX = minX;
            _MaxX = maxX;
            _MinY = minY;
            _MaxY = maxY;
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        /// <summary>
        /// 获取最小Y坐标
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最大X坐标
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最大Y坐标
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        /// <summary>
        /// 获取矩形宽度
        /// </summary>
        public double Width
        {
            get { return _MaxX - _MinX; }
        }

        /// <summary>
        /// 获取矩形高度
        /// </summary>
        public double Height
        {
            get { return _MaxY - _MinY; }
        }

        /// <summary>
        /// 判断矩形是否为空矩形
        /// </summary>
        public bool IsEmpty
        {
            get { return _MaxX <= _MinX || _MaxY <= _MinY; }
        }

        #endregion 属性
    }
}