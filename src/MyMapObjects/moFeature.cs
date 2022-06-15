namespace MyMapObjects
{
    // 要素
    public class moFeature
    {
        #region 字段

        private moGeometryTypeConstant _ShapeType = moGeometryTypeConstant.MultiPolygon;
        private moGeometry _Geometry;
        private moAttributes _Attributes; //属性集合
        private moSymbol _Symbol; //符号

        #endregion 字段

        #region 构造函数

        public moFeature(moGeometryTypeConstant shapeType, moGeometry geometry, moAttributes attributes)
        {
            _ShapeType = shapeType;
            _Geometry = geometry;
            _Attributes = attributes;
        }

        #endregion 构造函数

        #region 属性

        public moGeometryTypeConstant ShapeType
        {
            get { return _ShapeType; }
            set { _ShapeType = value; }
        }

        public moGeometry Geometry
        {
            get { return _Geometry; }
            set { _Geometry = value; }
        }

        /// <summary>
        /// 获取或设置属性集合
        /// </summary>
        public moAttributes Attributes
        {
            get { return _Attributes; }
            set { _Attributes = value; }
        }

        /// <summary>
        /// 获取或设置符号，只为了我们程序内部显示所用，外部不可访问
        /// </summary>
        internal moSymbol Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 获取要素的外包矩形（最小绑定矩形）
        /// </summary>
        /// <returns></returns>
        public moRectangle GetEnvelope()
        {
            moRectangle sRect = null;

            if (_ShapeType == moGeometryTypeConstant.Point)
            {
                moPoint sPoint = (moPoint)_Geometry;
                sRect = new moRectangle(sPoint.X, sPoint.X, sPoint.Y, sPoint.Y); //一个空矩形
            }
            else if (_ShapeType == moGeometryTypeConstant.MultiPolyline)
            {
                moMultiPolyline moMultiPolyline = (moMultiPolyline)_Geometry;
                sRect = moMultiPolyline.GetEnvelope();
            }
            else
            {
                moMultiPolygon moMultiPolygon = (moMultiPolygon)_Geometry;
                sRect = moMultiPolygon.GetEnvelope();
            }

            return sRect;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moFeature Clone()
        {
            moGeometryTypeConstant sShapeType = _ShapeType;
            moGeometry sGeometry = null;
            moAttributes sAttributes = _Attributes.Clone();
            if (_ShapeType == moGeometryTypeConstant.Point)
            {
                moPoint sPoint = (moPoint)_Geometry;
                sGeometry = sPoint.Clone();
            }
            else if (_ShapeType == moGeometryTypeConstant.MultiPolyline)
            {
                moMultiPolyline sMultiPolyline = (moMultiPolyline)_Geometry;
                sGeometry = sMultiPolyline.Clone();
            }
            else if (_ShapeType == moGeometryTypeConstant.MultiPolygon)
            {
                moMultiPolygon sMultiPolygon = (moMultiPolygon)_Geometry;
                sGeometry = sMultiPolygon.Clone();
            }
            moFeature sFeature = new moFeature(sShapeType, sGeometry, sAttributes);
            return sFeature;
        }

        #endregion 方法
    }
}