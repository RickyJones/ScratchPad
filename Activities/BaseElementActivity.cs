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
    [Activity(Label = "BaseElementActivity")]
    public abstract class BaseElementActivity : Activity
    {
        protected bool isClicked;
        protected bool isEditMode;
        protected Intent intent;
        protected EditText position;
        protected EditText elementNameField;
        protected Action styleBtnFunc;
        protected Element element;
        protected List<string> validationMessages;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent intent = new Intent(this, typeof(StyleActivity));
            position = FindViewById<EditText>(Resource.Id.element_position_edit_text);
            elementNameField = FindViewById<EditText>(Resource.Id.element_name_edit_text);
            Button addStyleButton = FindViewById<Button>(Resource.Id.addStyleBtn);
            addStyleButton.Click += AddStyleButton_Click;
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            isEditMode = !(position.Text != null || position.Text != string.Empty);
            isClicked = false;
        }

        public override void SetContentView(View view)
        {
            var fullLayout = (LinearLayout)LayoutInflater.Inflate(Resource.Layout.BaseElementLayout, null);
            var subActivityContent = (FrameLayout)fullLayout.FindViewById(Resource.Id.element_content_frame);
            subActivityContent.AddView(view);
            base.SetContentView(fullLayout);
        }

        protected virtual void AddStyleButton_Click(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                try
                {
                    styleBtnFunc();
                    if (!isEditMode)
                    {
                        HtmlBuilder.Instance.PageStructureDictionary.Add(Convert.ToInt32(position.Text), element);
                    }
                    Intent intent = new Intent(this, typeof(StyleActivity));
                    intent.PutExtra("key", Convert.ToInt32(position.Text));
                    StartActivity(intent);
                    isClicked = true;
                }
                catch (Exception ex)
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetMessage(ex.Message)
                           .SetTitle("Error");

                    AlertDialog dialog = builder.Create();
                    builder.SetPositiveButton("OK", (c, ev) =>
                    {
                        dialog.Cancel();
                    });

                    dialog.Show();
                }
            }
        }
    }

}