using Game.Scripts.ItemMenager;
using Game.Scripts.ObstacleControls;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.MotionControls
{
    public class PenetrableControl : Singleton<PenetrableControl>
    {
        public  void Execute(Collider obstacleClCollider)
        {
            RotationControl.Instance.canRotate = false;
            Item.Instance.currentUsedItemRigidbody.isKinematic = true;
            if (ObstacleCollisionControl.endCollisionObstacleCollider != obstacleClCollider)
            {
                ObstacleCollisionControl.EndCollisionObstaclePhysicsOpen(); 
            }
            ObstacleCollisionControl.endCollisionObstacleCollider = obstacleClCollider;
        }
    }
}
