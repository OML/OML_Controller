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
using OML_Controller;

namespace OML_Controller
{
    [Activity(Label = "Video Activity")]
    public class video : Activity, ISurfaceHolderCallback
    {
        Android.Media.MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.videolayout);
            // Create your application here
            mediaPlayer = new Android.Media.MediaPlayer();
            SurfaceView surface = (SurfaceView)FindViewById(Resource.Id.surface);
            var holder = surface.Holder;
            holder.AddCallback(this);
            holder.SetType(Android.Views.SurfaceType.PushBuffers);
            Button btnClose = FindViewById<Button>(Resource.Id.btnClose);
            btnClose.Click += new EventHandler(btnClose_Click);
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            System.Console.WriteLine("@ SurfaceCreated:" + "Set Display, Set DataSource");
            try
            {
                mediaPlayer.SetDisplay(holder);
                //mediaPlayer.SetDataSource("http://www.aspnetpodcast.com/VideoFiles/MonoForAndroid.mp4");
                mediaPlayer.SetDataSource("http://141.252.221.71:1234");

                mediaPlayer.Prepared += new EventHandler(mediaPlayerPrepared);
                mediaPlayer.PrepareAsync();

                //Get the dimensions of the video
                int videoWidth = mediaPlayer.VideoHeight;
                int videoHeight = mediaPlayer.VideoWidth;
            }
            catch (System.Exception e)
            {
                Android.Util.Log.Debug("MEDIA_PLAYER", e.Message);
                Toast.MakeText(this, e.Message, ToastLength.Short).Show(); 
            }
        }

        void mediaPlayerPrepared(object sender, EventArgs e)
        {
            System.Console.WriteLine("@ mediaPlayerPrepared:" + "Start Stream");
            mediaPlayer.Start();
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            System.Console.WriteLine("@ SurfaceDestroyed:" + "Close Stream");
            mediaPlayer.Release();
        }

        public void SurfaceChanged(ISurfaceHolder holder, int i, int j, int k){}
    }
}