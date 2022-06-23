namespace MyMapObjects
{
    public abstract class moRenderer
    {
        public abstract moRendererTypeConstant RendererType { get; } //抽象属性：获取渲染类型

        public abstract moRenderer Clone(); //抽象Methods：克隆
    }
}