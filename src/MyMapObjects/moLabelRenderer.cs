namespace MyMapObjects
{
    // 注记渲染类型（注记配置规则描述）
    public class moLabelRenderer
    {
        #region 字段

        private bool _LabelFeatures = false; //是否标注
        private moTextSymbol _TextSymbol = new moTextSymbol(); //文本符号
        private string _Field = ""; //注记字段

        #endregion 字段

        #region 属性

        /// <summary>
        /// 指示是否为图层配置注记
        /// </summary>
        public bool LabelFeatures
        {
            get { return _LabelFeatures; }
            set { _LabelFeatures = value; }
        }

        /// <summary>
        /// 获取或设置注记符号
        /// </summary>
        public moTextSymbol TextSymbol
        {
            get { return _TextSymbol; }
            set { _TextSymbol = value; }
        }

        /// <summary>
        /// 获取或设置绑定字段
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        #endregion 属性
    }
}