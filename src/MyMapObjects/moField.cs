using System;

namespace MyMapObjects
{
    // 字段
    public class moField
    {
        #region 字段

        private string _Name = ""; //字段名称
        private string _AliasName = ""; //字段别名
        private moValueTypeConstant _ValueType = moValueTypeConstant.dInt32; //字段类型
        private int _Length = 0; //字段长度，因为对于一些数据库系统，对字段长度有所限制，注意不是字段名的长度，是字段所储存的数据长度

        #endregion 字段

        #region 构造函数

        public moField(string name)
        {
            _Name = name;
            _AliasName = name;
        }

        public moField(string name, moValueTypeConstant valueType)
        {
            _Name = name;
            _AliasName = name;
            _ValueType = valueType;
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 获取字段名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        public string AliasName
        {
            get { return _AliasName; }
            set { _AliasName = value; }
        }

        public moValueTypeConstant ValueType
        {
            get { return _ValueType; }
        }

        public int Length
        {
            get { return _Length; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moField Clone()
        {
            moField sField = new moField(_Name, _ValueType);
            sField._AliasName = _AliasName;
            sField._Length = _Length;
            return sField;
        }

        #endregion 方法
    }
}