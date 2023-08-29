using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Lib
{
    public class GMapText : GMapMarker
    {
        private readonly string _text;

        public GMapText(PointLatLng p, string text)
            : base(p)
        {
            _text = text;
        }

        public override void OnRender(Graphics g)
        {
            g.DrawString(_text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular), Brushes.Black, LocalPosition.X, LocalPosition.Y);
        }
    }
}
