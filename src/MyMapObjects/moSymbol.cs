namespace MyMapObjects
{
    // 符号
    public abstract class moSymbol
    {
        public abstract moSymbolTypeConstant SymbolType { get; } //抽象属性：获取符号类型

        public abstract moSymbol Clone(); //抽象Methods：克隆
    }
}