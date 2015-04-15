using CoreGraphics;
using ExtendedMap.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using CoreLocation;
using MapKit;

[assembly: ExportRenderer(typeof (ExtendedMap.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.iOS
{
    public class ExtendedMapRenderer : MapRenderer
    {
        private readonly UITapGestureRecognizer _tapRecogniser;

        public ExtendedMapRenderer()
        {
            _tapRecogniser = new UITapGestureRecognizer(OnTap)
            {
                NumberOfTapsRequired = 1,
                NumberOfTouchesRequired = 1
            };
        }

        private void OnTap(UITapGestureRecognizer recognizer)
        {
            var cgPoint = recognizer.LocationInView(Control);
            var location = ((MKMapView) Control).ConvertPoint(cgPoint, Control);
            ((ExtendedMap)Element).OnTap(new Position(location.Latitude, location.Longitude));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (Control != null)
                Control.RemoveGestureRecognizer(_tapRecogniser);
            base.OnElementChanged(e);
            if (Control != null)
                Control.AddGestureRecognizer(_tapRecogniser);
        }
    }
}