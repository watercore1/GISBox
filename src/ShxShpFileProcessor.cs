using System;
using System.Collections.Generic;
using System.IO;
using MyMapObjects;

namespace GISBox
{

    /// <summary>
    /// 读取 shx 文件 和 shp 文件
    /// 并对数据进行管理
    /// </summary>
    public class ShxShpFileProcessor
    {
        #region 字段
        //(1) 文件头数据 
        private ShxFileProcessor _shxFileProcessor;
        private ShpFileHeader _shpFileHeader;
        //(2) MyMapObjects 格式的要素类型和要素地理数据
        private moGeometryTypeConstant _geometryType;
        private List<moGeometry> _geometries = new List<moGeometry>();


        #endregion

        #region 构造函数

        /// <summary>
        /// 读取 .shx 文件和 .shp 文件数据
        /// </summary>
        /// <param name="shpFilePath">.shp 文件的文件路径</param>
        public ShxShpFileProcessor(string shpFilePath)
        {
            //(1) 读取 .shx 文件
            string shxFilePath = shpFilePath.Substring(0, shpFilePath.IndexOf(".shp", StringComparison.Ordinal)) + ".shx";
            FileStream shxFs = new FileStream(shxFilePath, FileMode.Open);
            BinaryReader shxBr = new BinaryReader(shxFs);
            _shxFileProcessor = new ShxFileProcessor(shxBr);

            //(2) 读取 .shp 文件
            FileStream shpFs = new FileStream(shpFilePath, FileMode.Open);
            BinaryReader shpBr = new BinaryReader(shpFs);
            _shpFileHeader = new ShpFileHeader(shpBr);

            //(3) 获取要素类型
            _geometryType = _shpFileHeader.GetMoGeometryType();
            //(4) 读取要素地理数据
            for(int i = 0; i < _shxFileProcessor.RecordCount; ++i)
            {
                shpBr.BaseStream.Seek(_shxFileProcessor.RecordOffsets[i], SeekOrigin.Begin);
                ReadEachRecordOfShapeFile(shpBr);
            }

            shxFs.Dispose();
            shxBr.Dispose();
            shpFs.Dispose();
            shpBr.Dispose();
        }

        #endregion

        #region 属性
        public moGeometryTypeConstant GeometryType { get => _geometryType; set => _geometryType = value; }
        public List<moGeometry> Geometries { get => _geometries; set => _geometries = value; }

        #endregion

        #region 私有函数

        /// <summary>
        /// 从文件中读取 point polyline polygon 三种类型
        /// </summary>
        /// <param name="br"></param>
        private void ReadEachRecordOfShapeFile(BinaryReader br)
        {
            //Record Header
            br.ReadBytes(8);
            //ShapeType
            uint sShapeType = br.ReadUInt32();
            //根据ShapeType读取对应的数据类型
            switch (sShapeType)
            {
                case (uint)ShapeFileType.Point:
                    ReadShpPoint(br);
                    break;
                case (int)ShapeFileType.PolyLine:
                    ReadShpPolyLine(br);
                    break;
                case (int)ShapeFileType.Polygon:
                    ReadShpPolygon(br);
                    break;
                default:
                    {
                        string error = "不支持该 ShapeFile 类型数据";
                        throw new NotSupportedException(error);
                    }
            }
        }

        /// <summary>
        /// 从文件读取 point 并转换为 moPoint
        /// </summary>
        /// <param name="br"></param>
        private void ReadShpPoint(BinaryReader br)
        {
            double x = br.ReadDouble();
            double y = br.ReadDouble();
            moPoint point = new moPoint(x, y);
            _geometries.Add(point);
        }

        /// <summary>
        /// 从文件读取 PolyLine 并转换为 moMultiPolyline
        /// </summary>
        /// <param name="br"></param>
        private void ReadShpPolyLine(BinaryReader br)
        {
            //(1) 读取边界盒参数
            br.ReadDouble();
            br.ReadDouble();
            br.ReadDouble();
            br.ReadDouble();

            //(2) 读取 NumParts 和 NumPoints
            var numParts = br.ReadInt32();
            var numPoints = br.ReadInt32();

            //(3) 读取每一部分的点在数组中的起始位置
            int[] partIndex = new int[numParts + 1];
            for (int i = 0; i < numParts; ++i)
            {
                partIndex[i] = br.ReadInt32();
            }
            partIndex[numParts] = numPoints;

            //(4) 构建 MultiPolyline
            moMultiPolyline multiPolyline = new moMultiPolyline();
            for(int i = 0; i < numParts; ++i)
            {
                //一条折线
                moPoints sPoints = new moPoints();
                for(int j = 0; j < partIndex[i + 1] - partIndex[i]; ++j)
                {
                    double x = br.ReadDouble();
                    double y = br.ReadDouble();
                    moPoint sPoint = new moPoint(x, y);
                    sPoints.Add(sPoint);
                }
                multiPolyline.Parts.Add(sPoints);
            }
            multiPolyline.UpdateExtent();
            _geometries.Add(multiPolyline);
        }

        /// <summary>
        /// 文件中读取 polygon 并转换为 moMultiPolygon
        /// </summary>
        /// <param name="br"></param>
        private void ReadShpPolygon(BinaryReader br)
        {
            //读取边界盒参数
            br.ReadDouble();
            br.ReadDouble();
            br.ReadDouble();
            br.ReadDouble();
            //读取NumParts和NumPoints
            int numParts = br.ReadInt32();
            int numPoints = br.ReadInt32();
            //读取每一部分的点在数组中的起始位置
            int[] partIndex = new int[numParts + 1];
            for (int i = 0; i < numParts; ++i)
            {
                partIndex[i] = br.ReadInt32();
            }
            partIndex[numParts] = numPoints;
            //构建MultiPolygon
            moMultiPolygon multiPolygon = new moMultiPolygon();
            for(int i = 0; i < numParts; ++i)
            {
                moPoints points = new moPoints();
                for (int j = 0; j < partIndex[i + 1] - partIndex[i]; ++j)
                {
                    double x = br.ReadDouble();
                    double y = br.ReadDouble();
                    moPoint point = new moPoint(x, y);
                    points.Add(point);
                }
                multiPolygon.Parts.Add(points);
            }
            multiPolygon.UpdateExtent();
            _geometries.Add(multiPolygon);
        }

        #endregion
    }
}
