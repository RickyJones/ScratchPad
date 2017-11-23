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
    public class Style
    {
        public string Id;
        public StyleDimensions Size;
        public string background_color;
        public string Construct()
        {
            var json = new JavaScriptSerializer().Serialize(new StyleDTO(this));
            json = json.Replace('_', '-');
            json = json.Replace(',', ';');
            json = json.Replace('"', ' ');
            json = json.Insert(json.Count() - 2, ";");
            return json;

        }
    }
}