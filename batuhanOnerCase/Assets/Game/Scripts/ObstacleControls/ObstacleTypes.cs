using UnityEngine;

namespace Game.Scripts.ObstacleControls
{
    public class ObstacleTypes : MonoBehaviour
    {
    public enum ObstacleType
    {
        Penetrable,
        Fail,
        Cuttable
    }
     public enum ObstacleDirectionType
    {
        Ground,
        Ceiling,
        FrontWall,
        BehindWall
    }
    }
}
