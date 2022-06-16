namespace GISBox
{
    /// <summary>
    /// shape file 要素类型
    /// </summary>
    public enum ShapeFileType
    {
        //NullShape = 0,
        Point = 1,
        PolyLine = 3,
        Polygon = 5,
        //MultiPoint = 8,
        //PointZ = 11,
        //PolyLineZ = 13,
        //PolygonZ = 15,
        //MultiPointZ = 18,
        //PointM = 21,
        //PolyLineM = 23,
        //PolygonM = 25,
        //MultiPointM = 28,
        //MultiPatch = 31
    }

    /// <summary>
    /// 地图操作
    /// </summary>
    public enum MapOpStyle
    {
        None=0,         //无
        ZoomIn=1,       //放大
        ZoomOut=2,      //缩小
        Move = 3,       //移动视图
        Select = 4,     //选择要素
        Identify = 5,   //识别要素
        Edit = 6,       //选择要编辑要素，并移动选中的要素
        Create = 7,     //创建新要素
        MoveNode = 8,   //移动节点
        AddNode = 9,    //添加节点
        DeleteNode =10  //删除节点
    }
}
