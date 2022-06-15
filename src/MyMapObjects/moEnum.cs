namespace MyMapObjects
{
    // 所有的枚举

    /// <summary>
    /// 值类型常数
    /// </summary>
    public enum moValueTypeConstant
    {
        dInt16 = 0,
        dInt32 = 1,
        dInt64 = 2,
        dSingle = 3,
        dDouble = 4,
        dText = 5
    }

    /// <summary>
    /// 符号类型常数
    /// </summary>
    public enum moSymbolTypeConstant
    {
        SimpleMarkerSymbol = 0, //简单点符号
        SimpleLineSymbol = 1, //简单线符号
        SimpleFillSymbol = 2 //简单面符号
    }

    /// <summary>
    /// 简单点符号形状常数
    /// </summary>
    public enum moSimpleMarkerSymbolStyleConstant
    {
        Circle = 0, //圆
        SolidCircle = 1, //实心圆
        Triangle = 2,
        SolidTriangle = 3,
        Square = 4,
        SolidSquare = 5,
        CircleDot = 6, //圆加点
        CircleCircle = 7 //同心圆
    }

    /// <summary>
    /// 简单线符号形状常数
    /// </summary>
    public enum moSimpleLineSymbolStyleConstant
    {
        Solid = 0, //实线
        Dash = 1, //短棒线
        Dot = 2, //点线
        DashDot = 3,
        DashDotDot = 4
    }

    /// <summary>
    /// 几何类型常数
    /// </summary>
    public enum moGeometryTypeConstant
    {
        Point = 0,
        MultiPolyline = 1,
        MultiPolygon = 2
    }

    /// <summary>
    /// 渲染类型常数
    /// </summary>
    public enum moRendererTypeConstant
    {
        Simple = 0, //单一符号渲染法，或称简单渲染法
        UniqueValue = 1, //唯一值渲染法
        ClassBreaks = 2 //分级渲染法
    }

    /// <summary>
    /// 文本符号布局常数
    /// </summary>
    public enum moTextSymbolAlignmentConstant
    {
        TopLeft = 0,
        TopCenter = 1,
        TopRight = 2,
        CenterLeft = 3,
        CenterCenter = 4,
        CenterRight = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8
    }

    /// <summary>
    /// 投影类型常数，可扩充，现仅实现Lambert_Conformal_Conic_2SP
    /// </summary>
    public enum moProjectionTypeConstant
    {
        None = 0,
        Mercator = 1,
        UTM = 2,
        Gauss_Kruger = 3,
        Lambert_Conformal_Conic_2SP = 4,
        Albers_Equal_Area = 5
    }

    /// <summary>
    /// 线性单位常数
    /// </summary>
    public enum moLinearUnitConstant
    {
        Millimeter = 0,
        Centimeter = 1,
        Decimeter = 2,
        Meter = 3,
        Kilometers = 4
    }
}