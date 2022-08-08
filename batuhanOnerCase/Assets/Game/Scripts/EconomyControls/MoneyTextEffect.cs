using System;
using System.Collections;
using DG.Tweening;
using Game.Scripts.EffectMenegar;
using Game.Scripts.Pattern;
using TMPro;
using UnityEngine;

namespace Game.Scripts.EconomyControls
{
    public class MoneyTextEffect : Singleton<MoneyTextEffect>
    {
        private GameObject _sprite;
        public float addPositionYaxis;
        public float addPositionYaxisTime;
        public void EffectExecute(Transform obstacleTableObjectTransform, ObstacleEffect obstacleEffect)
        {
            _sprite =  MoneyTextEffectPool.Instance.GetPooledEffectObject();
            _sprite.transform.position = obstacleTableObjectTransform.position;
            _sprite.GetComponent<TextMeshPro>().text ="$"+ obstacleEffect.effectTableObject.moneyWorth;
            _sprite.transform.DOMoveY(_sprite.transform.position.y + addPositionYaxis, addPositionYaxisTime).SetEase(Ease.OutElastic)
                .OnComplete(() =>
                {
                    _sprite.SetActive(false);
                });
        }
    }
}
