using DG.Tweening;
using Game.Scripts.GameMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.Pattern;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.LevelMenager
{
    public class MoneyCanvasEvents : Singleton<MoneyCanvasEvents>
    {
        public GameObject objectUI;
        public GameObject canvasBar;
        public void AnimateMoneyCanvas()
        {
            ShowEvent.Instance.EffectStart();
            GameControl.Instance.gameStates = GameControl.GameStates.Successful;
            for (var i = 0; i < 10; i++)
            {
                var currentObject = Instantiate(objectUI,Item.Instance.currentUsedItem.transform.position, objectUI.transform.rotation);
                currentObject.transform.SetParent(canvasBar.transform);
                currentObject.transform.position = Camera.main.WorldToScreenPoint(currentObject.transform.position);
                Vector2 v2 = (Vector2)currentObject.transform.position + Random.insideUnitCircle * 350;//Not al: Money ımage transform konumları, ör x:5 y:3 gibi ayarla. Ekrana bu şekilde ortalanması gerekiyor.
                
                currentObject.transform.DOMove(v2 , 1.3f).OnComplete(() =>
                {
                   
                    currentObject.transform.DOMove(canvasBar.transform.position, 1.2f).OnComplete(() =>
                    {
                        Destroy(currentObject);
                        Scripts.LevelMenager.LevelMenager.Instance.FinishTheGame(GameControl.GameStates.Successful);
                    });
                   
                });
            }
        }

       
    }
}
