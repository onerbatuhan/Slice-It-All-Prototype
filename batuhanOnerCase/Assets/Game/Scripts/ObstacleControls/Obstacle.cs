
using System;
using System.Collections;
using Game.Scripts.GameMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.MotionControls;
using UnityEngine;

namespace Game.Scripts.ObstacleControls
{
    public class Obstacle : MonoBehaviour
    {
        public ObstacleTypes.ObstacleType type;
        public ObstacleTypes.ObstacleDirectionType directionType;
        private ItemTypes.ItemType _currentUsedItemType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("ItemBehind"))
            {
                ItemBehindCollisionEvent(other,directionType);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                ItemFrontCollisionEvent(collision);
            }
        }
        private void ItemFrontCollisionEvent(Collision collision)
        {
            
            _currentUsedItemType = collision.transform.GetComponent<ItemCategory>().type;
            switch (type)
            {
                case ObstacleTypes.ObstacleType.Penetrable:
                    Penetrable(_currentUsedItemType,transform.GetComponent<Collider>());
                    break;
                case ObstacleTypes.ObstacleType.Fail:
                    ObstaclePhysicsOpen();
                    Fail(_currentUsedItemType);
                    break;
            }
        }
        private static void ItemBehindCollisionEvent(Collider other,ObstacleTypes.ObstacleDirectionType directionType)
        {
            if (!other.GetComponent<Rigidbody>())
            {
                ReverseMotionControl.Instance.MoveObjectBack(directionType);
            }
           
        }
        private static void Fail(ItemTypes.ItemType typeItem)
        {
            switch (typeItem)
            {
                case ItemTypes.ItemType.Standard:
                    LevelMenager.LevelMenager.Instance.FinishTheGame(GameControl.GameStates.Fail);
                    break;
            }
        }
        private static void Penetrable(ItemTypes.ItemType typeItem,Collider collider)
        {
            ObstacleCollisionControl.EndCollisionObstaclePhysicsClose();
            switch (typeItem)
            {
                case ItemTypes.ItemType.Standard:
                    PenetrableControl.Instance.Execute(collider);
                    break;
            }
        }
        private void ObstaclePhysicsOpen()
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
