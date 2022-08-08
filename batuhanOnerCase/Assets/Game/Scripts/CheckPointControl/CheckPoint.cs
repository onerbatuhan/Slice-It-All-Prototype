using System;
using Game.Scripts.EffectMenegar;
using UnityEngine;

namespace Game.Scripts.CheckPointControl
{
    public class CheckPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                transform.GetComponent<ObstacleEffect>().EffectStart();
            }
           
        }
    }
}
