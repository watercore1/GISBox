namespace GISBox
{
    /// <summary>
    /// shape file feature type
    /// </summary>
    public enum ShapeFileType:int
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
    /// use one byte to represent dbf Field Type
    /// divide all types into four case
    /// </summary>
    public enum DbfFieldType:byte
    {
        Int= (byte)'I',
        Single = (byte)'F',
        Double = (byte)'D',
        Text = (byte)'C',
    }

    /// <summary>
    /// different map states
    /// </summary>
    public enum MapOpStyle
    {
        None=0,        
        ZoomIn=1,       
        ZoomOut=2,      
        Pan = 3,       
        Select = 4,     // select feature
        Identify = 5,   // identify feature
        /// <summary>
        /// select the feature to edit
        /// and can move the selected feature in this style
        /// </summary>
        SelectAndMoveFeature = 6,
        MoveNode = 7,   // move node
        AddNode = 8,    // add node
        DelNode =9,  // del node
        Create = 10,    // create feature
    }
}
