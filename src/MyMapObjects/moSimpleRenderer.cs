namespace MyMapObjects
{
    // 单一符号渲染，或称简单渲染
    public class moSimpleRenderer : moRenderer
    {
        #region 字段

        private moSymbol _Symbol;

        #endregion 字段

        #region Constructors

        public moSimpleRenderer()
        {
        }

        #endregion Constructors

        #region 属性

        public override moRendererTypeConstant RendererType => moRendererTypeConstant.Simple;

        public moSymbol Symbol
        {
            get => _Symbol;
            set => _Symbol = value;
        }

        #endregion 属性

        #region Methods

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

        #endregion Methods
    }
}