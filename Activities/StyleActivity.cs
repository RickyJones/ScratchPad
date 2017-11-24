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
using static Android.Views.View;
using ScratchApp.HTMLGen;
using ScratchApp.Activities;

namespace ScratchApp
{
    [Activity(Label = "Create A Style")]
    public class StyleActivity : Activity 
    {
        int keyOfElementToStyle;
        EditText widthField;
        EditText heightField;
        EditText backgroundColorField;
        CheckBox isPixelsCheckbox;
        string alignment;
        bool inPixels;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Style);
            Intent intent = this.Intent;
            keyOfElementToStyle = intent.GetIntExtra("key",0);
            Button confirmButton = FindViewById<Button>(Resource.Id.confirmStyleBtn);
            confirmButton.Click += ConfirmButton_Click;
            widthField = FindViewById<EditText>(Resource.Id.width_edit_text);
            heightField = FindViewById<EditText>(Resource.Id.height_edit_text);
            isPixelsCheckbox = FindViewById<CheckBox>(Resource.Id.dimension_metric_checkbox);
            backgroundColorField = FindViewById<EditText>(Resource.Id.background_color_edit_text);
            isPixelsCheckbox.Click += IsPixelsCheckbox_Click;

            Spinner alignmentSpinner = FindViewById<Spinner>(Resource.Id.alignment_options_spinner);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this,
            Resource.Array.alignment_options_array, Android.Resource.Layout.SimpleSpinnerItem);
            alignmentSpinner.Adapter = adapter;
            alignmentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }

        private void IsPixelsCheckbox_Click(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            inPixels = chkBox.Checked;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            this.alignment = spinner.GetItemAtPosition(e.Position).ToString();

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Element elementToStyle = HtmlBuilder.Instance.PageStructureDictionary[keyOfElementToStyle];

            Style style = new Style { Id = elementToStyle.Id, background_color = backgroundColorField.Text,
                Size = new StyleDimensions { Width = Convert.ToDouble(widthField.Text), Height = Convert.ToDouble(heightField.Text),
                    SizeType = (inPixels ? StyleDimensions.DimensionType.Pixels : StyleDimensions.DimensionType.Pixels) } };
            elementToStyle.Style = style;
            Intent intent = new Intent(this, typeof(ContentActivity)).SetFlags(ActivityFlags.ClearTop);
            StartActivity(intent);

        }
    }
}