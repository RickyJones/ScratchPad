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
    public struct StyleDTO
    {
        public string height;
        public string width;
        public string background_color;

        public StyleDTO(Style style)
        {
            this.height = (style.Size.SizeType == StyleDimensions.DimensionType.Pixels) ? $"{style.Size.Height}px" : $"{style.Size.Height}%";
            this.width = (style.Size.SizeType == StyleDimensions.DimensionType.Pixels) ? $"{style.Size.Width}px" : $"{style.Size.Width}%";
            this.background_color = style.background_color;
        }
    }
}