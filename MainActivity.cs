using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace ScratchApp
{
    [Activity(Label = "ScratchApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            // Set our view from the "main" layout resource
            Button createHeaderBtn = FindViewById<Button>(Resource.Id.createHeaderButton);
            createHeaderBtn.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                StartActivity(typeof(CreateHeaderActivity));
            });
            
        }
    }
}

