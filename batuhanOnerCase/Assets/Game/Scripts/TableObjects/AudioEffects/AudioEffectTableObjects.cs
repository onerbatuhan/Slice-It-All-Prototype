using UnityEngine;

namespace Game.Scripts.TableObjects.AudioEffects
{
    [CreateAssetMenu(menuName = "Inventory/Audio",fileName = "New Item")]
    public class AudioEffectTableObjects : ScriptableObject
    {
        public AudioClip itemRotationAudio;
        public AudioClip itemBehindCollisionAudio;
        public AudioClip itemSliceAudio;


    }
}
