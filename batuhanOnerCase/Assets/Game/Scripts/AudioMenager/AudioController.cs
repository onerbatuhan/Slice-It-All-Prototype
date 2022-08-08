using System;
using Game.Scripts.Pattern;
using Game.Scripts.TableObjects.AudioEffects;
using UnityEngine;

namespace Game.Scripts.AudioMenager
{
    public class AudioController : Singleton<AudioController>
    {
        public AudioEffectTableObjects audioEffectTableObjects;
        public AudioSource audioSource;
        public void RotationSoundStart()
        {
            audioSource.PlayOneShot(audioEffectTableObjects.itemRotationAudio);
        }
        public void CollisionSoundStart()
        {
            audioSource.PlayOneShot(audioEffectTableObjects.itemBehindCollisionAudio);
            
        }
        public void SliceSoundStart()
        {
            audioSource.PlayOneShot(audioEffectTableObjects.itemSliceAudio);
        }
    }
}
