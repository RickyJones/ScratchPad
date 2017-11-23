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

namespace ScratchApp
{
    [Activity(Label = "Create A Style")]
    public class StyleActivity : Activity 
    {
        int keyOfElementToStyle;
        EditText widthField;
        EditText heightField;
        EditText backgroundColorField;
        string alignment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Style);
            Intent intent = this.Intent;
            keyOfElementToStyle = intent.GetIntExtra("key", 0);
            Button confirmButton = FindViewById<Button>(Resource.Id.confirmStyleBtn);
            confirmButton.Click += ConfirmButton_Click;
            widthField = FindViewById<EditText>(Resource.Id.width_edit_text);
            heightField = FindViewById<EditText>(Resource.Id.height_edit_text);
            backgroundColorField = FindViewById<EditText>(Resource.Id.background_color_edit_text);


            Spinner alignmentSpinner = FindViewById<Spinner>(Resource.Id.alignment_options_spinner);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this,
            Resource.Array.alignment_options_array, Android.Resource.Layout.SimpleSpinnerItem);
            alignmentSpinner.Adapter = adapter;
            alignmentSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
               // alignment = sender.
            };
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            HTMLGen.Element elementToStyle = HTMLGen.HtmlBuilder.Instance.PageStructureDictionary[keyOfElementToStyle];
        }
    }
}