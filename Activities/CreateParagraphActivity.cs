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

namespace ScratchApp.Activities
{
    [Activity(Label = "Create Paragraph Activity")]
    public class CreateParagraphActivity : BaseElementActivity
    {
        private EditText ParaTextField;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            View HeaderView = LayoutInflater.Inflate(Resource.Layout.CreateParagraph, null, false);
            base.SetContentView(HeaderView);
            TextView paraTextLabel = FindViewById<TextView>(Resource.Id.para_text_label);
            paraTextLabel.Text = "Paragraph Text";
            TextView elementNameLabel = FindViewById<TextView>(Resource.Id.element_name_label);
            elementNameLabel.Text = "Name Of Paragraph";
            ParaTextField = FindViewById<EditText>(Resource.Id.para_text_edit_text);
            Button addStyleButton = FindViewById<Button>(Resource.Id.addStyleBtn);
            addStyleButton.Click += AddStyleButton_Click;
            styleBtnFunc = () => {

             element = new Paragraph(elementNameField.Text, ParaTextField.Text, null);

            };
            base.OnCreate(savedInstanceState);
            // Create your application here
        }
    }
}