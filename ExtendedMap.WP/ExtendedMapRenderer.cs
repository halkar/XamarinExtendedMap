using System.Device.Location;
using System.Windows.Input;
using ExtendedMap.WP;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.WP8;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof (ExtendedMap.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.WP
{
    public class ExtendedMapRenderer : MapRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            if (Control != null)
                Control.Tap -= Control_Tap;
            base.OnElementChanged(e);
            if (Control != null)
                Control.Tap += Control_Tap;
        }

        private void Control_Tap(object sender, GestureEventArgs e)
        {
            var coordinate = Control.ConvertViewportPointToGeoCoordinate(e.GetPosition(Control));
            ((ExtendedMap) Element).OnTap(new Position(coordinate.Latitude, coordinate.Longitude));
        }
    }
}