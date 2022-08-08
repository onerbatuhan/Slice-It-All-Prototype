using Game.Scripts.ItemMenager;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.LevelMenager
{
    public class ShowEvent : Singleton<ShowEvent>
    {
        public ParticleSystem particleEffect;
        public void EffectStart()
        {
            var effect =   Instantiate(particleEffect, Item.Instance.currentUsedItem.transform.position ,Item.Instance.currentUsedItem.transform.rotation);
        }
    }
}
