using System.Drawing;
using MyMapObjects;

namespace GISBox.MapVariable
{
    public class SettingVariable
    {
        #region Property

        // (1) zoom
        public moSimpleFillSymbol ZoomBoxSymbol { get; }
        public double ZoomRatioClick { get; }

        // (2) select
        public moSimpleFillSymbol SelectBoxSymbol { get; }
        public double Tolerance { get; }

        // (3) feature symbols when moving feature to a new location
        public moSimpleMarkerSymbol MovingPointSymbol { get; }
        public moSimpleLineSymbol MovingPolylineSymbol { get; }
        public moSimpleFillSymbol MovingPolygonSymbol { get; }

        // (4) features symbol when editing node
        public moSimpleMarkerSymbol EditingNodeSymbol { get; }
        public moSimpleLineSymbol EditingPolylineSymbol { get; }
        public moSimpleFillSymbol EditingPolygonSymbol { get; }

        // (5) elastic symbol when creating feature
        public moSimpleLineSymbol ElasticSymbol { get; }

        // (6) others
        public bool IsShowLngLat { get; }

        #endregion

        #region Constructor

        public SettingVariable()
        {
            ZoomBoxSymbol = new moSimpleFillSymbol(Color.Brown);
            ZoomRatioClick = 2;

            SelectBoxSymbol = new moSimpleFillSymbol(Color.Pink);
            Tolerance = 5;

            MovingPointSymbol = new moSimpleMarkerSymbol(Color.DarkSalmon);
            MovingPolylineSymbol = new moSimpleLineSymbol(Color.DarkSalmon);
            MovingPolygonSymbol = new moSimpleFillSymbol(Color.DarkSalmon);

            EditingNodeSymbol = new moSimpleMarkerSymbol(Color.Green)
            {
                Style = moSimpleMarkerSymbolStyleConstant.SolidSquare,
                Size = 2
            };
            EditingPolylineSymbol = new moSimpleLineSymbol(Color.Green);
            EditingPolygonSymbol = new moSimpleFillSymbol(Color.Green);

            ElasticSymbol = new moSimpleLineSymbol(Color.BlueViolet)
            {
                Style = moSimpleLineSymbolStyleConstant.Dash
            };

            IsShowLngLat = true;
        }

    #endregion

}
}