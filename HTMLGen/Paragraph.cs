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
    public class Paragraph : Element
    {

        public string Text;
        public Paragraph(string name, string text, Style style) : base(name, style)
        {
            this.Text = text;
            style.Id = "p";
            this.Style = style;
        }
        public GeneratedHtmlAndCss Construct()
        {
            string HTML = $"<p>{Text}</p>";
            string CSS = this.Style.Construct();
            return new GeneratedHtmlAndCss { Html = HTML, css = CSS };
        }
    }
}