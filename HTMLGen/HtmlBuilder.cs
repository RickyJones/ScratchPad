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
using Java.IO;
using System.IO;

namespace ScratchApp.HTMLGen
{
    public sealed class HtmlBuilder
    {
        private static HtmlBuilder instance = null;
        public HtmlBuilder()
        {

        }
        public static HtmlBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HtmlBuilder();
                }
                return instance;
            }
        }
        public Dictionary<int, Element> PageStructureDictionary = new Dictionary<int, Element>();
        private Dictionary<string, string> HTMLCSSCouple;
        public Dictionary<string, string> BuildHtml()
        {
            PageStructureDictionary.OrderBy(x => x.Key); //ensure index ordering
            string HtmlGen = string.Empty;
            string CSSGen = string.Empty;
            foreach (Element element in PageStructureDictionary.Values)
            {
                HtmlGen += element.Construct().Html;
                CSSGen += element.Construct().css;
            }
            HTMLCSSCouple = new Dictionary<string, string>();
            HTMLCSSCouple.Add(HtmlGen, CSSGen);
            return HTMLCSSCouple;
        }
        
    }
}