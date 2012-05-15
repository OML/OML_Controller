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
        public string LogText;        
        public TCPClient TCPclient;
 
        public Activity1()
        {}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
             /**
             * Create start
             */
            Button btnOpenNewActivity1 = FindViewById<Button>(Resource.Id.startButton);
            btnOpenNewActivity1.Click += new EventHandler(StartClick);

            /**
            * Create info sometimes
            */
            Button btnOpenNewActivity = FindViewById<Button>(Resource.Id.infoButton);
            btnOpenNewActivity.Click += new EventHandler(InfoClick);
 
            /**
             * Create settings
             */
            Button btnOpenNewActivity2 = FindViewById<Button>(Resource.Id.settingsButton);
            btnOpenNewActivity2.Click += new EventHandler(SettingsClick);
    
            /**
             * Exit
             */
            Button btnOpenNewActivity3 = FindViewById<Button>(Resource.Id.exitButton);
            btnOpenNewActivity3.Click += new EventHandler(ExitClick);


            //TCP Server
            //TCPclient = new TCPClient(this);           
        }

        void button_Click(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(video));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
        }

        void StartClick(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(Start));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
        }

        void InfoClick(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(Info));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
        }

        void SettingsClick(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(Settings));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
        }

        void ExitClick(object sender, EventArgs e)
        {
            
        }  

        public void OnSetText()
        {
            //TextView txtlog = FindViewById<TextView>(Resource.Id.TextLog);
            //RunOnUiThread(() => txtlog.Text = LogText);
        }
    }
}

