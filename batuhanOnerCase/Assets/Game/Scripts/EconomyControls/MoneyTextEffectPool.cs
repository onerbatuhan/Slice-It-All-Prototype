using System;
using System.Collections.Generic;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.EconomyControls
{
    public class MoneyTextEffectPool : Singleton<MoneyTextEffectPool>
    {
        private Queue<GameObject> _poolMoneyEffect; 
        public GameObject objectEffectPrefab;
        public int poolSize;
        public Transform poolObject;
        
        private void Start()
        {
            _poolMoneyEffect = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(objectEffectPrefab,objectEffectPrefab.transform.position,objectEffectPrefab.transform.rotation,poolObject);
                obj.SetActive(false);
                _poolMoneyEffect.Enqueue(obj);
            }
        }
        public GameObject GetPooledEffectObject()
        {
            if (_poolMoneyEffect != null)
            {
                var obj = _poolMoneyEffect.Dequeue();  
                obj.SetActive(true);
                _poolMoneyEffect.Enqueue(obj);
                return obj;
            }
            else
            {
                var obj = Instantiate(objectEffectPrefab,objectEffectPrefab.transform.position,objectEffectPrefab.transform.rotation,poolObject);
                obj.SetActive(false);
                _poolMoneyEffect?.Enqueue(obj);
                return obj;
            }
           
            
        }
    }
}
