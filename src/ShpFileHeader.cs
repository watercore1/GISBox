using System;
using System.IO;

namespace GISBox
{
    /// <summary>
    /// shp 文件头
    /// </summary>
    public class ShpFileHeader
    {
        #region 字段

        private byte[] _reserved1;    //字节0-31：保留字节，大端序
        private ShapeFileType _shapeFileType;   //字节32-35：要素类型
        private double _minX;       //字节36-43
        private double _minY;       //字节52-59
        private double _maxX;       //字节44-51
        private double _maxY;       //字节60-67
        private byte[] _reserved2;  //字节68-99：保留字节


        #endregion

        #region 构造函数

        public ShpFileHeader(BinaryReader br)
        {
            _reserved1 = br.ReadBytes(32);
            _shapeFileType = (ShapeFileType)br.ReadUInt32();
            _minX = br.ReadDouble();
            _minY = br.ReadDouble();
            _maxX = br.ReadDouble();
            _maxY = br.ReadDouble();
            _reserved2 = br.ReadBytes(32);
        }

        #endregion

        #region 属性


        /// <summary>
        /// 获取shp约定的要素几何类型
        /// </summary>
        public ShapeFileType ShapeFileType => _shapeFileType;

        /// <summary>
        /// 获取最小外包矩形的MinX
        /// </summary>
        public double MinX => _minX;

        /// <summary>
        /// 获取最小外包矩形的MaxX
        /// </summary>
        public double MaxX => _maxX;

        /// <summary>
        /// 获取最小外包矩形的MinY
        /// </summary>
        public double MinY => _minY;

        /// <summary>
        /// 获取最小外包矩形的MaxY
        /// </summary>
        public double MaxY => _maxY;

        #endregion

        #region 方法

        public MyMapObjects.moGeometryTypeConstant GetMoGeometryType()
        {
            MyMapObjects.moGeometryTypeConstant moGeometryType;
            switch (_shapeFileType)
            {
                case ShapeFileType.Point:
                    moGeometryType = MyMapObjects.moGeometryTypeConstant.Point;
                    break;
                case ShapeFileType.PolyLine:
                    moGeometryType = MyMapObjects.moGeometryTypeConstant.MultiPolyline;
                    break;
                case ShapeFileType.Polygon:
                    moGeometryType = MyMapObjects.moGeometryTypeConstant.MultiPolygon;
                    break;
                default:
                    {
                        string msg = "不支持该 ShapeFile 类型数据";
                        throw new NotSupportedException(msg);
                    }
            }
            return moGeometryType;
        }
        #endregion
    }
}
