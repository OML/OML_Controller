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

namespace OML_Controller
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
            this.SetOnTouchListener(this);
        }

        public SliderControls(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
            this.SetOnTouchListener(this);
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

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (!this.IsInEditMode)
            {
                //if (((View)this.GetParent()).getVisibility() == VISIBLE && ((View)this.getParent()).getId() != id.bigSlider)
                if (this.Visibility == ViewStates.Visible)
                {
                //draw the dragable slider(s)
                //canvas.DrawBitmap(BitmapFactory.DecodeResource(Resource.Drawable.slidersmall, _touchingPoint.X, _touchingPoint.Y));            
                    canvas.DrawBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.slidersmall), _touchingPoint.X, _touchingPoint.Y, null);
                }
                //else
                //{
                //    //draw the dragable slider
                //    canvas.DrawBitmap(BitmapFactory.DecodeResource(Resource.Drawable.sliderbig, _touchingPoint.X, _touchingPoint.Y));
                //}
                //for debugging in edit mode
            }
            else
            {
                Paint innerCirclePaint = new Paint();
                innerCirclePaint.SetARGB(255, 255, 255, 255);
                innerCirclePaint.AntiAlias = true;

                innerCirclePaint.SetStyle(Paint.Style.Fill);
                canvas.DrawLine(21, 0, 21, 205, innerCirclePaint);
            }
        }
    }
}