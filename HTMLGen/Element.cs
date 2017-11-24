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
    public enum ElementType
    {
        HeaderOne, Paragraph
    }
    public abstract class Element
    {
        public string Id;
        public Style Style;
        public List<Element> NestedElements;

        public Element(string id, Style style)
        {
            this.Id = id;
            this.Style = style;
            if (style != null)
            this.Style.Id = id;
        }
        public void AddToPage(int positionOnPage)
        {
            if (HtmlBuilder.Instance.PageStructureDictionary[positionOnPage] != null)
            {
                Console.Write(Warnings.ElementPositionAlreadyAssigned);
            }
            else
            {
                HtmlBuilder.Instance.PageStructureDictionary.Add(positionOnPage, this);
            }
        }
        public void AddAsChild(Element parent)
        {
            parent.NestedElements.Add(this);
        }
        public abstract GeneratedHtmlAndCss Construct();
    }
}