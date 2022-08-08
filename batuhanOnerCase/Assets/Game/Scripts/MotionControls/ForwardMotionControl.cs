
using System;
using Game.Scripts.EventMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.MotionControls
{
    public class ForwardMotionControl : Singleton<ForwardMotionControl>
    {
        public Vector3 forwardSpeed;

        protected override void Awake()
        {
            MotionTouchEvents.AddMotionEvent(MoveObjectForward);
        }

        public void MoveObjectForward()
        {
            Item.Instance.currentUsedItemRigidbody.AddForce(forwardSpeed,ForceMode.VelocityChange);
        }
    }
}
