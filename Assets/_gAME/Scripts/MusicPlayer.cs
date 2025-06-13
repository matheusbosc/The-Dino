using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _gAME.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        public AudioClip[] clips;
        public AudioSource audioSource;

        void Start()
        {
            
            if (GameObject.FindGameObjectsWithTag("MusicPlayer").Length >= 2)
            {
                Destroy(gameObject);
            }
            Play();
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                Play();
            }
        }

        public void Play()
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}