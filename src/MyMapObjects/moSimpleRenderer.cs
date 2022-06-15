namespace MyMapObjects
{
    // 单一符号渲染，或称简单渲染
    public class moSimpleRenderer : moRenderer
    {
        #region 字段

        private moSymbol _Symbol;

        #endregion 字段

        #region 构造函数

        public moSimpleRenderer()
        {
        }

        #endregion 构造函数

        #region 属性

        public override moRendererTypeConstant RendererType
        {
            get { return moRendererTypeConstant.Simple; }
        }

        public moSymbol Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public override moRenderer Clone()
        {
            moSimpleRenderer sRenderer = new moSimpleRenderer();
            sRenderer._Symbol = Symbol.Clone();

            return sRenderer;
        }

        #endregion 方法
    }
}