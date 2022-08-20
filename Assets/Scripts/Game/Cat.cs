using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class Cat : MonoBehaviour
    {
        [SerializeField]
        private EventListener _catSad;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Sprite _catSadTexture;

        [SerializeField]
        private Sprite _catNormalTexture;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _catSad.OnEventHappened += UpdateState;
        }

        private void OnDisable()
        {
            _catSad.OnEventHappened -= UpdateState;
        }

        private void UpdateState()
        {
            _spriteRenderer.sprite = _catSadTexture;
        }
    }
}