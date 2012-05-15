using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using OML_Controller.Connection;
using Android.Media;

namespace OML_Controller
{
    [Activity(Label = "OML_Controller", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;
        public string LogText;        
        public TCPClient TCPclient;
        private MediaPlayer mp;
        private string url; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            TCPclient = new TCPClient(this); 
        }
            

        public void OnSetText()
        {
            TextView txtlog = FindViewById<TextView>(Resource.Id.TextLog);
            RunOnUiThread(() => txtlog.Text = LogText);
        }
    }
}

