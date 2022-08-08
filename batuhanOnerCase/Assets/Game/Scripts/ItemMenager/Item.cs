using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.TableObjects;
using Game.Scripts.TableObjects.Item;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.ItemMenager
{
    public class Item : Pattern.Singleton<Item>
    {
        public List<ItemTableObject> usableTableItems;
        public ItemTableObject currentTableObjectValues;
        public  GameObject currentUsedItem;
        public  Rigidbody currentUsedItemRigidbody;
        public Vector3 cloneItemStartPosition;
        public Quaternion cloneItemStartRotation;
        public  void Awake()
        {
            currentTableObjectValues = FindCurrentItem();
            AddItemToScene(currentTableObjectValues.itemGameObject);
        }
        
        private ItemTableObject FindCurrentItem()
        {
            foreach (var currentObject in usableTableItems.Where(currentObject => currentObject.isSelected))
            {
                currentTableObjectValues = currentObject;
            }
            return currentTableObjectValues;
        }
        private void AddItemToScene(GameObject currentObject)
        {
            currentUsedItem = Instantiate(currentObject, cloneItemStartPosition, cloneItemStartRotation);
            currentUsedItemRigidbody = currentUsedItem.GetComponent<Rigidbody>();
        }
    }
    
}
