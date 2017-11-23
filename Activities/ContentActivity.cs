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
using Java.Lang;
using ScratchApp.HTMLGen;

namespace ScratchApp.Activities
{
    [Activity(Label = "ContentActivity", MainLauncher =true)]
    public class ContentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_content);
            Style style = new Style();
            style.Size.Height = 10;
            style.Size.Width = 100;
            style.background_color = "white";
            Paragraph p = new Paragraph("first pa", "some text", style);
            HtmlBuilder.Instance.PageStructureDictionary.Add(1, p);
            ListView contentList = FindViewById<ListView>(Resource.Id.content_List);
            ContentListAdapter adapter = new ContentListAdapter(this, HtmlBuilder.Instance.PageStructureDictionary);
            contentList.Adapter = adapter;
            Button addElementButton = FindViewById<Button>(Resource.Id.add_elementBtn);
            addElementButton.Click += AddElementButton_Click;
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CreateHeaderActivity));
            StartActivity(intent);
        }
    }
    public class ContentListAdapter : BaseAdapter
    {
        Dictionary<int, Element> Elements;
        Context context;

        public ContentListAdapter(Context context, Dictionary<int, Element> elements)
        {
            this.context = context;
            this.Elements = elements;
        }

        public override int Count
        {
            get
            {
                return Elements.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;//Java.Lang.Object(Elements[position]);
        }

        public override long GetItemId(int position)
        {
            return Convert.ToInt64(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(Resource.Layout.ContentItem, null);
                TextView elementName = view.FindViewById<TextView>(Resource.Id.element_name);
                TextView elementPosition = view.FindViewById<TextView>(Resource.Id.element_position);
                TextView elementParent = view.FindViewById<TextView>(Resource.Id.element_parent);
                List<Element> e = Elements.Values.ToList<Element>();
                elementName.Text = e[position].Id;
                //elementPosition.Text = Elements.Keys[position];
            }

            return view;
        }
    }
}