
using System;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.EventMenager
{
    public class MotionTouchEvents : Singleton<MotionTouchEvents>
    {
        public delegate void TouchMotionEventDelegate();
        public static event TouchMotionEventDelegate TouchMotionEvent;

       
        public static void OnTouchMotionEvent()
        {
            TouchMotionEvent?.Invoke();
        }

        public static void AddMotionEvent(TouchMotionEventDelegate motion)
        {
            TouchMotionEvent += motion;
        }

        public static void RemoveMotionEvent(TouchMotionEventDelegate motion)
        {
            TouchMotionEvent -= motion;
        }

        public static void RemoveAllMotionEvent()
        {
            TouchMotionEvent = null;
        }

     
        
    }
}
