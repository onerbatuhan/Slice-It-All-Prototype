using UnityEngine;

namespace Game.Scripts.TableObjects.Item
{
    [CreateAssetMenu(menuName = "Inventory/Item",fileName = "New Item")]
    public class ItemTableObject : ScriptableObject
    {
        public string itemName;
        public GameObject itemGameObject;
        public float rotateSpeed;
        public float specificMaxAngularVelocity;
        public float touchCancelWaitingTime;
        public float specificAngularDrag;
        public float specificLowRotateSpeed;
        public bool isSelected;



    }
}
