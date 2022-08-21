using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _chponk;

        [SerializeField]
        private EventListener _startAudio;

        private void OnEnable()
        {
            _startAudio.OnEventHappened += StartAudio;
        }

        private void OnDisable()
        {
            _startAudio.OnEventHappened -= StartAudio;
        }

        private void StartAudio()
        {
            _chponk.Play();
        }
    }
}