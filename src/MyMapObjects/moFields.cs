using System;
using System.Collections.Generic;

namespace MyMapObjects
{
    // 字段集合
    public class moFields
    {
        #region 字段

        private List<moField> _Fields; //字段集合
        private string _PrimaryField = ""; //主字段名称，为了应用程序方便，用主字段的值标识选中的要素
        private bool _ShowAlias = false; //是否显示别名，为了应用程序方便，确定二维表列头是否显示别名，方便用户辨识

        #endregion 字段

        #region Constructors

        public moFields()
        {
            _Fields = new List<moField>();
        }

        #endregion Constructors

        #region 属性

        /// <summary>
        /// 获取字段集中元素的数目（字段的数目）
        /// </summary>
        public int Count => _Fields.Count;

        /// <summary>
        /// 获取或设置主字段
        /// </summary>
        public string PrimaryField
        {
            get => _PrimaryField;
            set => _PrimaryField = value;
        }

        /// <summary>
        /// 指示是否显示别名
        /// </summary>
        public bool ShowAlias
        {
            get => _ShowAlias;
            set => _ShowAlias = value;
        }

        #endregion 属性

        #region Methods

        /// <summary>
        /// 查找指定名称的字段，并返回其索引号，如无，则返回-1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FindField(string name)
        {
            int sFieldCount = _Fields.Count;
            for (int i = 0; i <= sFieldCount - 1; i++)
            {
                //字段名不区分大小写
                if (_Fields[i].Name.ToLower() == name.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取指定索引号的字段
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moField GetItem(int index)
        {
            return _Fields[index];
        }

        /// <summary>
        /// 获取指定名称的字段
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public moField GetItem(string name)
        {
            int sIndex = FindField(name);
            if (sIndex >= 0)
                return _Fields[sIndex];
            else
                return null;
        }

        /// <summary>
        /// 在字段集末尾追加一个字段
        /// </summary>
        /// <param name="field"></param>
        public void Append(moField field)
        {
            if (FindField(field.Name) >= 0)
            {
                string sMessage = MyMapObjects.Properties.Resources.String001;
                throw new Exception(sMessage);
            }

            _Fields.Add(field);

            //触发事件
            if (FieldAppended != null)
                FieldAppended(this, field);
        }

        /// <summary>
        /// 删除指定索引号的字段
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            moField sField = _Fields[index];
            _Fields.RemoveAt(index);

            //触发事件
            if (FieldRemoved != null)
                FieldRemoved(this, index, sField);
        }

        #endregion Methods

        #region 事件 放出消息，广播，由Layer监听

        internal delegate void FieldAppendedHandle(object sender, moField fieldAppended);

        /// <summary>
        /// 有字段被加入了
        /// </summary>
        internal event FieldAppendedHandle FieldAppended;

        internal delegate void FieldRemovedHandle(object sender, int fieldIndex, moField fieldRemoved);

        /// <summary>
        /// 有字段被删除了
        /// </summary>
        internal event FieldRemovedHandle FieldRemoved;

        #endregion 事件 放出消息，广播，由Layer监听
    }
}