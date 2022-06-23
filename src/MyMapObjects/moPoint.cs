namespace MyMapObjects
{
    // 点
    public class moPoint : moGeometry
    {
        #region 字段

        private double _X;
        private double _Y;

        #endregion 字段

        #region Constructors

        public moPoint()
        { }

        public moPoint(double x, double y)
        {
            _X = x;
            _Y = y;
        }

        #endregion Constructors

        #region 属性

        /// <summary>
        /// 设置或获取X坐标
        /// </summary>
        public double X
        {
            get => _X;
            set => _X = value;
        }

        /// <summary>
        /// 设置或获取Y坐标
        /// </summary>
        public double Y
        {
            get => _Y;
            set => _Y = value;
        }

        #endregion 属性

        #region Methods

        /// <summary>
        /// 克隆一个点
        /// </summary>
        /// <returns></returns>
        public moPoint Clone()
        {
            moPoint sPoint = new moPoint(_X, _Y); //s表示sub，过程级，函数级
            return sPoint;
        }

        #endregion Methods
    }
}