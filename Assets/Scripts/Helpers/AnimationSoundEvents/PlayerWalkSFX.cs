using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Helpers.AnimationSoundEvents
{
    public class PlayerWalkSFX : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioMixer audioMixer;

        public void PlayAudioSource(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        public void SetPlayerSFXVolume(float volume)
        {
            audioMixer.SetFloat("SoundEffectsVolume", volume);
        }

    }
}