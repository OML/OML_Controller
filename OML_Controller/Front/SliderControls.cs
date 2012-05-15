using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace OML_Controller.Front
{
    public class SliderControls : View, View.IOnTouchListener
    {
        public static int INIT_X = 0;
	    public static int INIT_Y = 179;
	
	    public Point _touchingPoint = new Point(INIT_X, INIT_Y);
	
	    private Boolean _dragging = false;
	    private MotionEvent lastEvent;
	
	    public float percentage = 0;

        public SliderControls(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public SliderControls(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        public bool OnTouch(View v, MotionEvent events) 
	    {
		    update(events);
            this.Invalidate();
		    return true;
	    }

        public void update(MotionEvent events)
	    {
		    if (events == null && lastEvent == null)
			    return;
		
		    else if(events == null && lastEvent != null)
			    events = lastEvent;
		
		    else
			    lastEvent = events;
		
		    //drag drop 
            if (events.Action == MotionEventActions.Down)
			    _dragging = true;

            else if (events.Action == MotionEventActions.Up)							
			    _dragging = false;
		
		    if ( _dragging )
		    {
			    // get the position
			    _touchingPoint.X = INIT_X;
			
			    if ((int)events.GetY() < 0)
				    _touchingPoint.Y = 0;
			    else if((int)events.GetY() > 179)
				    _touchingPoint.Y = 179;
			    else
				    _touchingPoint.Y = (int)events.GetY();
		    }
		
		    //determine the percentage of power
		    percentage = ((Math.Abs(_touchingPoint.Y - 179) / 179) * 100);
	    }

        public void onDraw(Canvas canvas)
        {
            //if (((View)this.GetParent()).getVisibility() == VISIBLE && ((View)this.getParent()).getId() != id.bigSlider)
           //if (((View)this.GetParent()).getVisibility() == VISIBLE && ((View)this.getParent()).getId() != id.bigSlider)
           //{
                //draw the dragable slider(s)
                //canvas.DrawBitmap(BitmapFactory.DecodeResource(Resource.Drawable.slidersmall, _touchingPoint.X, _touchingPoint.Y));
            var paint = new Paint ();
              paint.AntiAlias = true;
              paint.Color = Color.Green;
              paint.Alpha = 50;

              //Bitmap a = BitmapFactory.DecodeResource(Resource.Drawable.slidersmall, 2);

              //canvas.DrawBitmap(_touchingPoint.X, _touchingPoint.X, paint);
            
           //}
           //else
           //{
           //    //draw the dragable slider
           //    canvas.DrawBitmap(BitmapFactory.DecodeResource(Resource.Drawable.sliderbig, _touchingPoint.X, _touchingPoint.Y));
           //}
           //for debugging in edit mode
        }
    }
}