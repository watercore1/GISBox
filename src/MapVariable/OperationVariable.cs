using System.Collections.Generic;
using System.Drawing;
using MyMapObjects;

namespace GISBox.MapVariable
{
    public class OperationVariable
    {
        #region Propert

        // (1) map operation style
        public MapOpStyle MapStyle { get; set; }

        /* more detailed map status than MapOpStyle, depends on
        whether the left mouse button pressed
        whether pressed on selected features
        whether the selected feature has been moved */

        /// <summary>
        /// In the style 1-5:
        /// mouse move has different response
        /// depending on whether left mouse button pressed
        /// </summary>
        public bool IsLeftMousePressed { get; set; }

        /// <summary>
        /// In the style 6: SelectAndMoveFeature
        /// when the left mouse button is pressed,
        /// need to judge if pressed on selected feature
        /// if true: move selected features
        /// if false: reselect features to edit
        /// </summary>
        public bool IsMouseDownOnSelectedFeature { get; set; }

        /// <summary>
        /// in the status: MouseDownOnSelectedFeature
        /// if you just click once, not actually move mouse
        /// then select the single feature click on, not move feature 
        /// </summary>
        public bool IsSelectedFeatureMoved { get; set; }

        /// <summary>
        /// in the style 7: move node
        /// when the left mouse button is pressed,
        /// need to judge if pressed near node
        /// if true: ready to move node
        /// if false: nothing to do
        /// </summary>
        public bool IsMouseDownNearNode { get; set; }

        public bool IsNodeChanged { get; set; }

        /// <summary>
        /// if layer is changed, when finish editing
        /// need to choose whether to save layer
        /// </summary>
        public bool IsLayerChanged { get; set; }


        // (2) operation data
        
        // the location of mouse down
        public PointF StartMouseLocation { get; set; }

        // selected layer index
        public int SelectedLayerIndex { get; set; }

        // edited layer index
        public int EditedLayerIndex { get; set; }

        // when edit node on polygon or polyline, the part index
        public int MouseOnPartIndex { get; set; }

        // when edit node, the point index
        public int MouseOnPointIndex { get; set; }

        // the selected geometries to move
        public List<moGeometry> MovingGeometries { get; set; }

        // the selected geometries to edit node
        public moGeometry EditingNodeGeometry { get; set; }

        // current created part
        public List<moPoint> CreatingPoint { get; set; }

        // current created feature
        public List<moPoints> CreatingFeature { get; set; }

        
        #endregion

        #region Constructor

        public OperationVariable()
        {
            MapStyle = 0;
            IsLeftMousePressed = false;
            IsMouseDownOnSelectedFeature = false;
            IsSelectedFeatureMoved = false;
            IsMouseDownNearNode = false;
            IsLayerChanged = false;
            StartMouseLocation = new PointF();
            SelectedLayerIndex = -1;
            EditedLayerIndex = -1;
            MouseOnPartIndex = -1;
            MouseOnPointIndex = -1;
            MovingGeometries = new List<moGeometry>();

            CreatingPoint = new List<moPoint>();
            CreatingFeature = new List<moPoints>();
            moPoints points = new moPoints();
            CreatingFeature.Add(points);
        }


        public void EndEditNode()
        {
            IsNodeChanged = false;
            EditingNodeGeometry = null;
            MouseOnPartIndex = -1;
            MouseOnPointIndex = -1;
        }

        public void EndEditLayer()
        {
            MapStyle = 0;
            EditedLayerIndex = -1;
            IsLayerChanged = false;
            MovingGeometries.Clear();
        }

        public void EndCreateFeature()
        {
            CreatingPoint.Clear();
            CreatingFeature.Clear();
            moPoints points = new moPoints();
            CreatingFeature.Add(points);
        }

        #endregion

    }
}