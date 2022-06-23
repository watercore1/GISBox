using System;
using System.Collections.Generic;

namespace MyMapObjects
{
    // 唯一值渲染
    public class moUniqueValueRenderer : moRenderer
    {
        #region 字段

        private string _Field = ""; //绑定字段
        private string _HeadTitle = ""; //在图层显示控件中的标题
        private bool _ShowHead = true; //在图层显示控件中是否显示标题
        private List<string> _Values = new List<string>(); //唯一值列表
        private List<moSymbol> _Symbols = new List<moSymbol>(); //符号列表，与唯一值列表对应
        private moSymbol _DefaultSymbol; //默认符号
        private bool _ShowDefaultSymbol = true; //在图层显示控件中是否显示默认符号

        #endregion 字段

        #region Constructors

        public moUniqueValueRenderer()
        {
        }

        #endregion Constructors

        #region 属性

        public override moRendererTypeConstant RendererType => moRendererTypeConstant.UniqueValue;

        /// <summary>
        /// 获取或设置唯一值的绑定字段
        /// </summary>
        public string Field
        {
            get => _Field;
            set => _Field = value;
        }

        /// <summary>
        /// 获取唯一值数目
        /// </summary>
        public int ValueCount => _Values.Count;

        /// <summary>
        /// 获取或设置默认符号
        /// </summary>
        public moSymbol DefaultSymbol
        {
            get => _DefaultSymbol;
            set => _DefaultSymbol = value;
        }

        //其他属性不再编写，自行添加

        #endregion 属性

        #region Methods

        /// <summary>
        /// 获取指定索引号的唯一值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetValue(int index)
        {
            return _Values[index];
        }

        /// <summary>
        /// 设置指定索引号的唯一值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetValue(int index, string value)
        {
            _Values[index] = value;
        }

        /// <summary>
        /// 获取指定索引号的符号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moSymbol GetSymbol(int index)
        {
            return _Symbols[index];
        }

        /// <summary>
        /// 设置指定索引号的符号
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        public void SetSymbol(int index, moSymbol symbol)
        {
            _Symbols[index] = symbol;
        }

        /// <summary>
        /// 增加一个唯一值以及对应符号
        /// </summary>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        public void AddUniqueValue(string value, moSymbol symbol)
        {
            _Values.Add(value);
            _Symbols.Add(symbol);
        }

        /// <summary>
        /// 增加唯一值数组和对应的符号数组
        /// </summary>
        /// <param name="values"></param>
        /// <param name="symbols"></param>
        public void AddUniqueValues(string[] values, moSymbol[] symbols)
        {
            if (values.Length != symbols.Length)
                throw new Exception("两个数组的长度不一致！");

            _Values.AddRange(values);
            _Symbols.AddRange(symbols);
        }

        /// <summary>
        /// 根据指定的唯一值获得对应符号，若该值不存在则返回默认符号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public moSymbol FindSymbol(string value)
        {
            int sValueCount = _Values.Count;

            for (int i = 0; i < sValueCount; i++)
            {
                if (_Values[i] == value)
                    return _Symbols[i];
            }

            return _DefaultSymbol;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public override moRenderer Clone()
        {
            moUniqueValueRenderer sRenderer = new moUniqueValueRenderer();
            sRenderer._Field = _Field;
            sRenderer._HeadTitle = _HeadTitle;
            sRenderer._ShowHead = _ShowHead;
            int sValueCount = _Values.Count;
            for (int i = 0; i <= sValueCount - 1; i++)
            {
                string sValue = _Values[i];
                moSymbol sSymbol = null;
                if (_Symbols[i] != null)
                    sSymbol = _Symbols[i].Clone();
                sRenderer.AddUniqueValue(sValue, sSymbol);
            }
            if (_DefaultSymbol != null)
                sRenderer.DefaultSymbol = _DefaultSymbol.Clone();
            sRenderer._ShowDefaultSymbol = _ShowDefaultSymbol;
            return sRenderer;
        }

        #endregion Methods
    }
}