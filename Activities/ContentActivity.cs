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
        ElementType elementType;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_content);
            Spinner elementTypeSpinner = FindViewById<Spinner>(Resource.Id.elementTypeSpinner);
            ArrayAdapter spinnerAdapter = ArrayAdapter.CreateFromResource(this,
            Resource.Array.element_type_options_array, Android.Resource.Layout.SimpleSpinnerItem);
            elementTypeSpinner.Adapter = spinnerAdapter;
            elementTypeSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            ListView contentList = FindViewById<ListView>(Resource.Id.content_List);
            ContentListAdapter adapter = new ContentListAdapter(this, HtmlBuilder.Instance.PageStructureDictionary);
            contentList.Adapter = adapter;
            Button addElementButton = FindViewById<Button>(Resource.Id.add_elementBtn);
            addElementButton.Click += AddElementButton_Click;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string elmtType = spinner.GetItemAtPosition(e.Position).ToString();
            switch (elmtType)
            {
                case "Header One":
                    this.elementType = ElementType.HeaderOne;
                    break;
                case "Paragraph":
                    this.elementType = ElementType.Paragraph;
                    break;
                default:
                    break;
            }
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            switch(elementType)
            {
                case ElementType.HeaderOne:
                    intent = new Intent(this, typeof(CreateHeaderActivity));
                    break;
                case ElementType.Paragraph:
                    intent = new Intent(this, typeof(CreateParagraphActivity));
                    break;
            }
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

        public Element GetElement(int position)
        {
            return Elements[position];
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