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
using ScratchApp.Activities;

namespace ScratchApp
{
    [Activity(Label = "Create A Header")]
    public class CreateHeaderActivity : BaseElementActivity
    {
        EditText textInHeader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            View HeaderView = LayoutInflater.Inflate(Resource.Layout.Create_header, null, false);
            base.SetContentView(HeaderView);
            textInHeader = FindViewById<EditText>(Resource.Id.header_text_edit_text);
            Button addStyleButton = FindViewById<Button>(Resource.Id.addStyleBtn);
            addStyleButton.Click += AddStyleButton_Click;
            styleBtnFunc = () => {
                element = new HeaderOne(elementNameField.Text, textInHeader.Text, null);
            };
            base.OnCreate(savedInstanceState);
        }

        private void Validation()
        {
            if(textInHeader.Text == string.Empty)
            {
                validationMessages.Add("Field is empty.");
            }
        }
    }
}