using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.EffectMenegar
{
    public class ObstacleEffect : MonoBehaviour
    {
        public EffectTableObject effectTableObject;
        public void EffectStart()
        {
            var effect =   Instantiate(effectTableObject.particleSystem, transform.position, transform.rotation);
            effect.transform.position = transform.position+Vector3.up;
            effect.startColor = transform.GetComponent<MeshRenderer>().material.color;
            Destroy(effect.gameObject, effect.main.duration);
        }

       
    }
}
