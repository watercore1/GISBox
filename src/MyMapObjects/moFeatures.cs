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

        #region Constructors

        public moFeatures()
        {
            _Features = new List<moFeature>();
        }

        #endregion Constructors

        #region 属性

        public int Count => _Features.Count;

        #endregion 属性

        #region Methods

        public moFeature GetItem(int index)
        {
            return _Features[index];
        }

        public void SetItem(int index, moFeature feature)
        {
            _Features[index] = feature;
        }

        public void Add(moFeature feature)
        {
            _Features.Add(feature);
        }

        public void RemoveAt(int index)
        {
            _Features.RemoveAt(index);
        }

        // <summary>
        /// 获取该要素所处的位置
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public int Find(moFeature feature)
        {
            object[] temp = feature.Attributes.ToArray();
            object[] temp1;
            bool judge = true;
            for (int i = 0; i < this.Count; i++)
            {
                temp1 = this.GetItem(i).Attributes.ToArray();
                for (int j = 0; j < this.GetItem(i).Attributes.Count; j++)
                {
                    if (temp1[j] != temp[j])
                    {
                        judge = false;
                        break;
                    }
                }
                if (judge == true)
                    return i;
                judge = true;
            }
            return -1;
        }

        /// <summary>
        /// 清除所有元素
        /// </summary>
        public void Clear()
        {
            _Features.Clear();
        }

        #endregion Methods
    }
}