using UnityEngine;

namespace Game.Scripts.ObstacleControls
{
    public class ObstacleCollisionControl : MonoBehaviour
    {
        public static Collider endCollisionObstacleCollider;

        public static void EndCollisionObstaclePhysicsOpen()
        {
            if (endCollisionObstacleCollider!=null)
            {
                endCollisionObstacleCollider.isTrigger = false;
            }
        }
        public static void EndCollisionObstaclePhysicsClose()
        {
            if (endCollisionObstacleCollider!=null)
            {
                endCollisionObstacleCollider.isTrigger = true;
            }
        }
    }
}
