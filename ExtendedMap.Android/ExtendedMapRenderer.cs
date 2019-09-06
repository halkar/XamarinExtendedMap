using Android.Gms.Maps;
using ExtendedMap.Android;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (ExtendedMap.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.Android
{
    public class ExtendedMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        public ExtendedMapRenderer(Context context) : base(context)
        { }

        public void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            if (_map != null)
                NativeMap.MapClick += googleMap_MapClick;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                NativeMap.MapClick -= googleMap_MapClick;
            if (Control != null)
                ((MapView) Control).GetMapAsync(this);
        }

        private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            ((ExtendedMap)Element).OnTap(new Position(e.Point.Latitude, e.Point.Longitude));
        }
    }
}