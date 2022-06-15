using System;
using System.Collections.Generic;

namespace MyMapObjects
{
    // 要素集合
    public class moFeatures
    {
        #region 字段

        private List<moFeature> _Features;

        #endregion 字段

        #region 构造函数

        public moFeatures()
        {
            _Features = new List<moFeature>();
        }

        #endregion 构造函数

        #region 属性

        public Int32 Count
        {
            get { return _Features.Count; }
        }

        #endregion 属性

        #region 方法

        public moFeature GetItem(Int32 index)
        {
            return _Features[index];
        }

        public void SetItem(Int32 index, moFeature feature)
        {
            _Features[index] = feature;
        }

        public void Add(moFeature feature)
        {
            _Features.Add(feature);
        }

        public void RemoveAt(Int32 index)
        {
            _Features.RemoveAt(index);
        }

        /// <summary>
        /// 清除所有元素
        /// </summary>
        public void Clear()
        {
            _Features.Clear();
        }

        #endregion 方法
    }
}