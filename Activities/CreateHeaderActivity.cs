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
using ScratchApp.HTMLGen;

namespace ScratchApp
{
    [Activity(Label = "Create A Header")]
    public class CreateHeaderActivity : Activity
    {
        EditText headerNameField;
        EditText textInHeader;
        EditText position;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Create_header);
            headerNameField = FindViewById<EditText>(Resource.Id.header_name_edit_text);
            textInHeader = FindViewById<EditText>(Resource.Id.header_text_edit_text);
            position = FindViewById<EditText>(Resource.Id.header_position_edit_text);
            Button addStyleButton = FindViewById<Button>(Resource.Id.addStyleBtn);
            addStyleButton.Click += AddStyleButton_Click;
            // Create your application here
        }

        private void AddStyleButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(StyleActivity));
            intent.PutExtra("key", Convert.ToInt32(position.Text));
            //Intent.PutExtra("text", textInHeader.Text);

            HeaderOne header = new HeaderOne(headerNameField.Text, textInHeader.Text, null);
            HtmlBuilder.Instance.PageStructureDictionary.Add(Convert.ToInt32(position.Text), header);

            StartActivity(intent);
        }
    }
}