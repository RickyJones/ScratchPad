
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

namespace ScratchApp.Activities
{
    [Activity(Label = "BoxActivity")]
    public class BoxActivity : Activity
    {
        EditText allPaddingField;
        EditText topPaddingField;
        EditText bottomPaddingField;
        EditText rightPaddingField;
        EditText leftPaddingField;
        Button confirmBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent intent = this.Intent;
            string boxType = intent.GetStringExtra("BoxType");

            SetContentView(Resource.Layout.Box);
            allPaddingField = FindViewById<EditText>(Resource.Id.box_all_edit_text);
            topPaddingField = FindViewById<EditText>(Resource.Id.box_top_edit_text);
            bottomPaddingField = FindViewById<EditText>(Resource.Id.box_bottom_edit_text);
            rightPaddingField = FindViewById<EditText>(Resource.Id.box_right_edit_text);
            leftPaddingField = FindViewById<EditText>(Resource.Id.box_left_edit_text);
            confirmBtn = FindViewById<Button>(Resource.Id.box_add_btn);
        }
    }
}
