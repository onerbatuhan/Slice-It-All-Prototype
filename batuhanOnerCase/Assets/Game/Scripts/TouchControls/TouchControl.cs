using System;
using Game.Scripts.EventMenager;
using Game.Scripts.GameMenager;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.TouchControls
{
    public class TouchControl : Singleton<TouchControl>
    {
        void Update()
        {
           
                if (GameControl.Instance.gameStates == GameControl.GameStates.Continues)
                {
                    TouchEvent();
                }
            
            
           
        }

        private void TouchEvent()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MotionTouchEvents.OnTouchMotionEvent();
            }
        }
    }
}
