using System;
using Game.Scripts.AudioMenager;
using Game.Scripts.EventMenager;
using Game.Scripts.GameMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.ObstacleControls;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.MotionControls
{
    public class ReverseMotionControl : Singleton<ReverseMotionControl>
    {
        public float itemBehindCollisionDirectionSpeed;
        
        
        public void MoveObjectBack(ObstacleTypes.ObstacleDirectionType directionType)
        {
            if (GameControl.Instance.gameStates != GameControl.GameStates.Continues) return;
            MotionTouchEvents.RemoveMotionEvent(ForwardMotionControl.Instance.MoveObjectForward);
            MotionTouchEvents.RemoveMotionEvent(JumpControl.Instance.Jump);
            MotionTouchEvents.OnTouchMotionEvent();
            switch (directionType)
            {
                case ObstacleTypes.ObstacleDirectionType.Ground:
                    ItemBehindCollisionMotionEvent(itemBehindCollisionDirectionSpeed,Vector3.up);
                    break;
                case ObstacleTypes.ObstacleDirectionType.Ceiling:
                    ItemBehindCollisionMotionEvent(itemBehindCollisionDirectionSpeed,Vector3.forward);
                    break;
                case ObstacleTypes.ObstacleDirectionType.FrontWall:
                    ItemBehindCollisionMotionEvent(itemBehindCollisionDirectionSpeed,Vector3.back);
                    break;
                case ObstacleTypes.ObstacleDirectionType.BehindWall:
                    ItemBehindCollisionMotionEvent(itemBehindCollisionDirectionSpeed,Vector3.forward);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(directionType), directionType, null);
            }
            MotionTouchEvents.AddMotionEvent(ForwardMotionControl.Instance.MoveObjectForward);
            MotionTouchEvents.AddMotionEvent(JumpControl.Instance.Jump);
        }

        private void ItemBehindCollisionMotionEvent(float speed, Vector3 direction)
        {
            Item.Instance.currentUsedItemRigidbody.velocity = direction *(speed);
            AudioController.Instance.CollisionSoundStart();
            
        }
    }
}
