using UnityEngine;

namespace Game.Scripts.EffectMenegar
{
    [CreateAssetMenu(menuName = "Inventory/Effect",fileName = "New Item")]
    public class EffectTableObject : ScriptableObject
    {
        public ParticleSystem particleSystem;
        public int moneyWorth;


      
    }
}
