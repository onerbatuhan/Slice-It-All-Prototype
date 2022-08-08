using DG.Tweening;
using Game.Scripts.GameMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.MotionControls;
using Game.Scripts.Pattern;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.LevelMenager
{
    
    public class LevelMenager : Singleton<LevelMenager>
    {
    public GameObject levelSuccessUI;
    public GameObject levelFailUI;
    [SerializeField] private bool canReturn;
    
    public void LevelSuccess()
    {
        levelSuccessUI.SetActive(true);
        ScaleChange(levelSuccessUI);
        Item.Instance.currentUsedItemRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void LevelFail()
    {
        levelFailUI.SetActive(true);
        ScaleChange(levelFailUI);
        Item.Instance.currentUsedItemRigidbody.isKinematic = false;
        Item.Instance.currentUsedItemRigidbody.useGravity = true;
        Item.Instance.currentUsedItemRigidbody.constraints = RigidbodyConstraints.None;
    }

    public void LevelRestart()
    {
        RotationControl.Instance.canRotate = false;
        SceneManager. LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelUp()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount+1)
        {
            LevelRestart();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
    }
    private void ScaleChange(GameObject changeScaleObject)
    {
        var beforeScale = changeScaleObject.transform.localScale;
        changeScaleObject.transform.localScale = Vector3.zero;
        changeScaleObject.transform.DOScale(beforeScale, 1).SetEase(Ease.OutElastic);
    }

    public void FinishTheGame(GameControl.GameStates gameStates)
    {
        if (canReturn)
        {
            canReturn = false;
            switch (gameStates)
            {
                case GameControl.GameStates.Continues:
                    break;
                case GameControl.GameStates.Successful:
                    LevelSuccess();
                    break;
                case GameControl.GameStates.Fail:
                    LevelFail();
                    break;
            }
            GameControl.Instance.gameStates = gameStates;
            RotationControl.Instance.canRotate = false;

        }


    }
    }
}
