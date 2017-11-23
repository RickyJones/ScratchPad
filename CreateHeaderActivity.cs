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

namespace ScratchApp
{
    [Activity(Label = "Create A Header")]
    public class CreateHeaderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Create_header);
            Button addStyleButton = FindViewById<Button>(Resource.Id.addStyleBtn);
            addStyleButton.Click += AddStyleButton_Click;
            // Create your application here
        }

        private void AddStyleButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(StyleActivity));
            StartActivity(intent);
        }
    }
}