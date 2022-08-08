using Cinemachine;
using Game.Scripts.GameMenager;
using Game.Scripts.ItemMenager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Game.Scripts.MarketMenager
{
    public class MarketController : MonoBehaviour
    {
        public GameObject marketPanelUI;
        
        public void SelectItem()
        {
            GameObject selectObject = EventSystem.current.currentSelectedGameObject;
            foreach (var item in Item.Instance.usableTableItems)
            {
                item.isSelected = false;
            }
            Item.Instance.usableTableItems[selectObject.GetComponent<ItemID>().itemID].isSelected = true;
            CloseMarket();
            ItemChange();
        }

        public void OpenMarket()
        {
            
            Item.Instance.currentUsedItem.SetActive(false);
            marketPanelUI.SetActive(true);
        }
        public void CloseMarket()
        {
            Item.Instance.currentUsedItem.SetActive(true);
            marketPanelUI.SetActive(false);
        }

        public void ItemChange() 
        {
            Item.Instance.currentUsedItem.SetActive(false);
            var beforeItemPosition = Item.Instance.currentUsedItem.transform;
            Item.Instance.Awake();
            Item.Instance.currentUsedItem.transform.position = beforeItemPosition.position;
            Item.Instance.currentUsedItem.transform.rotation = beforeItemPosition.rotation;
            Item.Instance.currentUsedItemRigidbody.useGravity = true;
            GameControl.Instance.Start();
        }
       
    }

   
}
