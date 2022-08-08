
using Game.Scripts.EventMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.MotionControls
{
    public class JumpControl : Singleton<JumpControl>
    {
        public Vector3 jumpSpeed;

        protected override void Awake()
        {
            MotionTouchEvents.AddMotionEvent(Jump);
        }
        
        public void Jump()
        {
            Item.Instance.currentUsedItemRigidbody.useGravity = true;
            Item.Instance.currentUsedItemRigidbody.velocity = jumpSpeed;
        }
    }
}
