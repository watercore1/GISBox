﻿using System;
using System.Collections.Generic;

namespace MyMapObjects
{
    // 点集，即点的集合
    public class moPoints
    {
        #region 字段

        private List<moPoint> _Points; //点集合
        private double _MinX = double.MaxValue;
        private double _MaxX = double.MinValue;
        private double _MinY = double.MaxValue;
        private double _MaxY = double.MinValue;

        #endregion 字段

        #region 构造函数

        public moPoints()
        {
            _Points = new List<moPoint>();
        }

        public moPoints(moPoint[] points)
        {
            _Points = new List<moPoint>();
            _Points.AddRange(points);
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 获取点数目
        /// </summary>
        public int Count
        {
            get { return _Points.Count; }
        }

        /// <summary>
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        /// <summary>
        /// 获取最大X坐标
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最小Y坐标
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最大Y坐标
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 根据指定索引号返回点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moPoint GetItem(int index)
        {
            return _Points[index];
        }

        /// <summary>
        /// 在末尾增加一个点
        /// </summary>
        /// <param name="point"></param>
        public void Add(moPoint point)
        {
            _Points.Add(point);
        }

        /// <summary>
        /// 将指定数组中的元素添加到末尾（添加若干个点）
        /// </summary>
        /// <param name="points"></param>
        public void AddRange(moPoint[] points)
        {
            _Points.AddRange(points);
        }

        /// <summary>
        /// 将指定数组中的元素插入到指定索引号
        /// </summary>
        /// <param name="index"></param>
        /// <param name="points"></param>
        public void InsertRange(int index, moPoint[] points)
        {
            _Points.InsertRange(index, points);
        }

        /// <summary>
        /// 将指定元素插入到指定索引号
        /// </summary>
        /// <param name="index"></param>
        /// <param name="point"></param>
        public void Insert(int index, moPoint point)
        {
            _Points.Insert(index, point);
        }

        /// <summary>
        /// 删除指定索引号的元素
        /// </summary>
        public void RemoveAt(int index)
        {
            _Points.RemoveAt(index);
        }

        /// <summary>
        /// 将所有元素复制到一个新的数组中
        /// </summary>
        /// <returns></returns>
        public moPoint[] ToArray()
        {
            return _Points.ToArray();
        }

        /// <summary>
        /// 删除所有元素
        /// </summary>
        public void Clear()
        {
            _Points.Clear();
        }

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        /// <returns></returns>
        public moRectangle GetEnvelope()
        {
            moRectangle sRect = new moRectangle(_MinX, _MaxX, _MinY, _MaxY);
            return sRect;
        }

        /// <summary>
        /// 更新范围
        /// </summary>
        public void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moPoints Clone()
        {
            moPoints sPoints = new moPoints();
            int sPointCount = _Points.Count;
            for (int i = 0; i <= sPointCount - 1; i++)
            {
                moPoint sPoint = new moPoint(_Points[i].X, _Points[i].Y);
                sPoints.Add(sPoint);
            }
            sPoints._MinX = _MinX;
            sPoints._MaxX = _MaxX;
            sPoints._MinY = _MinY;
            sPoints._MaxY = _MaxY;
            return sPoints;
        }

        #endregion 方法

        #region 私有函数

        //计算范围
        private void CalExtent()
        {
            double sMinX = double.MaxValue;
            double sMaxX = double.MinValue;
            double sMinY = double.MaxValue;
            double sMaxY = double.MinValue;
            int sPointCount = _Points.Count;
            for (int i = 0; i <= sPointCount - 1; i++)
            {
                if (_Points[i].X < sMinX)
                    sMinX = _Points[i].X;
                if (_Points[i].X > sMaxX)
                    sMaxX = _Points[i].X;
                if (_Points[i].Y < sMinY)
                    sMinY = _Points[i].Y;
                if (_Points[i].Y > sMaxY)
                    sMaxY = _Points[i].Y;
            }
            _MinX = sMinX;
            _MaxX = sMaxX;
            _MinY = sMinY;
            _MaxY = sMaxY;
        }

        #endregion 私有函数
    }
}