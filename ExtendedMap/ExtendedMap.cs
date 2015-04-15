using System;
using Xamarin.Forms.Maps;

namespace ExtendedMap
{
    public class ExtendedMap : Map
    {
        public event EventHandler<TapEventArgs> Tap;
        public ExtendedMap()
        {
            
        }

        public ExtendedMap(MapSpan region):base(region)
        {
            
        }

        public void OnTap(Position coordinate)
        {
            OnTap(new TapEventArgs{Position = coordinate});
        }

        protected virtual void OnTap(TapEventArgs e)
        {
            var handler = Tap;
            if (handler != null) handler(this, e);
        }
    }

    public class TapEventArgs : EventArgs
    {
        public Position Position { get; set; }
    }
}