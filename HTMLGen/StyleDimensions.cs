using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScratchApp.HTMLGen
{
    public struct StyleDimensions
    {
        public enum DimensionType { Pixels, Percentage };
        public DimensionType SizeType;
        public double Height;
        public double Width;
    }
}