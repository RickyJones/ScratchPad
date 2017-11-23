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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Style);
            Spinner alignmentSpinner = FindViewById<Spinner>(Resource.Id.alignment_options_spinner);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this,
            Resource.Array.alignment_options_array, Android.Resource.Layout.SimpleSpinnerItem);
            alignmentSpinner.Adapter = adapter;
            alignmentSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                
            };
        }
    }
}