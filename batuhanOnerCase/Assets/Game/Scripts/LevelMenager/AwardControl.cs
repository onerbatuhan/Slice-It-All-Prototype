using Game.Scripts.EconomyControls;
using UnityEngine;

namespace Game.Scripts.LevelMenager
{
    public class AwardControl : MonoBehaviour
    {
        public int prizeMultiplierValue;
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.layer != LayerMask.NameToLayer("Item") || other.gameObject.layer != LayerMask.NameToLayer("ItemBehind"))
            {
                MoneyController.Instance.MoneyMultiply(prizeMultiplierValue);
                MoneyCanvasEvents.Instance.AnimateMoneyCanvas();
            }
          
        }
    }
}
